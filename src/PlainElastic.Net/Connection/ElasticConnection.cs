using System;
using System.IO;
using System.Net;
using System.Text;
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
            return ExecuteRequest("GET", command, null);
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

                throw new OperationException(message, statusCode, ex);
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
