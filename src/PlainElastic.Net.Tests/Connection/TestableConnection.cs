using System.Net;

namespace PlainElastic.Net.Tests.Connection
{
    public class TestableConnection : ElasticConnection
    {
        public new HttpWebRequest CreateRequest(string method, string uri)
        {
            return base.CreateRequest(method, uri);
        }
    }
}