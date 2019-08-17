using System.Net;
using Machine.Specifications;

namespace PlainElastic.Net.Tests.Connection
{
    [Subject(typeof(ElasticConnection))]
    class When_CreateRequest_with_null_Proxy_called
    {
        Establish context = () => {
            WebRequest.DefaultWebProxy = new WebProxy("http://default-proxy.example.com");

            connection = new TestableConnection { Proxy = null };
        };

        Because of = () =>
            result = connection.CreateRequest("GET", "http://www.example.com");

        It should_return_WebRequest_with_null_proxy = () =>
            result.Proxy.ShouldEqual(null);

        private static HttpWebRequest result;
        private static TestableConnection connection;
    }
}
