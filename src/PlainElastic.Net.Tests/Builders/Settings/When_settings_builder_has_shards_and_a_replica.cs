using Machine.Specifications;

using PlainElastic.Net.Builders.IndexSettings.Settings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Settings
{
    public class When_settings_builder_has_shards_and_a_replica
    {
        private static string result;

        Because of = () => result = new Setting().NumberOfReplicas(3).NumberOfShards(2).ToString();

        It should_contain_the_number_of_replicas = () => result.ShouldContain("'number_of_replicas': 3,'number_of_shards': 2".AltQuote());
    }
}