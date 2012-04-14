using Machine.Specifications;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Utils
{
    [Subject(typeof(StringExtensions))]
    class When_Quotate_with_non_printable_characters_called
    {
        Because of = () =>
            result = "Some \u001a non printable \u0005 chars".Quotate();

        It should_return_string_in_double_quotes_and_with_unicode_encoded_non_printable_chars = () =>
            result.ShouldEqual(@"""Some \u001a non printable \u0005 chars""");

        private static string result;
    }
}
