using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(PatternTokenizer))]
    class When_complete_PatternTokenizer_built
    {
        Because of = () => result = new PatternTokenizer()
                                            .Name("name")
                                            .Version("3.6")
                                            .Pattern("pattern")
                                            .Flags(RegexFlags.CANON_EQ | RegexFlags.CASE_INSENSITIVE)
                                            .Group(2)
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'pattern'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.6'".AltQuote());

        It should_contain_pattern_part = () => result.ShouldContain("'pattern': 'pattern'".AltQuote());

        It should_contain_flags_part = () => result.ShouldContain("'flags': 'CANON_EQ|CASE_INSENSITIVE'".AltQuote());

        It should_contain_group_part = () => result.ShouldContain("'group': 2".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'pattern'," +
                                                                    "'version': '3.6'," +
                                                                    "'pattern': 'pattern'," +
                                                                    "'flags': 'CANON_EQ|CASE_INSENSITIVE'," +
                                                                    "'group': 2," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}