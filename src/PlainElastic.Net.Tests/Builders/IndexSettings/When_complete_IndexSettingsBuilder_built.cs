using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(IndexSettingsBuilder))]
    class When_complete_IndexSettingsBuilder_built
    {
        Because of = () => result = new IndexSettingsBuilder()
                                            .Analysis(a => a.CustomPart("Analysis"))
                                            .Settings(a => a.CustomPart("Settings"))
                                            .NumberOfReplicas(5)
                                            .NumberOfShards(3)
                                            .Build();

        It should_contain_analysis_part = () => 
            result.ShouldContain("'analysis': { Analysis }".AltQuote());

        It should_contain_shards_part = () =>
            result.ShouldContain("'number_of_shards': 3".AltQuote());

        It should_contain_replicas_part = () =>
            result.ShouldContain("'number_of_replicas': 5".AltQuote());

        It should_contain_settings_part = () => result.ShouldContain("Settings");

        private static string result;
    }
}