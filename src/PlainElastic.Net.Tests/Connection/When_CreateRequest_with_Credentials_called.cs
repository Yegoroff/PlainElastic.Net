using System.Net;
using Machine.Specifications;

namespace PlainElastic.Net.Tests.Connection
{
    [Subject(typeof(ElasticConnection))]
    class When_CreateRequest_with_Credentials_called
    {
        Establish context = () => {
            credentials = new NetworkCredential(userName: "User", password: "Password");
            connection = new TestableConnection {Credentials = credentials};
        };

        Because of = () =>
            result = connection.CreateRequest("GET", "http://www.example.com");

        It should_return_WebRequest_with_configured_credentials = () =>
            result.Credentials.ShouldEqual(credentials);

        private static HttpWebRequest result;
        private static TestableConnection connection;
        private static ICredentials credentials;
    }

}
