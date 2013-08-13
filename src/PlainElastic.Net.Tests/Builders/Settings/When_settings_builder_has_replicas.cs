using Machine.Specifications;

using PlainElastic.Net.Builders.IndexSettings.Settings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Settings
{
    public class When_settings_builder_has_replicas
    {
        private static string result;

        Because of = () => result = new Setting().NumberOfReplicas(3).ToString();

        It should_contain_the_number_of_replicas = () => result.ShouldContain("'number_of_replicas': 3".AltQuote());
    }
}