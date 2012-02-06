
using Newtonsoft.Json;
using PlainElastic.Net;
using PlainElastic.Net.QueryBuilder;
using PlainElastic.Net.Serialization;

namespace PlainSample
{
    public class ElasticClient
    {
        private readonly IElasticConnection connection;
        private readonly JsonNetSerializer serializer;

        public ElasticClient(string defaultHost, int defaultPort)
        {
            connection = new ElasticConnection{DefaultHost = defaultHost, DefaultPort  = defaultPort};
            serializer = new JsonNetSerializer();
        }

        public JsonSerializerSettings SerializerSettings
        {
            get { return serializer.Settings; }
            set { serializer.Settings = value; }
        }

        public IElasticConnection Connection
        {
            get { return connection; }
        }


        public GetResult<T> Get<T>(GetCommandBuilder getCommand)
        {
            var result = connection.Get(getCommand);
            return serializer.ToGetResult<T>(result);
        }

        public IndexResult Index(IndexCommandBuilder indexCommand, object document)
        {
            string data = serializer.ToJson(document);
            var result = connection.Put(indexCommand, data);
            return serializer.ToIndexResult(result);
        }

        public SearchResult<T> Search<T>(SearchCommandBuilder searchCommand, QueryBuilder<T> query)
        {
            var results = connection.Post(searchCommand, query.Build());
            return serializer.ToSearchResult<T>(results);
        }

        public DeleteResult Delete(DeleteCommandBuilder deleteCommand)
        {
            var result = connection.Delete(deleteCommand);
            return serializer.ToDeleteResult(result);
        }
    }
}
