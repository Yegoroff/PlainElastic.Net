using System.Net;
using Machine.Specifications;

namespace PlainElastic.Net.Tests.Connection
{
    [Subject(typeof(ElasticConnection))]
    class When_CreateRequest_with_no_Proxy_specified_called
    {
        Establish context = () => {
            defaultProxy = new WebProxy("http://default-proxy.example.com");
            WebRequest.DefaultWebProxy = defaultProxy;

            connection = new TestableConnection();
        };

        Because of = () =>
            result = connection.CreateRequest("GET", "http://www.example.com");

        It should_return_WebRequest_with_default_proxy = () =>
            result.Proxy.ShouldEqual(defaultProxy);

        private static HttpWebRequest result;
        private static IWebProxy defaultProxy;
        private static TestableConnection connection;
    }
}
