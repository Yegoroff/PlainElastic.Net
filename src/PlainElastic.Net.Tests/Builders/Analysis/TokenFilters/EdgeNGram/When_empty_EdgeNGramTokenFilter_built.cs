using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(EdgeNGramTokenFilter))]
    class When_empty_EdgeNGramTokenFilter_built
    {
        Because of = () => result = new EdgeNGramTokenFilter()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'edgeNGram' }".AltQuote());

        private static string result;
    }
}