using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(Analyzer))]
    class When_complete_Analyzer_built
    {
        Because of = () => result = new Analyzer()
                                            .Standard(s => s.Custom("Standard"))
                                            .Standard("named_standard")
                                            .Simple(s => s.Custom("Simple"))
                                            .Simple("named_simple")
                                            .Standard(AnalyzersDefaultAliases.@default, s => s.Custom("Default"))
                                            .Custom("{ Custom }")
                                            .ToString();

        It should_contain_standard_part = () => result.ShouldContain("'standard': { 'type': 'standard',Standard }".AltQuote());

        It should_contain_named_standard_part = () => result.ShouldContain("'named_standard': { 'type': 'standard' }".AltQuote());

        It should_contain_simple_part = () => result.ShouldContain("'simple': { 'type': 'simple',Simple }".AltQuote());

        It should_contain_named_simple_part = () => result.ShouldContain("'named_simple': { 'type': 'simple' }".AltQuote());

        It should_contain_default_part = () => result.ShouldContain("'default': { 'type': 'standard',Default }".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'analyzer': { " +
                                                                    "'standard': { 'type': 'standard',Standard }," +
                                                                    "'named_standard': { 'type': 'standard' }," +
                                                                    "'simple': { 'type': 'simple',Simple }," +
                                                                    "'named_simple': { 'type': 'simple' }," +
                                                                    "'default': { 'type': 'standard',Default }," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}