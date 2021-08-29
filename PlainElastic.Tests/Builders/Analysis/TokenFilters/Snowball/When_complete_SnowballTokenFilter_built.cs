using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(SnowballTokenFilter))]
    class When_complete_SnowballTokenFilter_built
    {
        Because of = () => result = new SnowballTokenFilter()
                                            .Name("name")
                                            .Version("3.6")
                                            .Language(SnowballLanguages.Russian)
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'snowball'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.6'".AltQuote());

        It should_contain_language_part = () => result.ShouldContain("'language': 'Russian'".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'snowball'," +
                                                                    "'version': '3.6'," +
                                                                    "'language': 'Russian'," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}