using Machine.Specifications;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Utils
{
    [Subject(typeof(StringExtensions))]
    class When_AltQuoteFormat_with_null_format_called
    {
        Because of = () => 
            result = ((string)null).AltQuoteF(null);

        It should_return_null = () =>
            result.ShouldBeNull();

        private static string result;
    }
}
