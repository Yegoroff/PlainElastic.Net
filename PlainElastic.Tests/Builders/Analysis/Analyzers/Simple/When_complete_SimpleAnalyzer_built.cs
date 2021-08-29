using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(SimpleAnalyzer))]
    class When_complete_SimpleAnalyzer_built
    {
        Because of = () => result = new SimpleAnalyzer()
                                            .Name("name")
                                            .Version("3.5")
                                            .Alias("second", "third")
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'simple'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.5'".AltQuote());

        It should_contain_alias_part = () => result.ShouldContain("'alias': [ 'second','third' ]".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'simple'," +
                                                                    "'version': '3.5'," +
                                                                    "'alias': [ 'second','third' ]," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}