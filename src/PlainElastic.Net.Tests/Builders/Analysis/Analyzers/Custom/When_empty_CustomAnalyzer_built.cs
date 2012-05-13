using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(CustomAnalyzer))]
    class When_empty_CustomAnalyzer_built
    {
        Because of = () => result = new CustomAnalyzer()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'custom' }".AltQuote());

        private static string result;
    }
}