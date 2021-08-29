using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(PatternReplaceTokenFilter))]
    class When_empty_PatternReplaceTokenFilter_built
    {
        Because of = () => result = new PatternReplaceTokenFilter()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'pattern_replace' }".AltQuote());

        private static string result;
    }
}