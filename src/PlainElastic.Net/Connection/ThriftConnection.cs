using System;
using System.Net;
using System.Threading.Tasks;

namespace PlainElastic.Net.Connection
{
    public class ThriftConnection : IElasticConnection, IDisposable
    {
        public string DefaultHost { get; set; }
        public int DefaultPort { get; set; }
        public IWebProxy Proxy { get; set; }
        public ICredentials Credentials { get; set; }
        public int Timeout { get; set; }

        public OperationResult Get(string command, string jsonData = null)
        {
            throw new NotImplementedException();
        }

        public OperationResult Post(string command, string jsonData = null)
        {
            throw new NotImplementedException();
        }

        public OperationResult Put(string command, string jsonData = null)
        {
            throw new NotImplementedException();
        }

        public OperationResult Delete(string command, string jsonData = null)
        {
            throw new NotImplementedException();
        }

        public OperationResult Head(string command, string jsonData = null)
        {
            throw new NotImplementedException();
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

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
