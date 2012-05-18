using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(TokenizerSettings))]
    class When_complete_TokenizerSettings_built
    {
        Because of = () => result = new TokenizerSettings()
                                            .EdgeNGram(e => e.CustomPart("EdgeNGram"))
                                            .EdgeNGram("named_edgeNGram")
                                            .Keyword(k => k.CustomPart("Keyword"))
                                            .Keyword("named_keyword")
                                            .Letter(l => l.CustomPart("Letter"))
                                            .Letter("named_letter")
                                            .Lowercase(l => l.CustomPart("Lowercase"))
                                            .Lowercase("named_lowercase")
                                            .NGram(n => n.CustomPart("NGram"))
                                            .NGram("named_nGram")
                                            .Standard(s => s.CustomPart("Standard"))
                                            .Standard("named_standard")
                                            .Whitespace(w => w.CustomPart("Whitespace"))
                                            .Whitespace("named_whitespace")
                                            .Pattern(p => p.CustomPart("Pattern"))
                                            .Pattern("named_pattern")
                                            .UaxUrlEmail(u => u.CustomPart("UaxUrlEmail"))
                                            .UaxUrlEmail("named_uax_url_email")
                                            .PathHierarchy(p => p.CustomPart("PathHierarchy"))
                                            .PathHierarchy("named_path_hierarchy")
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_contain_edgeNGram_part = () => result.ShouldContain("'edgeNGram': { 'type': 'edgeNGram',EdgeNGram }".AltQuote());

        It should_contain_named_edgeNGram_part = () => result.ShouldContain("'named_edgeNGram': { 'type': 'edgeNGram' }".AltQuote());

        It should_contain_keyword_part = () => result.ShouldContain("'keyword': { 'type': 'keyword',Keyword }".AltQuote());

        It should_contain_named_keyword_part = () => result.ShouldContain("'named_keyword': { 'type': 'keyword' }".AltQuote());

        It should_contain_letter_part = () => result.ShouldContain("'letter': { 'type': 'letter',Letter }".AltQuote());

        It should_contain_named_letter_part = () => result.ShouldContain("'named_letter': { 'type': 'letter' }".AltQuote());

        It should_contain_lowercase_part = () => result.ShouldContain("'lowercase': { 'type': 'lowercase',Lowercase }".AltQuote());

        It should_contain_named_lowercase_part = () => result.ShouldContain("'named_lowercase': { 'type': 'lowercase' }".AltQuote());

        It should_contain_nGram_part = () => result.ShouldContain("'nGram': { 'type': 'nGram',NGram }".AltQuote());

        It should_contain_named_nGram_part = () => result.ShouldContain("'named_nGram': { 'type': 'nGram' }".AltQuote());

        It should_contain_standard_part = () => result.ShouldContain("'standard': { 'type': 'standard',Standard }".AltQuote());

        It should_contain_named_standard_part = () => result.ShouldContain("'named_standard': { 'type': 'standard' }".AltQuote());

        It should_contain_whitespace_part = () => result.ShouldContain("'whitespace': { 'type': 'whitespace',Whitespace }".AltQuote());

        It should_contain_named_whitespace_part = () => result.ShouldContain("'named_whitespace': { 'type': 'whitespace' }".AltQuote());

        It should_contain_pattern_part = () => result.ShouldContain("'pattern': { 'type': 'pattern',Pattern }".AltQuote());

        It should_contain_named_pattern_part = () => result.ShouldContain("'named_pattern': { 'type': 'pattern' }".AltQuote());

        It should_contain_uax_url_email_part = () => result.ShouldContain("'uax_url_email': { 'type': 'uax_url_email',UaxUrlEmail }".AltQuote());

        It should_contain_named_uax_url_email_part = () => result.ShouldContain("'named_uax_url_email': { 'type': 'uax_url_email' }".AltQuote());

        It should_contain_path_hierarchy_part = () => result.ShouldContain("'path_hierarchy': { 'type': 'path_hierarchy',PathHierarchy }".AltQuote());

        It should_contain_named_path_hierarchy_part = () => result.ShouldContain("'named_path_hierarchy': { 'type': 'path_hierarchy' }".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'tokenizer': { " +
                                                                    "'edgeNGram': { 'type': 'edgeNGram',EdgeNGram }," +
                                                                    "'named_edgeNGram': { 'type': 'edgeNGram' }," +
                                                                    "'keyword': { 'type': 'keyword',Keyword }," +
                                                                    "'named_keyword': { 'type': 'keyword' }," +
                                                                    "'letter': { 'type': 'letter',Letter }," +
                                                                    "'named_letter': { 'type': 'letter' }," +
                                                                    "'lowercase': { 'type': 'lowercase',Lowercase }," +
                                                                    "'named_lowercase': { 'type': 'lowercase' }," +
                                                                    "'nGram': { 'type': 'nGram',NGram }," +
                                                                    "'named_nGram': { 'type': 'nGram' }," +
                                                                    "'standard': { 'type': 'standard',Standard }," +
                                                                    "'named_standard': { 'type': 'standard' }," +
                                                                    "'whitespace': { 'type': 'whitespace',Whitespace }," +
                                                                    "'named_whitespace': { 'type': 'whitespace' }," +
                                                                    "'pattern': { 'type': 'pattern',Pattern }," +
                                                                    "'named_pattern': { 'type': 'pattern' }," +
                                                                    "'uax_url_email': { 'type': 'uax_url_email',UaxUrlEmail }," +
                                                                    "'named_uax_url_email': { 'type': 'uax_url_email' }," +
                                                                    "'path_hierarchy': { 'type': 'path_hierarchy',PathHierarchy }," +
                                                                    "'named_path_hierarchy': { 'type': 'path_hierarchy' }," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}