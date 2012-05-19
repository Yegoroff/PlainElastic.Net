using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(PhoneticTokenFilter))]
    class When_empty_PhoneticTokenFilter_built
    {
        Because of = () => result = new PhoneticTokenFilter()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'phonetic' }".AltQuote());

        private static string result;
    }
}