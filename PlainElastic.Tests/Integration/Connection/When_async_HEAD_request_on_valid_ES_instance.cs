using Machine.Specifications;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Integration.Connection
{
    [Subject(typeof(ElasticConnection))]
    class When_async_HEAD_request_on_valid_ES_instance
    {
        Establish context = () =>
        {
            connection = new ElasticConnection("localhost", 9200);
            connection.Put("/test/foo/1", "{ 'field': 'value' }".AltQuote());
        };


        Because of = () => 
            result = connection.HeadAsync(command: "/test/foo").Result;

        It should_return_empty_result = () =>
            result.Result.ShouldBeEmpty();


        private static ElasticConnection connection;
        private static OperationResult result;
    }
}
