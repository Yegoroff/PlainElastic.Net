using System.Net;
using Machine.Specifications;

namespace PlainElastic.Net.Tests.Connection
{
    [Subject(typeof(ElasticConnection))]
    class When_CreateRequest_with_Proxy_called
    {
        Establish context = () => {
            proxy = new WebProxy();
            connection = new TestableConnection { Proxy = proxy };
        };

        Because of = () =>
            result = connection.CreateRequest("GET", "http://www.example.com");

        It should_return_WebRequest_with_configured_proxy = () =>
            result.Proxy.ShouldEqual(proxy);

        private static HttpWebRequest result;
        private static IWebProxy proxy;
        private static TestableConnection connection;
    }
}
