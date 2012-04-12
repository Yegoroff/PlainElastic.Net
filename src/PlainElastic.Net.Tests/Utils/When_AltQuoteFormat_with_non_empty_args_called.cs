using Machine.Specifications;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Utils
{
    [Subject(typeof(StringExtensions))]
    class When_AltQuoteFormat_with_non_empty_args_called
    {
        Because of = () => 
            result = "'Custom Format': {0}".AltQuoteF("arguments");

        It should_return_format_string_with_arguments_and_double_quotes = () =>
            result.ShouldEqual("\"Custom Format\": arguments");

        private static string result;
    }
}
