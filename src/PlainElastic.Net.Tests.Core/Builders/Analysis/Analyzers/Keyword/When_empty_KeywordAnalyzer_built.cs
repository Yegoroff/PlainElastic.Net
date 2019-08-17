using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(KeywordAnalyzer))]
    class When_empty_KeywordAnalyzer_built
    {
        Because of = () => result = new KeywordAnalyzer()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'keyword' }".AltQuote());

        private static string result;
    }
}