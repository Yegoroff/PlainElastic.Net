using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(WhitespaceAnalyzer))]
    class When_empty_WhitespaceAnalyzer_built
    {
        Because of = () => result = new WhitespaceAnalyzer()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'whitespace' }".AltQuote());

        private static string result;
    }
}