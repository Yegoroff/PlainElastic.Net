using Machine.Specifications;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Utils
{
    [Subject(typeof(StringExtensions))]
    class When_Format_with_non_empty_args_called
    {
        Because of = () => 
            result = "Custom Format {0}".F("arguments");

        It should_return_format_string_with_arguments = () =>
            result.ShouldEqual("Custom Format arguments");

        private static string result;
    }
}
