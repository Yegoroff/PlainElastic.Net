using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(CustomAnalyzer))]
    class When_complete_CustomAnalyzer_built
    {
        Because of = () => result = new CustomAnalyzer()
                                            .Name("name")
                                            .Version("3.5")
                                            .Alias("second", "third")
                                            .Tokenizer(DefaultTokenizers.lowercase)
                                            .Tokenizer("custom_tokenizer")
                                            .Filter(DefaultTokenFilters.stop, DefaultTokenFilters.truncate)
                                            .Filter("custom_filter1", "custom_filter2")
                                            .CharFilter(DefaultCharFilters.html_strip, DefaultCharFilters.mapping)
                                            .CharFilter("custom_char_filter1", "custom_char_filter2")
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'custom'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.5'".AltQuote());

        It should_contain_alias_part = () => result.ShouldContain("'alias': [ 'second','third' ]".AltQuote());

        It should_contain_tokenizer_part = () => result.ShouldContain("'tokenizer': 'lowercase'".AltQuote());

        It should_contain_custom_tokenizer_part = () => result.ShouldContain("'tokenizer': 'custom_tokenizer'".AltQuote());

        It should_contain_filter_part = () => result.ShouldContain("'filter': [ 'stop','truncate' ]".AltQuote());

        It should_contain_custom_filter_part = () => result.ShouldContain("'filter': [ 'custom_filter1','custom_filter2' ]".AltQuote());

        It should_contain_char_filter_part = () => result.ShouldContain("'char_filter': [ 'html_strip','mapping' ]".AltQuote());

        It should_contain_custom_char_filter_part = () => result.ShouldContain("'char_filter': [ 'custom_char_filter1','custom_char_filter2' ]".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'custom'," +
                                                                    "'version': '3.5'," +
                                                                    "'alias': [ 'second','third' ]," +
                                                                    "'tokenizer': 'lowercase'," +
                                                                    "'tokenizer': 'custom_tokenizer'," +
                                                                    "'filter': [ 'stop','truncate' ]," +
                                                                    "'filter': [ 'custom_filter1','custom_filter2' ]," +
                                                                    "'char_filter': [ 'html_strip','mapping' ]," +
                                                                    "'char_filter': [ 'custom_char_filter1','custom_char_filter2' ]," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}