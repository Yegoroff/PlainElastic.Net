using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(UniqueTokenFilter))]
    class When_complete_UniqueTokenFilter_built
    {
        Because of = () => result = new UniqueTokenFilter()
                                            .Name("name")
                                            .Version("3.6")
                                            .OnlyOnSamePosition(true)
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'unique'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.6'".AltQuote());

        It should_contain_only_on_same_position_part = () => result.ShouldContain("'only_on_same_position': true".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'unique'," +
                                                                    "'version': '3.6'," +
                                                                    "'only_on_same_position': true," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}