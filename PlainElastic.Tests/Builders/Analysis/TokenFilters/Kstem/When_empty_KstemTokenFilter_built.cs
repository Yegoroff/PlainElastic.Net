using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(KstemTokenFilter))]
    class When_empty_KstemTokenFilter_built
    {
        Because of = () => result = new KstemTokenFilter()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'kstem' }".AltQuote());

        private static string result;
    }
}