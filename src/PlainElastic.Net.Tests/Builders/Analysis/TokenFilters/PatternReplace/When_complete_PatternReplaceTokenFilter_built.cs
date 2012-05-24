using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(PatternReplaceTokenFilter))]
    class When_complete_PatternReplaceTokenFilter_built
    {
        Because of = () => result = new PatternReplaceTokenFilter()
                                            .Name("name")
                                            .Version("3.6")
                                            .Pattern("2")
                                            .Replacement("3")
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'pattern_replace'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.6'".AltQuote());

        It should_contain_pattern_part = () => result.ShouldContain("'pattern': '2'".AltQuote());

        It should_contain_replacement_part = () => result.ShouldContain("'replacement': '3'".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'pattern_replace'," +
                                                                    "'version': '3.6'," +
                                                                    "'pattern': '2'," +
                                                                    "'replacement': '3'," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}