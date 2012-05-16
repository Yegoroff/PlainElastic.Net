using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(TokenizerSettings))]
    class When_empty_TokenizerSettings_built
    {
        Because of = () => result = new TokenizerSettings()
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'tokenizer': {  }".AltQuote());

        private static string result;
    }
}