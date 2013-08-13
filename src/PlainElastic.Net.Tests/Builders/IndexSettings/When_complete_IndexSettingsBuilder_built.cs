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
                                            .NumberOfReplicas(5)
                                            .NumberOfShards(3)
                                            .Build();

        It should_contain_analysis_part = () => 
            result.ShouldContain("'analysis': { Analysis }".AltQuote());

        It should_contain_shards_part = () =>
            result.ShouldContain("'number_of_shards': 3".AltQuote());

        It should_contain_replicas_part = () =>
            result.ShouldContain("'number_of_replicas': 5".AltQuote());

        It should_return_correct_result = () =>
            result.ShouldEqual(
            ("{ " +
               "'index': { " +
                    "'analysis': { Analysis }," +
                    "'number_of_replicas': 5," +
                    "'number_of_shards': 3 " +
               "} " +
             "}"
            ).AltQuote());

        private static string result;
    }
}