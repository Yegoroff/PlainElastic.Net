using Machine.Specifications;

namespace PlainElastic.Net.Tests.Integration.Connection
{
    [Subject(typeof(ElasticConnection))]
    class When_full_GET_request_on_valid_ES_instance
    {
        Establish context = () =>
        {
            connection = new ElasticConnection();
        };


        Because of = () => result = connection.Get(@"http://localhost:9200?pretty=true");


        It should_return_OK = () => result.Result.ShouldContain("\"ok\" : true");

        private static ElasticConnection connection;
        private static OperationResult result;
    }
}
