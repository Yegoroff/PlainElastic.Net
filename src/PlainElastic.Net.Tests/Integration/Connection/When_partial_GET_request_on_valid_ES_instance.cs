using Machine.Specifications;

namespace PlainElastic.Net.Tests.Integration.Connection
{
    [Subject(typeof(ElasticConnection))]
    class When_partial_GET_request_on_valid_ES_instance
    {
        Establish context = () =>
        {
            connection = new ElasticConnection("localhost", 9200);
        };


        Because of = () => result = connection.Get("_refresh?pretty=true");


        It should_not_fail = () => result.Result.ShouldContain("\"failed\" : 0");

        private static ElasticConnection connection;
        private static OperationResult result;
    }
}
