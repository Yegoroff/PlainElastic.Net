using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(StopTokenFilter))]
    class When_complete_StopTokenFilter_built
    {
        Because of = () => result = new StopTokenFilter()
                                            .Name("name")
                                            .Version("3.6")
                                            .Stopwords("2", "3")
                                            .StopwordsPath("4")
                                            .EnablePositionIncrements(false)
                                            .IgnoreCase(true)
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'stop'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.6'".AltQuote());

        It should_contain_stopwords_part = () => result.ShouldContain("'stopwords': [ '2','3' ]".AltQuote());

        It should_contain_stopwords_path_part = () => result.ShouldContain("'stopwords_path': '4'".AltQuote());

        It should_contain_enable_position_increments_part = () => result.ShouldContain("'enable_position_increments': false".AltQuote());

        It should_contain_ignore_case_part = () => result.ShouldContain("'ignore_case': true".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'stop'," +
                                                                    "'version': '3.6'," +
                                                                    "'stopwords': [ '2','3' ]," +
                                                                    "'stopwords_path': '4'," +
                                                                    "'enable_position_increments': false," +
                                                                    "'ignore_case': true," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}