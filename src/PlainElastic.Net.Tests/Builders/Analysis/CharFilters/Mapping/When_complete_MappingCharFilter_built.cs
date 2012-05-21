using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(MappingCharFilter))]
    class When_complete_MappingCharFilter_built
    {
        Because of = () => result = new MappingCharFilter()
                                            .Name("name")
                                            .Version("3.6")
                                            .Mappings("ph=>f", "qu=>q")
                                            .MappingsPath("2")
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'mapping'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.6'".AltQuote());

        It should_contain_mappings_part = () => result.ShouldContain("'mappings': [ 'ph=>f','qu=>q' ]".AltQuote());

        It should_contain_mappings_path_part = () => result.ShouldContain("'mappings_path': '2'".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'mapping'," +
                                                                    "'version': '3.6'," +
                                                                    "'mappings': [ 'ph=>f','qu=>q' ]," +
                                                                    "'mappings_path': '2'," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}