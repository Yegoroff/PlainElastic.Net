using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(SimpleAnalyzer))]
    class When_empty_SimpleAnalyzer_built
    {
        Because of = () => result = new SimpleAnalyzer()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'simple' }".AltQuote());

        private static string result;
    }
}