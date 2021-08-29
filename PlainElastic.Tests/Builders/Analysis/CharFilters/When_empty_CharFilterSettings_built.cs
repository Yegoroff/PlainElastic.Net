using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(CharFilterSettings))]
    class When_empty_CharFilterSettings_built
    {
        Because of = () => result = new CharFilterSettings()
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'char_filter': {  }".AltQuote());

        private static string result;
    }
}