using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(PatternAnalyzer))]
    class When_complete_PatternAnalyzer_built
    {
        Because of = () => result = new PatternAnalyzer()
                                            .Name("name")
                                            .Version("3.5")
                                            .Alias("second", "third")
                                            .Lowercase(false)
                                            .Pattern("pattern")
                                            .Flags(RegexFlags.CANON_EQ | RegexFlags.CASE_INSENSITIVE)
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'pattern'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.5'".AltQuote());

        It should_contain_alias_part = () => result.ShouldContain("'alias': [ 'second','third' ]".AltQuote());

        It should_contain_lowercase_part = () => result.ShouldContain("'lowercase': false".AltQuote());

        It should_contain_pattern_part = () => result.ShouldContain("'pattern': 'pattern'".AltQuote());

        It should_contain_flags_part = () => result.ShouldContain("'flags': 'CANON_EQ|CASE_INSENSITIVE'".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'pattern'," +
                                                                    "'version': '3.5'," +
                                                                    "'alias': [ 'second','third' ]," +
                                                                    "'lowercase': false," +
                                                                    "'pattern': 'pattern'," +
                                                                    "'flags': 'CANON_EQ|CASE_INSENSITIVE'," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}