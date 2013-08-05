using Machine.Specifications;

using PlainElastic.Net.Builders.IndexSettings.Settings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Settings
{
    [Subject(typeof(Setting))]
    public class When_settings_builder_is_empty
    {
        private static string result;

        Because of = () => result = new Setting().ToString();

        private It should_contain_no_settings_part = () => result.ShouldContain("".AltQuote());
    }
}