using Machine.Specifications;

namespace PlainElastic.Net.Tests.Integration.Connection
{
    [Subject(typeof(ElasticConnection))]
    class When_async_GET_request_on_valid_ES_instance
    {
        Establish context = () =>
        {
            connection = new ElasticConnection();
        };


        Because of = () => 
            result = connection.GetAsync(@"http://localhost:9200?pretty=true").Result;


        It should_return_OK_status = () => result.Result.ShouldContain("\"status\" : 200");

        private static ElasticConnection connection;
        private static OperationResult result;
    }
}
