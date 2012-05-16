using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(KeywordTokenizer))]
    class When_complete_KeywordTokenizer_built
    {
        Because of = () => result = new KeywordTokenizer()
                                            .Name("name")
                                            .Version("3.6")
                                            .BufferSize(100500)
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'keyword'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.6'".AltQuote());

        It should_contain_buffer_size_part = () => result.ShouldContain("'buffer_size': 100500".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'keyword'," +
                                                                    "'version': '3.6'," +
                                                                    "'buffer_size': 100500," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}