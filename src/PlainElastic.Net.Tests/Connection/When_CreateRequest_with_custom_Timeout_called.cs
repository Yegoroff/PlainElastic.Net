using System.Net;
using Machine.Specifications;

namespace PlainElastic.Net.Tests.Connection
{
    [Subject(typeof(ElasticConnection))]
    class When_CreateRequest_with_custom_Timeout_called
    {
        Establish context = () => {
            timeout = 1000;
            connection = new TestableConnection { Timeout = timeout };
        };

        Because of = () =>
            result = connection.CreateRequest("GET", "http://www.example.com");

        It should_return_WebRequest_with_configured_timeout = () =>
            result.Timeout.ShouldEqual(timeout);

        private static HttpWebRequest result;
        private static TestableConnection connection;
        private static int timeout;
    }
}
