using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(PorterStemTokenFilter))]
    class When_empty_PorterStemTokenFilter_built
    {
        Because of = () => result = new PorterStemTokenFilter()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'porterStem' }".AltQuote());

        private static string result;
    }
}