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
											.NGram(n => n.CustomPart("NGram"))
											.NGram("named_nGram")
											.Standard(s => s.CustomPart("Standard"))
											.Standard("named_standard")
											.Pattern(p => p.CustomPart("Pattern"))
											.Pattern("named_pattern")
											.UaxUrlEmail(u => u.CustomPart("UaxUrlEmail"))
											.UaxUrlEmail("named_uax_url_email")
                                            .CustomPart("{ Custom }")
                                            .ToString();

		It should_contain_edgeNGram_part = () => result.ShouldContain("'edgeNGram': { 'type': 'edgeNGram',EdgeNGram }".AltQuote());

		It should_contain_named_edgeNGram_part = () => result.ShouldContain("'named_edgeNGram': { 'type': 'edgeNGram' }".AltQuote());

		It should_contain_keyword_part = () => result.ShouldContain("'keyword': { 'type': 'keyword',Keyword }".AltQuote());

		It should_contain_named_keyword_part = () => result.ShouldContain("'named_keyword': { 'type': 'keyword' }".AltQuote());

		It should_contain_nGram_part = () => result.ShouldContain("'nGram': { 'type': 'nGram',NGram }".AltQuote());

		It should_contain_named_nGram_part = () => result.ShouldContain("'named_nGram': { 'type': 'nGram' }".AltQuote());

		It should_contain_standard_part = () => result.ShouldContain("'standard': { 'type': 'standard',Standard }".AltQuote());

		It should_contain_named_standard_part = () => result.ShouldContain("'named_standard': { 'type': 'standard' }".AltQuote());

		It should_contain_pattern_part = () => result.ShouldContain("'pattern': { 'type': 'pattern',Pattern }".AltQuote());

		It should_contain_named_pattern_part = () => result.ShouldContain("'named_pattern': { 'type': 'pattern' }".AltQuote());

		It should_contain_uax_url_email_part = () => result.ShouldContain("'uax_url_email': { 'type': 'uax_url_email',UaxUrlEmail }".AltQuote());

		It should_contain_named_uax_url_email_part = () => result.ShouldContain("'named_uax_url_email': { 'type': 'uax_url_email' }".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'tokenizer': { " +
																	"'edgeNGram': { 'type': 'edgeNGram',EdgeNGram }," +
																	"'named_edgeNGram': { 'type': 'edgeNGram' }," +
																	"'keyword': { 'type': 'keyword',Keyword }," +
																	"'named_keyword': { 'type': 'keyword' }," +
																	"'nGram': { 'type': 'nGram',NGram }," +
																	"'named_nGram': { 'type': 'nGram' }," +
																	"'standard': { 'type': 'standard',Standard }," +
																	"'named_standard': { 'type': 'standard' }," +
																	"'pattern': { 'type': 'pattern',Pattern }," +
																	"'named_pattern': { 'type': 'pattern' }," +
																	"'uax_url_email': { 'type': 'uax_url_email',UaxUrlEmail }," +
																	"'named_uax_url_email': { 'type': 'uax_url_email' }," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}