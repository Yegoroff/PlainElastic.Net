using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(SynonymTokenFilter))]
    class When_complete_SynonymTokenFilter_built
    {
        Because of = () => result = new SynonymTokenFilter()
                                            .Name("name")
                                            .Version("3.6")
                                            .Synonyms("2", "3")
                                            .SynonymsPath("4")
                                            .Format(SynonymTokenFilterFormats.WordNet)
                                            .IgnoreCase(true)
                                            .Expand(false)
                                            .Tokenizer(DefaultTokenizers.standard)
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'synonym'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.6'".AltQuote());

        It should_contain_synonyms_part = () => result.ShouldContain("'synonyms': [ '2','3' ]".AltQuote());

        It should_contain_synonyms_path_part = () => result.ShouldContain("'synonyms_path': '4'".AltQuote());

        It should_contain_format_part = () => result.ShouldContain("'format': 'WordNet'".AltQuote());

        It should_contain_ignore_case_part = () => result.ShouldContain("'ignore_case': true".AltQuote());

        It should_contain_expand_part = () => result.ShouldContain("'expand': false".AltQuote());

        It should_contain_tokenizer_part = () => result.ShouldContain("'tokenizer': 'standard'".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'synonym'," +
                                                                    "'version': '3.6'," +
                                                                    "'synonyms': [ '2','3' ]," +
                                                                    "'synonyms_path': '4'," +
                                                                    "'format': 'WordNet'," +
                                                                    "'ignore_case': true," +
                                                                    "'expand': false," +
                                                                    "'tokenizer': 'standard'," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}