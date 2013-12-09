using System;
using System.Net;
using Machine.Specifications;

namespace PlainElastic.Net.Tests.Integration.Connection
{
    [Subject(typeof(ElasticConnection))]
    class When_invalid_async_GET_request_on_valid_ES_instance
    {
        Establish context = () =>
        {
            connection = new ElasticConnection();
        };


        Because of = () =>{
            var aggregateException = Catch.Exception(connection.GetAsync(@"http://localhost:9200/invalid").Wait);
            exception = aggregateException.InnerException;
        };


        It should_throw_OperationException = () => 
            exception.ShouldBe(typeof(OperationException));

        It should_throw_exception_with_message = () =>
            exception.Message.ShouldEqual("No handler found for uri [/invalid] and method [GET]");

        It should_throw_exception_with_inner_WebException = () =>
            exception.InnerException.ShouldBe(typeof(WebException));


        private static ElasticConnection connection;
        private static Exception exception;
    }
}
