using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(LengthTokenFilter))]
    class When_complete_LengthTokenFilter_built
    {
        Because of = () => result = new LengthTokenFilter()
                                            .Name("name")
                                            .Version("3.6")
                                            .Min(2)
                                            .Max(3)
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'length'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.6'".AltQuote());

        It should_contain_min_part = () => result.ShouldContain("'min': 2".AltQuote());

        It should_contain_max_part = () => result.ShouldContain("'max': 3".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'length'," +
                                                                    "'version': '3.6'," +
                                                                    "'min': 2," +
                                                                    "'max': 3," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}