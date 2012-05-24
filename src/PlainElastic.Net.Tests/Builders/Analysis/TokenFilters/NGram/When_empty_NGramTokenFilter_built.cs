using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(NGramTokenFilter))]
    class When_empty_NGramTokenFilter_built
    {
        Because of = () => result = new NGramTokenFilter()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'nGram' }".AltQuote());

        private static string result;
    }
}