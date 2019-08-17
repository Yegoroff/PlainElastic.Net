using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(StandardAnalyzer))]
    class When_empty_StandardAnalyzer_built
    {
        Because of = () => result = new StandardAnalyzer()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'standard' }".AltQuote());

        private static string result;
    }
}