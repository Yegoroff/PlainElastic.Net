using Machine.Specifications;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Integration.Connection
{
    [Subject(typeof(ElasticConnection))]
    class When_async_DELETE_request_on_valid_ES_instance
    {
        Establish context = () =>
        {
            connection = new ElasticConnection("localhost", 9200);
            connection.Put("/test/foo/1", "{ 'field': 'value' }".AltQuote());
        };


        Because of = () => 
            result = connection.DeleteAsync(command: "/test/foo/_query", 
                                         jsonData: "{'query': {'term': { 'field': 'value' } } }".AltQuote()
                                         ).Result;

        It should_not_fail = () =>
            result.Result.ShouldContain("\"failed\":0");


        private static ElasticConnection connection;
        private static OperationResult result;
    }
}
