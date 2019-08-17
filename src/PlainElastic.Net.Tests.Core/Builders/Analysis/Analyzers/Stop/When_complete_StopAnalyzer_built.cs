using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(StopAnalyzer))]
    class When_complete_StopAnalyzer_built
    {
        Because of = () => result = new StopAnalyzer()
                                            .Name("name")
                                            .Version("3.5")
                                            .Alias("second", "third")
                                            .Stopwords("stop", "word")
                                            .StopwordsPath("stopwords path")
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'stop'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.5'".AltQuote());

        It should_contain_alias_part = () => result.ShouldContain("'alias': [ 'second','third' ]".AltQuote());

        It should_contain_stopwords_part = () => result.ShouldContain("'stopwords': [ 'stop','word' ]".AltQuote());

        It should_contain_stopwords_path_part = () => result.ShouldContain("'stopwords_path': 'stopwords path'".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'stop'," +
                                                                    "'version': '3.5'," +
                                                                    "'alias': [ 'second','third' ]," +
                                                                    "'stopwords': [ 'stop','word' ]," +
                                                                    "'stopwords_path': 'stopwords path'," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}