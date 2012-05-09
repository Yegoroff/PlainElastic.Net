using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(AnalyzerSettings))]
    class When_empty_AnalyzerSettings_built
    {
        Because of = () => result = new AnalyzerSettings()
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'analyzer': {  }".AltQuote());

        private static string result;
    }
}