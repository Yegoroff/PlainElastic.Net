using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(SnowballAnalyzer))]
    class When_empty_SnowballAnalyzer_built
    {
        Because of = () => result = new SnowballAnalyzer()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'snowball' }".AltQuote());

        private static string result;
    }
}