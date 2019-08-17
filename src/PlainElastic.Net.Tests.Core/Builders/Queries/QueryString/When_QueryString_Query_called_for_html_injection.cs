using System;
using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(QueryString<>))]
    class When_QueryString_Query_called_for_html_injection
    {
        Establish context = () =>
        {
            htmlInjection = @"""> <script>alert(1)</script> <!--";

            queryString = new QueryString<object>();
        };

        Because of = () =>
            exception = Catch.Exception(() => queryString.Query(htmlInjection));

        It should_not_fail = () =>
            exception.ShouldBeNull();

        private static Exception exception;
        private static QueryString<object> queryString;
        private static string htmlInjection;
    }
}
