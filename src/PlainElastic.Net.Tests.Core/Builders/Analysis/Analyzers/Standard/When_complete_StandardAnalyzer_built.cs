using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(StandardAnalyzer))]
    class When_complete_StandardAnalyzer_built
    {
        Because of = () => result = new StandardAnalyzer()
                                            .Name("name")
                                            .Version("3.5")
                                            .Alias("second", "third")
                                            .Stopwords("stop", "word")
                                            .StopwordsPath("stopwords path")
                                            .MaxTokenLength(10)
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'standard'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.5'".AltQuote());

        It should_contain_alias_part = () => result.ShouldContain("'alias': [ 'second','third' ]".AltQuote());

        It should_contain_stopwords_part = () => result.ShouldContain("'stopwords': [ 'stop','word' ]".AltQuote());

        It should_contain_stopwords_path_part = () => result.ShouldContain("'stopwords_path': 'stopwords path'".AltQuote());

        It should_contain_max_token_length_part = () => result.ShouldContain("'max_token_length': 10".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'standard'," +
                                                                    "'version': '3.5'," +
                                                                    "'alias': [ 'second','third' ]," +
                                                                    "'stopwords': [ 'stop','word' ]," +
                                                                    "'stopwords_path': 'stopwords path'," +
                                                                    "'max_token_length': 10," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}