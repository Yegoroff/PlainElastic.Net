using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(PatternAnalyzer))]
    class When_empty_PatternAnalyzer_built
    {
        Because of = () => result = new PatternAnalyzer()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'pattern' }".AltQuote());

        private static string result;
    }
}