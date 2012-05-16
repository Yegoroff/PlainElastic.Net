using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(EdgeNGramTokenizer))]
    class When_empty_EdgeNGramTokenizer_built
    {
        Because of = () => result = new EdgeNGramTokenizer()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'edgeNGram' }".AltQuote());

        private static string result;
    }
}