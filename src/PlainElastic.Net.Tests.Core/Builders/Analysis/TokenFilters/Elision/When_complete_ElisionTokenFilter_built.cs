using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(ElisionTokenFilter))]
    class When_complete_ElisionTokenFilter_built
    {
        Because of = () => result = new ElisionTokenFilter()
                                            .Name("name")
                                            .Version("3.6")
                                            .Articles("2", "3")
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'elision'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.6'".AltQuote());

        It should_contain_articles_part = () => result.ShouldContain("'articles': [ '2','3' ]".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'elision'," +
                                                                    "'version': '3.6'," +
                                                                    "'articles': [ '2','3' ]," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}