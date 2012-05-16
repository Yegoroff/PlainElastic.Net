using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(PathHierarchyTokenizer))]
    class When_complete_PathHierarchyTokenizer_built
    {
        Because of = () => result = new PathHierarchyTokenizer()
                                            .Name("name")
                                            .Version("3.6")
                                            .Delimiter('x')
                                            .Replacement('y')
                                            .BufferSize(100500)
                                            .Reverse(true)
                                            .Skip(10)
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'path_hierarchy'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.6'".AltQuote());

        It should_contain_delimiter_part = () => result.ShouldContain("'delimiter': 'x'".AltQuote());

        It should_contain_replacement_part = () => result.ShouldContain("'replacement': 'y'".AltQuote());

        It should_contain_buffer_size_part = () => result.ShouldContain("'buffer_size': 100500".AltQuote());

        It should_contain_reverse_part = () => result.ShouldContain("'reverse': true".AltQuote());

        It should_contain_skip_part = () => result.ShouldContain("'skip': 10".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'path_hierarchy'," +
                                                                    "'version': '3.6'," +
                                                                    "'delimiter': 'x'," +
                                                                    "'replacement': 'y'," +
                                                                    "'buffer_size': 100500," +
                                                                    "'reverse': true," +
                                                                    "'skip': 10," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}