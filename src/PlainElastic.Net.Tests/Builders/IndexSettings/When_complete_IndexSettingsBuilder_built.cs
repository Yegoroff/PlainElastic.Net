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
                                            .Build();

        It should_contain_analysis_part = () => result.ShouldContain("'analysis': { Analysis }".AltQuote());

        It should_contain_settings_part = () => result.ShouldContain("Settings");

        It should_return_correct_result = () => result.ShouldEqual(("{ 'settings': { 'index': { 'analysis': { Analysis },Settings } } }").AltQuote());

        private static string result;
    }
}