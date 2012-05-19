using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(StemmerTokenFilter))]
    class When_empty_StemmerTokenFilter_built
    {
        Because of = () => result = new StemmerTokenFilter()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'stemmer' }".AltQuote());

        private static string result;
    }
}