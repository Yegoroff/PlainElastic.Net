using System;
using System.Net;
using Machine.Specifications;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Integration.Connection
{
    [Subject(typeof(ElasticConnection))]
    class When_invalid_GET_request_on_valid_ES_instance
    {
        Establish context = () =>
        {
            connection = new ElasticConnection();
        };


        Because of = () => 
            exception = Catch.Exception(() => connection.Get(@"http://localhost:9200/invalid"));


        It should_throw_OperationException = () => exception.ShouldBe(typeof(OperationException));

        It should_throw_exception_with_message = () => exception.Message.ShouldEqual(@"{'error':'IndexMissingException[[invalid] missing]','status':404}".AltQuote());

        It should_throw_exception_with_inner_WebException = () => exception.InnerException.ShouldBe(typeof(WebException));


        private static ElasticConnection connection;
        private static Exception exception;
    }
}
