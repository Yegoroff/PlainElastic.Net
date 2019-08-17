using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(UaxUrlEmailTokenizer))]
    class When_empty_UaxUrlEmailTokenizer_built
    {
        Because of = () => result = new UaxUrlEmailTokenizer()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'uax_url_email' }".AltQuote());

        private static string result;
    }
}