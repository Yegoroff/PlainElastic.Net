
namespace PlainElastic.Net
{
    public interface IElasticConnection
    {
        string DefaultHost { get; }

        int DefaultPort { get; }

        OperationResult Get(string command, string jsonData = null);

        OperationResult Post(string command, string jsonData = null);

        OperationResult Put(string command, string jsonData = null);

        OperationResult Delete(string command, string jsonData = null);

        OperationResult Head(string command, string jsonData = null);
    }
}
