using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(WhitespaceTokenizer))]
    class When_empty_WhitespaceTokenizer_built
    {
        Because of = () => result = new WhitespaceTokenizer()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'whitespace' }".AltQuote());

        private static string result;
    }
}