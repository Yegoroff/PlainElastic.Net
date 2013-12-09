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
                                         jsonData: "{'term': { 'field': 'value' } }".AltQuote()
                                         ).Result;

        It should_return_OK = () =>
            result.Result.ShouldContain("\"ok\":true");


        private static ElasticConnection connection;
        private static OperationResult result;
    }
}
