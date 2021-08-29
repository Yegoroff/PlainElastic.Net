using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(StopAnalyzer))]
    class When_empty_StopAnalyzer_built
    {
        Because of = () => result = new StopAnalyzer()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'stop' }".AltQuote());

        private static string result;
    }
}