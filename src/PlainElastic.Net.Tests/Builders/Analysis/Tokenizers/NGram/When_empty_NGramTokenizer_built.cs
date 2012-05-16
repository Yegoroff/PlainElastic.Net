using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(NGramTokenizer))]
    class When_empty_NGramTokenizer_built
    {
        Because of = () => result = new NGramTokenizer()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'nGram' }".AltQuote());

        private static string result;
    }
}