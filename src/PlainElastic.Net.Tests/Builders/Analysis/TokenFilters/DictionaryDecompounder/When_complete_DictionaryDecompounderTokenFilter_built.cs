using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(DictionaryDecompounderTokenFilter))]
    class When_complete_DictionaryDecompounderTokenFilter_built
    {
        Because of = () => result = new DictionaryDecompounderTokenFilter()
                                            .Name("name")
                                            .Version("3.6")
                                            .WordList("2", "3")
                                            .WordListPath("4")
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'dictionary_decompounder'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.6'".AltQuote());

        It should_contain_word_list_part = () => result.ShouldContain("'word_list': [ '2','3' ]".AltQuote());

        It should_contain_word_list_path_part = () => result.ShouldContain("'word_list_path': '4'".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'dictionary_decompounder'," +
                                                                    "'version': '3.6'," +
                                                                    "'word_list': [ '2','3' ]," +
                                                                    "'word_list_path': '4'," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}