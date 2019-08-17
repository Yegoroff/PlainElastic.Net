using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(HtmlStripCharFilter))]
    class When_empty_HtmlStripCharFilter_built
    {
        Because of = () => result = new HtmlStripCharFilter()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'html_strip' }".AltQuote());

        private static string result;
    }
}