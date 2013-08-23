using System;
using System.IO;
using System.Net;
using System.Text;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
	partial class ElasticConnection
	{
		public IAsyncResult BeginRequest(RequestMethodEnum method, string command, string jsonData, AsyncCallback cb, object state)
		{
			return BeginExecuteRequest(method.ToString(), command, jsonData, cb, state);
		}

		public OperationResult EndRequest(IAsyncResult res)
		{
			return EndExecuteRequest(res);
		}

		private IAsyncResult BeginExecuteRequest(string method, string command, string jsonData, AsyncCallback cb, object state)
		{
			var rval = AsyncResult.CreateAndStart(cb, state);

			try
			{
				string uri = CommandToUri(command);
				var request = CreateRequest(method, uri);

				if (!jsonData.IsNullOrEmpty())
				{
					byte[] buffer = Encoding.UTF8.GetBytes(jsonData);
					request.ContentLength = buffer.Length;
					request.BeginGetRequestStream(CompleteGetRequestStream, new Tuple<HttpWebRequest, AsyncResult, byte[]>(request, rval, buffer));
				}
				else
					request.BeginGetResponse(CompleteGetResponse, new Tuple<HttpWebRequest, AsyncResult>(request, rval));

			}
			catch (Exception ex)
			{
				if (ex is WebException) ex = GetDetailedOuterException((WebException)ex);
				rval.End(ex, true);
			}

			return rval;
		}

		private OperationResult EndExecuteRequest(IAsyncResult res)
		{
			var result = (AsyncResult)res;

			if (!res.IsCompleted) throw new InvalidOperationException("Request is not complete");
			if (result.Error != null) throw result.Error;

			var data = result.Result != null ? Encoding.UTF8.GetString((byte[])result.Result) : string.Empty;

			return new OperationResult(data);
		}

		private static void CompleteGetRequestStream(IAsyncResult res)
		{
			var state = (Tuple<HttpWebRequest, AsyncResult, byte[]>)res.AsyncState;
			try
			{
				var requestStream = state.Item1.EndGetRequestStream(res);
				requestStream.BeginWrite(state.Item3, 0, state.Item3.Length, (r) =>
				{
					var stream = (Stream)r.AsyncState;
					try
					{
						stream.EndWrite(r);
						state.Item1.BeginGetResponse(CompleteGetResponse, new Tuple<HttpWebRequest, AsyncResult>(state.Item1, state.Item2));
					}
					catch (Exception ex)
					{
						if (ex is WebException) ex = GetDetailedOuterException((WebException)ex);
						state.Item2.End(ex);
					}
					finally
					{
						try { stream.Dispose(); }
						catch { };
					}

				}, requestStream);

			}

			catch (Exception ex)
			{
				if (ex is WebException) ex = GetDetailedOuterException((WebException)ex);
				state.Item2.End(ex);
			}
		}

		private static void CompleteGetResponse(IAsyncResult res)
		{
			var state = (Tuple<HttpWebRequest, AsyncResult>)res.AsyncState;
			WebResponse response = null;
			Stream stream = null;
			try
			{
				response = state.Item1.EndGetResponse(res);
				stream = response.GetResponseStream();
				var buffer = new byte[4096];
				if (response.ContentLength != 0)
				{
					var output = new MemoryStream((int)Math.Max(response.ContentLength, 4096));
					var newState = new Tuple<AsyncResult, WebResponse, byte[], Stream, MemoryStream>(state.Item2, response, buffer, stream, output);
					stream.BeginRead(buffer, 0, buffer.Length, CompleteReadChunk, newState);
				}
				else
					state.Item2.End(null);
			}
			catch (Exception ex)
			{
				HandleException(state.Item2, response, stream, ex);
			}
		}

		private static void CompleteReadChunk(IAsyncResult res)
		{
			var state = (Tuple<AsyncResult, WebResponse, byte[], Stream, MemoryStream>)res.AsyncState;
			try
			{
				var readed = state.Item4.EndRead(res);
				if (readed > 0)
				{
					state.Item5.Write(state.Item3, 0, readed);
					if (state.Item2.ContentLength < state.Item5.Length)
						state.Item4.BeginRead(state.Item3, 0, state.Item3.Length, CompleteReadChunk, state);
					else
						CompleteReadData(state.Item1, state.Item2, state.Item5, state.Item4);
				}
				else
					CompleteReadData(state.Item1, state.Item2, state.Item5, state.Item4);
			}
			catch (Exception ex)
			{
				HandleException(state.Item1, state.Item2, state.Item4, ex);
			}
		}

		private static void CompleteReadData(AsyncResult result, WebResponse response, MemoryStream output, Stream stream)
		{
			try { stream.Dispose(); }
			catch { }
			try { ((IDisposable)response).Dispose(); }
			catch { }
			result.End(output.ToArray());
		}

		private static void HandleException(AsyncResult result, WebResponse response, Stream stream, Exception ex)
		{
			if (stream != null)
				try { stream.Dispose(); }
				catch { }
			if (response != null)
				try { ((IDisposable)response).Dispose(); }
				catch { }

			if (ex is WebException) ex = GetDetailedOuterException((WebException)ex);
			result.End(ex);
		}

		private static OperationException GetDetailedOuterException(WebException ex)
		{
			var message = ex.Message;
			var response = ex.Response;
			if (response != null)
			{
				using (var responseStream = response.GetResponseStream())
				{
					message = new StreamReader(responseStream, true).ReadToEnd();
				}
			}

			int statusCode = 0;
			if (response is HttpWebResponse)
				statusCode = (int)((HttpWebResponse)response).StatusCode;

			var outerEx = new OperationException(message, statusCode, ex);
			return outerEx;
		}

	}
}
