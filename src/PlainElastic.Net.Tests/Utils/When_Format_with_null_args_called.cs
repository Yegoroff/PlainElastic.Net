using Machine.Specifications;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Utils
{
    [Subject(typeof(StringExtensions))]
    class When_Format_with_null_args_called
    {
        Because of = () => 
            result = "{ Custom } Format".F(null);

        It should_return_format_string = () =>
            result.ShouldEqual("{ Custom } Format");

        private static string result;
    }
}
