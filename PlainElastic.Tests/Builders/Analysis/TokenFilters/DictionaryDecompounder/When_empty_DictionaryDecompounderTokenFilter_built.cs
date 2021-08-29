using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(DictionaryDecompounderTokenFilter))]
    class When_empty_DictionaryDecompounderTokenFilter_built
    {
        Because of = () => result = new DictionaryDecompounderTokenFilter()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'dictionary_decompounder' }".AltQuote());

        private static string result;
    }
}