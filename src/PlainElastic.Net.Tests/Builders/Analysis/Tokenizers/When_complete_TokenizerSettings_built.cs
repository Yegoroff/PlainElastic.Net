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
											.Keyword(e => e.CustomPart("Keyword"))
											.Keyword("named_keyword")
											.NGram(e => e.CustomPart("NGram"))
											.NGram("named_nGram")
                                            .CustomPart("{ Custom }")
                                            .ToString();

		It should_contain_edgeNGram_part = () => result.ShouldContain("'edgeNGram': { 'type': 'edgeNGram',EdgeNGram }".AltQuote());

		It should_contain_named_edgeNGram_part = () => result.ShouldContain("'named_edgeNGram': { 'type': 'edgeNGram' }".AltQuote());

		It should_contain_keyword_part = () => result.ShouldContain("'keyword': { 'type': 'keyword',Keyword }".AltQuote());

		It should_contain_named_keyword_part = () => result.ShouldContain("'named_keyword': { 'type': 'keyword' }".AltQuote());

		It should_contain_nGram_part = () => result.ShouldContain("'nGram': { 'type': 'nGram',NGram }".AltQuote());

		It should_contain_named_nGram_part = () => result.ShouldContain("'named_nGram': { 'type': 'nGram' }".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'tokenizer': { " +
																	"'edgeNGram': { 'type': 'edgeNGram',EdgeNGram }," +
																	"'named_edgeNGram': { 'type': 'edgeNGram' }," +
																	"'keyword': { 'type': 'keyword',Keyword }," +
																	"'named_keyword': { 'type': 'keyword' }," +
																	"'nGram': { 'type': 'nGram',NGram }," +
																	"'named_nGram': { 'type': 'nGram' }," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}