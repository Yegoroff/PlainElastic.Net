using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(StemmerTokenFilter))]
    class When_complete_StemmerTokenFilter_built
    {
        Because of = () => result = new StemmerTokenFilter()
                                            .Name("name")
                                            .Version("3.6")
                                            .Language(StemmerTokenFilterLanguages.light_russian)
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'stemmer'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.6'".AltQuote());

        It should_contain_language_part = () => result.ShouldContain("'language': 'light_russian'".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'stemmer'," +
                                                                    "'version': '3.6'," +
                                                                    "'language': 'light_russian'," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}