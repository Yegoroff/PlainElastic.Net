using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(HyphenationDecompounderTokenFilter))]
    class When_empty_HyphenationDecompounderTokenFilter_built
    {
        Because of = () => result = new HyphenationDecompounderTokenFilter()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'hyphenation_decompounder' }".AltQuote());

        private static string result;
    }
}