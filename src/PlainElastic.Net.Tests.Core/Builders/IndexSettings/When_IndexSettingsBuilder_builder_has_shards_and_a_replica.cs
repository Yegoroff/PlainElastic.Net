using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(IndexSettingsBuilder))]
    public class When_IndexSettingsBuilder_builder_has_shards_and_a_replica
    {
        private static string result;

        Because of = () => 
            result = new IndexSettingsBuilder()
                        .NumberOfReplicas(3)
                        .NumberOfShards(2)
                        .Build();

        It should_contain_the_number_of_replicas = () => 
            result.ShouldContain("'number_of_replicas': 3,'number_of_shards': 2".AltQuote());
    }
}