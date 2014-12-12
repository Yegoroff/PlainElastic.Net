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


        It should_return_OK_status = () => result.Result.ShouldContain("\"status\" : 200");

        private static ElasticConnection connection;
        private static OperationResult result;
    }
}
