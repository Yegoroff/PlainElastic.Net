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
                                            .Build();

        It should_contain_analysis_part = () => result.ShouldContain("'analysis': { Analysis }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("{ 'index': { " +
                                                                    "'analysis': { Analysis } } }").AltQuote());

        private static string result;
    }
}