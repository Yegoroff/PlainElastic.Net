using System;
using System.IO;
using System.Net;
using System.Text;

namespace PlainElastic.Net
{
    public class ElasticConnection: IElasticConnection
    {
        
        public string DefaultHost { get; set; }

        public int DefaultPort { get; set; }
        

        public OperationResult Get(string command)
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




        private OperationResult ExecuteRequest(string method, string command, string jsonData)
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

            using (WebResponse response = request.GetResponse())
            {
                var result = new StreamReader(response.GetResponseStream()).ReadToEnd();
                return new OperationResult(result);
            }
        }

        private HttpWebRequest CreateRequest(string method, string uri)
        {
            var request = (HttpWebRequest) WebRequest.Create(uri);

#warning check this settings !!!

            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.Timeout = 1000*60;          // 1 minute timeout.
            request.ReadWriteTimeout = 1000*60; // 1 minute timeout.
            request.Method = method;

            //TODO: Setup Proxy
            // support HTTPS (with provided certificate) and digest (u/p)

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
