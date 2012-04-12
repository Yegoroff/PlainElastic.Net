using Machine.Specifications;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Utils
{
    [Subject(typeof(StringExtensions))]
    class When_Quotate_with_special_characters_called
    {
        Because of = () =>
            result = "\\ Some \" special \n chars \t".Quotate();

        It should_return_string_in_double_quotes_and_with_escaped_special_chars = () =>
            result.ShouldEqual(@"""\\ Some \"" special \n chars \t""");

        private static string result;
    }
}
