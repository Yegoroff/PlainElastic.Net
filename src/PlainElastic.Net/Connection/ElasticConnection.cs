using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
    public class ElasticConnection: IElasticConnection
    {
        private IWebProxy proxy;
        private bool proxySet;

        public ElasticConnection(string defaultHost = null, int defaultPort = 9200)
        {
            DefaultHost = defaultHost;
            DefaultPort = defaultPort;
            Timeout = 60 * 1000; // 60 seconds
        }

        
        public string DefaultHost { get; set; }

        public int DefaultPort { get; set; }

        public IWebProxy Proxy
        {
            get { return proxySet ? proxy : WebRequest.DefaultWebProxy; }
            set {
                proxy = value;
                proxySet = true;
            }
        }

        public ICredentials Credentials { get; set; }

        /// <summary>
        /// Timeout in milliseconds. Default value 1 minute or 60000 msec
        /// </summary>
        public int Timeout { get; set; }


        public OperationResult Get(string command, string jsonData = null)
        {
            return ExecuteRequest("GET", command, jsonData);
        }

        public OperationResult Post(string command, string jsonData = null)
        {
            return ExecuteRequest("POST", command, jsonData);
        }

        public OperationResult Put(string command, string jsonData = null)
        {
            return ExecuteRequest("PUT", command, jsonData);
        }

        public OperationResult Delete(string command, string jsonData = null)
        {
            return ExecuteRequest("DELETE", command, jsonData);
        }

        public OperationResult Head(string command, string jsonData = null)
        {
            return ExecuteRequest("HEAD", command, jsonData);
        }


        public Task<OperationResult> GetAsync(string command, string jsondata = null)
        {
            return ExecuteRequestAsync("GET", command, jsondata);
        }

        public Task<OperationResult> PostAsync(string command, string jsonData = null)
        {
            return ExecuteRequestAsync("POST", command, jsonData);
        }

        public Task<OperationResult> PutAsync(string command, string jsonData = null)
        {
            return ExecuteRequestAsync("PUT", command, jsonData);
        }

        public Task<OperationResult> DeleteAsync(string command, string jsonData = null)
        {
            return ExecuteRequestAsync("DELETE", command, jsonData);
        }

        public Task<OperationResult> HeadAsync(string command, string jsonData = null)
        {
            return ExecuteRequestAsync("HEAD", command, jsonData);
        }


        private OperationResult ExecuteRequest(string method, string command, string jsonData)
        {
            try
            {
                string uri = CommandToUri(command);
                var request = CreateRequest(method, uri);

                // Add request payload if any.
                if (!jsonData.IsNullOrEmpty())
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(jsonData);
                    request.ContentLength = buffer.Length;
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(buffer, 0, buffer.Length);
                    }
                }

                // Execute request.
                using (WebResponse response = request.GetResponse())
                {
                    var result = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    return new OperationResult(result);
                }

            }
            catch (WebException ex)
            {
                var operationException = HandleWebException(ex);    
                throw operationException;
            }

        }

        private OperationException HandleWebException(WebException webException)
        {
            var message = webException.Message;
            var response = webException.Response;
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

            return new OperationException(message, statusCode, webException);
        }


        private Task<OperationResult> ExecuteRequestAsync(string method, string command, string jsonData)
        {
            var executeCompletionSource = new TaskCompletionSource<OperationResult>();

            var stepsEnumerator = AsyncExecutionSteps(method, command, jsonData, executeCompletionSource).GetEnumerator();

            Action<Task> sequentialStepRunner = null;
            sequentialStepRunner = completedStep =>
            {
                if (completedStep != null && completedStep.IsFaulted)
                {
                    var exception = completedStep.Exception.InnerException;
                    if (exception is WebException)
                        exception = HandleWebException((WebException)exception);

                    executeCompletionSource.TrySetException(exception);
                    stepsEnumerator.Dispose();
                }

                else if (stepsEnumerator.MoveNext())
                {
                    stepsEnumerator.Current.ContinueWith(sequentialStepRunner, TaskContinuationOptions.ExecuteSynchronously);
                }

                else stepsEnumerator.Dispose();
            };

            sequentialStepRunner(null);

            return executeCompletionSource.Task;
        }

        private IEnumerable<Task> AsyncExecutionSteps(string method, string command, string jsonData, TaskCompletionSource<OperationResult> executeCompletionSource)
        {
            string uri = CommandToUri(command);
            var request = CreateRequest(method, uri);

            // Send the JSON request if any
            if (!jsonData.IsNullOrEmpty())
            {
                Task<Stream> getRequestStream = Task.Factory.FromAsync<Stream>(request.BeginGetRequestStream,
                                                                               request.EndGetRequestStream, null);
                yield return getRequestStream;

                byte[] buffer = Encoding.UTF8.GetBytes(jsonData);
                using (var requestStream = getRequestStream.Result)
                {
                    var sendRequestData = Task.Factory.FromAsync(requestStream.BeginWrite,
                                                                 requestStream.EndWrite,
                                                                 buffer, 0, buffer.Length,
                                                                 null);
                    yield return sendRequestData;
                }
            }

            // Get response 
            var getResponse = Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);
            yield return getResponse;

            // Read respoonse JSON data
            using (var response = getResponse.Result)
            using (var responseStream = response.GetResponseStream())
            {
                var responseData = new MemoryStream();
                var buffer = new byte[response.ContentLength > 0 ? response.ContentLength : 0x100];
                while (true)
                {
                    var readResponseChunk = Task<int>.Factory.FromAsync(responseStream.BeginRead, responseStream.EndRead,
                                                                       buffer, 0, buffer.Length, null);
                    yield return readResponseChunk;

                    if (readResponseChunk.Result == 0)
                        break;

                    responseData.Write(buffer, 0, readResponseChunk.Result);
                }

                // Convert read data to result JSON string
                string result = Encoding.UTF8.GetString(responseData.ToArray());
                executeCompletionSource.TrySetResult(new OperationResult(result));
            }
        }


        protected virtual HttpWebRequest CreateRequest(string method, string uri)
        {
            var request = (HttpWebRequest) WebRequest.Create(uri);

            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.Timeout = Timeout;
            request.Method = method;

            if (proxySet)
                request.Proxy = proxy;

            if (Credentials != null)
                request.Credentials = Credentials;

            return request;
        }


        private string CommandToUri(string command)
        {
            if (Uri.IsWellFormedUriString(command, UriKind.Absolute))
                return command;

            return @"http://{0}:{1}/{2}".F(DefaultHost, DefaultPort, command);
        }
    }
}
