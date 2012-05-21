using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(TokenFilterSettings))]
    class When_empty_TokenFilterSettings_built
    {
        Because of = () => result = new TokenFilterSettings()
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'filter': {  }".AltQuote());

        private static string result;
    }
}