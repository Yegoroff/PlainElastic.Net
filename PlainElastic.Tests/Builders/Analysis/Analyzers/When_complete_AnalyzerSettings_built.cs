using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(AnalyzerSettings))]
    class When_complete_AnalyzerSettings_built
    {
        Because of = () => result = new AnalyzerSettings()
                                            .Standard(s => s.CustomPart("Standard"))
                                            .Standard("named_standard")
                                            .Simple(s => s.CustomPart("Simple"))
                                            .Simple("named_simple")
                                            .Whitespace(w => w.CustomPart("Whitespace"))
                                            .Whitespace("named_whitespace")
                                            .Stop(s => s.CustomPart("Stop"))
                                            .Stop("named_stop")
                                            .Keyword(k => k.CustomPart("Keyword"))
                                            .Keyword("named_keyword")
                                            .Pattern(p => p.CustomPart("Pattern"))
                                            .Pattern("named_pattern")
                                            .Language(l => l
                                                .Type(LanguageAnalyzerTypes.russian)
                                                .CustomPart("Language"))
                                            .Language("named_language", l => l
                                                .Type(LanguageAnalyzerTypes.french))
                                            .Snowball(s => s.CustomPart("Snowball"))
                                            .Snowball("named_snowball")
                                            .Custom("custom", c => c.CustomPart("Custom Analyzer"))
                                            .Standard(AnalyzersDefaultAliases.@default, d => d.CustomPart("Default"))
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_contain_standard_part = () => result.ShouldContain("'standard': { 'type': 'standard',Standard }".AltQuote());

        It should_contain_named_standard_part = () => result.ShouldContain("'named_standard': { 'type': 'standard' }".AltQuote());

        It should_contain_simple_part = () => result.ShouldContain("'simple': { 'type': 'simple',Simple }".AltQuote());

        It should_contain_named_simple_part = () => result.ShouldContain("'named_simple': { 'type': 'simple' }".AltQuote());

        It should_contain_whitespace_part = () => result.ShouldContain("'whitespace': { 'type': 'whitespace',Whitespace }".AltQuote());

        It should_contain_named_whitespace_part = () => result.ShouldContain("'named_whitespace': { 'type': 'whitespace' }".AltQuote());

        It should_contain_stop_part = () => result.ShouldContain("'stop': { 'type': 'stop',Stop }".AltQuote());

        It should_contain_named_stop_part = () => result.ShouldContain("'named_stop': { 'type': 'stop' }".AltQuote());

        It should_contain_keyword_part = () => result.ShouldContain("'keyword': { 'type': 'keyword',Keyword }".AltQuote());

        It should_contain_named_keyword_part = () => result.ShouldContain("'named_keyword': { 'type': 'keyword' }".AltQuote());

        It should_contain_pattern_part = () => result.ShouldContain("'pattern': { 'type': 'pattern',Pattern }".AltQuote());

        It should_contain_named_pattern_part = () => result.ShouldContain("'named_pattern': { 'type': 'pattern' }".AltQuote());

        It should_contain_language_part = () => result.ShouldContain("'russian': { 'type': 'russian',Language }".AltQuote());

        It should_contain_named_language_part = () => result.ShouldContain("'named_language': { 'type': 'french' }".AltQuote());

        It should_contain_snowball_part = () => result.ShouldContain("'snowball': { 'type': 'snowball',Snowball }".AltQuote());

        It should_contain_named_snowball_part = () => result.ShouldContain("'named_snowball': { 'type': 'snowball' }".AltQuote());

        It should_contain_custom_analyzer_part = () => result.ShouldContain("'custom': { 'type': 'custom',Custom Analyzer }".AltQuote());

        It should_contain_default_part = () => result.ShouldContain("'default': { 'type': 'standard',Default }".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'analyzer': { " +
                                                                    "'standard': { 'type': 'standard',Standard }," +
                                                                    "'named_standard': { 'type': 'standard' }," +
                                                                    "'simple': { 'type': 'simple',Simple }," +
                                                                    "'named_simple': { 'type': 'simple' }," +
                                                                    "'whitespace': { 'type': 'whitespace',Whitespace }," +
                                                                    "'named_whitespace': { 'type': 'whitespace' }," +
                                                                    "'stop': { 'type': 'stop',Stop }," +
                                                                    "'named_stop': { 'type': 'stop' }," +
                                                                    "'keyword': { 'type': 'keyword',Keyword }," +
                                                                    "'named_keyword': { 'type': 'keyword' }," +
                                                                    "'pattern': { 'type': 'pattern',Pattern }," +
                                                                    "'named_pattern': { 'type': 'pattern' }," +
                                                                    "'russian': { 'type': 'russian',Language }," +
                                                                    "'named_language': { 'type': 'french' }," +
                                                                    "'snowball': { 'type': 'snowball',Snowball }," +
                                                                    "'named_snowball': { 'type': 'snowball' }," +
                                                                    "'custom': { 'type': 'custom',Custom Analyzer }," +
                                                                    "'default': { 'type': 'standard',Default }," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}