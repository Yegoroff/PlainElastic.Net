using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(CharFilterSettings))]
    class When_complete_CharFilterSettings_built
    {
        Because of = () => result = new CharFilterSettings()
                                            .HtmlStrip(x => x.CustomPart("HtmlStrip"))
                                            .HtmlStrip("named_html_strip")
                                            .Mapping(x => x.CustomPart("Mapping"))
                                            .Mapping("named_mapping")
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_contain_html_strip_part = () => result.ShouldContain("'html_strip': { 'type': 'html_strip',HtmlStrip }".AltQuote());

        It should_contain_named_html_strip_part = () => result.ShouldContain("'named_html_strip': { 'type': 'html_strip' }".AltQuote());

        It should_contain_mapping_part = () => result.ShouldContain("'mapping': { 'type': 'mapping',Mapping }".AltQuote());

        It should_contain_named_mapping_part = () => result.ShouldContain("'named_mapping': { 'type': 'mapping' }".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'char_filter': { " +
                                                                    "'html_strip': { 'type': 'html_strip',HtmlStrip }," +
                                                                    "'named_html_strip': { 'type': 'html_strip' }," +
                                                                    "'mapping': { 'type': 'mapping',Mapping }," +
                                                                    "'named_mapping': { 'type': 'mapping' }," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}