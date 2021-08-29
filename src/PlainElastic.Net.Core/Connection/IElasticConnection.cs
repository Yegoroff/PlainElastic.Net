
using System.Net;
using System.Threading.Tasks;

namespace PlainElastic.Net
{
    public interface IElasticConnection
    {
        string DefaultHost { get; set; }

        int DefaultPort { get; set; }

        IWebProxy Proxy { get; set; }

        ICredentials Credentials { get; set; }

        /// <summary>
        /// Timeout in milliseconds.
        /// </summary>
        int Timeout { get; set; }


        OperationResult Get(string command, string jsonData = null);

        OperationResult Post(string command, string jsonData = null);

        OperationResult Put(string command, string jsonData = null);

        OperationResult Delete(string command, string jsonData = null);

        OperationResult Head(string command, string jsonData = null);


        Task<OperationResult> GetAsync(string command, string jsonData = null);

        Task<OperationResult> PostAsync(string command, string jsonData = null);

        Task<OperationResult> PutAsync(string command, string jsonData = null);

        Task<OperationResult> DeleteAsync(string command, string jsonData = null);

        Task<OperationResult> HeadAsync(string command, string jsonData = null);
    }
}
