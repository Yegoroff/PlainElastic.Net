using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(LowercaseTokenizer))]
    class When_empty_LowercaseTokenizer_built
    {
        Because of = () => result = new LowercaseTokenizer()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'lowercase' }".AltQuote());

        private static string result;
    }
}