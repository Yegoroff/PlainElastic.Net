using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(SnowballAnalyzer))]
    class When_complete_SnowballAnalyzer_built
    {
        Because of = () => result = new SnowballAnalyzer()
                                            .Name("name")
                                            .Version("3.5")
                                            .Alias("second", "third")
                                            .Language(SnowballLanguages.Russian)
                                            .Stopwords("stop", "word")
                                            .StopwordsPath("stopwords path")
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'snowball'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.5'".AltQuote());

        It should_contain_alias_part = () => result.ShouldContain("'alias': [ 'second','third' ]".AltQuote());

        It should_contain_language_part = () => result.ShouldContain("'language': 'Russian'".AltQuote());

        It should_contain_stopwords_part = () => result.ShouldContain("'stopwords': [ 'stop','word' ]".AltQuote());

        It should_contain_stopwords_path_part = () => result.ShouldContain("'stopwords_path': 'stopwords path'".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'snowball'," +
                                                                    "'version': '3.5'," +
                                                                    "'alias': [ 'second','third' ]," +
                                                                    "'language': 'Russian'," +
                                                                    "'stopwords': [ 'stop','word' ]," +
                                                                    "'stopwords_path': 'stopwords path'," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}