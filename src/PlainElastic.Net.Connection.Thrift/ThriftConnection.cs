using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PlainElastic.Net.Connection.Thrift.Protocol;
using PlainElastic.Net.Connection.Thrift.Transport;

namespace PlainElastic.Net.Connection.Thrift
{
	public class ThriftConnection : IElasticConnection, IDisposable
	{
		private readonly ConcurrentQueue<Rest.Client> _clients = new ConcurrentQueue<Rest.Client>();
		private readonly Semaphore _resourceLock;
		private readonly int _poolSize;
		private bool _disposed;

        public ThriftConnection(string defaultHost = null, int defaultPort = 9200)
		{
            DefaultHost = defaultHost;
            DefaultPort = defaultPort;
            Timeout = 60 * 1000; // 60 seconds
            var MaximumAsyncConnections = 20;
			this._poolSize = Math.Max(1, MaximumAsyncConnections);

			this._resourceLock = new Semaphore(_poolSize, _poolSize);

			for (var i = 0; i <= MaximumAsyncConnections; i++)
			{
				var tsocket = new TSocket(defaultHost, defaultPort);
				var transport = new TBufferedTransport(tsocket, 1024);
				var protocol = new TBinaryProtocol(transport);
				var client = new Rest.Client(protocol);
				_clients.Enqueue(client);
			}
		}

        public OperationResult Get(string command, string jsonData = null)
        {
            var restRequest = new RestRequest();
            restRequest.Method = Method.GET;
            restRequest.Uri = command;

            restRequest.Headers = new Dictionary<string, string>();
            restRequest.Headers.Add("Content-Type", "application/json");
            return this.Execute(restRequest);
        }

        public OperationResult Post(string command, string jsonData = null)
        {
            var restRequest = new RestRequest();
            restRequest.Method = Method.POST;
            restRequest.Uri = command;

            if (jsonData != null)
                restRequest.Body = Encoding.UTF8.GetBytes(jsonData);
            restRequest.Headers = new Dictionary<string, string>();
            restRequest.Headers.Add("Content-Type", "application/json");
            return this.Execute(restRequest);
        }

        public OperationResult Put(string command, string jsonData = null)
        {
            var restRequest = new RestRequest();
            restRequest.Method = Method.PUT;
            restRequest.Uri = command;

            if (jsonData != null)
                restRequest.Body = Encoding.UTF8.GetBytes(jsonData);
            restRequest.Headers = new Dictionary<string, string>();
            restRequest.Headers.Add("Content-Type", "application/json");
            return this.Execute(restRequest);
        }

        public OperationResult Delete(string command, string jsonData = null)
        {
            var restRequest = new RestRequest();
            restRequest.Method = Method.DELETE;
            restRequest.Uri = command;

            if (jsonData != null)
                restRequest.Body = Encoding.UTF8.GetBytes(jsonData);
            restRequest.Headers = new Dictionary<string, string>();
            restRequest.Headers.Add("Content-Type", "application/json");
            return this.Execute(restRequest);
        }

        public OperationResult Head(string command, string jsonData = null)
        {
            var restRequest = new RestRequest();
            restRequest.Method = Method.HEAD;
            restRequest.Uri = command;

            restRequest.Headers = new Dictionary<string, string>();
            restRequest.Headers.Add("Content-Type", "application/json");
            return this.Execute(restRequest);

        }

        public Task<OperationResult> GetAsync(string command, string jsonData = null)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> PostAsync(string command, string jsonData = null)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> PutAsync(string command, string jsonData = null)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> DeleteAsync(string command, string jsonData = null)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> HeadAsync(string command, string jsonData = null)
        {
            throw new NotImplementedException();
        }

		#region IDisposable Members

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
		}

		#endregion

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
			{
				return;
			}

			foreach (var c in this._clients)
			{
				if (c != null 
					&& c.InputProtocol != null 
					&& c.InputProtocol.Transport != null 
					&& c.InputProtocol.Transport.IsOpen)
					c.InputProtocol.Transport.Close();
			}
			_disposed = true;
		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="HttpConnection"/> is reclaimed by garbage collection.
		/// </summary>
		~ThriftConnection()
		{
			Dispose(false);
		}



        private OperationResult Execute(RestRequest restRequest)
		{
			//RestResponse result = GetClient().execute(restRequest);
			//
			var method = Enum.GetName(typeof (Method), restRequest.Method);
			var path = restRequest.Uri;
			var requestData = restRequest.Body;
			if (!this._resourceLock.WaitOne(Timeout))
			{
				var m = "Could not start the thrift operation before the timeout of " + Timeout + "ms completed while waiting for the semaphore";
                throw new OperationException(m, 500, new TimeoutException(m));
			}
			try
			{
				Rest.Client client = null;
				if (!this._clients.TryDequeue(out client))
				{
					var m = string.Format("Could dequeue a thrift client from internal socket pool of size {0}", this._poolSize);
                    throw new OperationException(m, 500, new Exception(m));
				}
				try
				{
					if (!client.InputProtocol.Transport.IsOpen)
						client.InputProtocol.Transport.Open();

					var result = client.execute(restRequest);
					if (result.Status == Status.OK || result.Status == Status.CREATED || result.Status == Status.ACCEPTED)
                        return new OperationResult(Encoding.UTF8.GetString(result.Body));
					else
					{
					    throw new OperationException("Unable to connect", (int)result.Status, new Exception("Unable to connect"));
					}
				}
				finally
				{
					//make sure we make the client available again.
					this._clients.Enqueue(client);
				}
			}
			catch (Exception e)
			{
			    throw new OperationException("Error", 500, e);
			}
			finally
			{
				this._resourceLock.Release();
			}
		}

		public string DecodeStr(byte[] bytes)
		{
			if (bytes != null && bytes.Length > 0)
			{
				return Encoding.UTF8.GetString(bytes);
			}
			return string.Empty;
		}

	    public string DefaultHost { get; set; }
	    public int DefaultPort { get; set; }
	    public IWebProxy Proxy { get; set; }
	    public ICredentials Credentials { get; set; }
	    public int Timeout { get; set; }
	}
}