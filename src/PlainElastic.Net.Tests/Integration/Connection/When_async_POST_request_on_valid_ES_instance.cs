using Machine.Specifications;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Integration.Connection
{
    [Subject(typeof(ElasticConnection))]
    class When_async_POST_request_on_valid_ES_instance
    {
        Establish context = () =>
        {
            connection = new ElasticConnection("localhost", 9200);
        };


        Because of = () => 
            result = connection.PostAsync(command: "/test/foo", 
                                          jsonData: "{ 'field': 'value' }".AltQuote()
                                         ).Result;

        It should_return_OK = () =>
            result.Result.ShouldContain("\"ok\":true");


        private static ElasticConnection connection;
        private static OperationResult result;
    }
}
