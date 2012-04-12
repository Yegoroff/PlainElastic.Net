using Machine.Specifications;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Utils
{
    [Subject(typeof(StringExtensions))]
    class When_AltQuoteFormat_with_null_args_called
    {
        Because of = () => 
            result = "{ 'Custom' } Format".AltQuoteF(null);

        It should_return_format_string_with_double_qoutes = () =>
            result.ShouldEqual("{ \"Custom\" } Format");

        private static string result;
    }
}
