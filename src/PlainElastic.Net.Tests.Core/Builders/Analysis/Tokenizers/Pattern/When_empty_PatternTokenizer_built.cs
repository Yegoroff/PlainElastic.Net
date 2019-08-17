using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(PatternTokenizer))]
    class When_empty_PatternTokenizer_built
    {
        Because of = () => result = new PatternTokenizer()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'pattern' }".AltQuote());

        private static string result;
    }
}