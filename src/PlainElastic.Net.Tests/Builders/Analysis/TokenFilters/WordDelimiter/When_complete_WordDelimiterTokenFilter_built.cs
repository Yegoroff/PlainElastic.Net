using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(WordDelimiterTokenFilter))]
    class When_complete_WordDelimiterTokenFilter_built
    {
        Because of = () => result = new WordDelimiterTokenFilter()
                                            .Name("name")
                                            .Version("3.6")
                                            .GenerateWordParts(false)
                                            .GenerateNumberParts(false)
                                            .CatenateWords(true)
                                            .CatenateNumbers(true)
                                            .CatenateAll(true)
                                            .SplitOnCaseChange(false)
                                            .PreserveOriginal(true)
                                            .SplitOnNumerics(false)
                                            .StemEnglishPossessive(false)
                                            .ProtectedWords("2", "3")
                                            .ProtectedWordsPath("4")
                                            .TypeTable("$=>DIGIT", "%=>DIGIT")
                                            .TypeTablePath("5")
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'word_delimiter'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.6'".AltQuote());

        It should_contain_generate_word_parts_part = () => result.ShouldContain("'generate_word_parts': false".AltQuote());

        It should_contain_generate_number_parts_part = () => result.ShouldContain("'generate_number_parts': false".AltQuote());

        It should_contain_catenate_words_part = () => result.ShouldContain("'catenate_words': true".AltQuote());

        It should_contain_catenate_numbers_part = () => result.ShouldContain("'catenate_numbers': true".AltQuote());

        It should_contain_catenate_all_part = () => result.ShouldContain("'catenate_all': true".AltQuote());

        It should_contain_split_on_case_change_part = () => result.ShouldContain("'split_on_case_change': false".AltQuote());

        It should_contain_preserve_original_part = () => result.ShouldContain("'preserve_original': true".AltQuote());

        It should_contain_split_on_numerics_part = () => result.ShouldContain("'split_on_numerics': false".AltQuote());

        It should_contain_stem_english_possessive_part = () => result.ShouldContain("'stem_english_possessive': false".AltQuote());

        It should_contain_protected_words_part = () => result.ShouldContain("'protected_words': [ '2','3' ]".AltQuote());

        It should_contain_protected_words_path_part = () => result.ShouldContain("'protected_words_path': '4'".AltQuote());

        It should_contain_type_table_part = () => result.ShouldContain("'type_table': [ '$=>DIGIT','%=>DIGIT' ]".AltQuote());

        It should_contain_type_table_path_part = () => result.ShouldContain("'type_table_path': '5'".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'word_delimiter'," +
                                                                    "'version': '3.6'," +
                                                                    "'generate_word_parts': false," +
                                                                    "'generate_number_parts': false," +
                                                                    "'catenate_words': true," +
                                                                    "'catenate_numbers': true," +
                                                                    "'catenate_all': true," +
                                                                    "'split_on_case_change': false," +
                                                                    "'preserve_original': true," +
                                                                    "'split_on_numerics': false," +
                                                                    "'stem_english_possessive': false," +
                                                                    "'protected_words': [ '2','3' ]," +
                                                                    "'protected_words_path': '4'," +
                                                                    "'type_table': [ '$=>DIGIT','%=>DIGIT' ]," +
                                                                    "'type_table_path': '5'," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}