using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(TokenFilterSettings))]
    class When_complete_TokenFilterSettings_built
    {
        Because of = () => result = new TokenFilterSettings()
                                            .Asciifolding(x => x.CustomPart("Asciifolding"))
                                            .Asciifolding("named_asciifolding")
                                            .EdgeNGram(x => x.CustomPart("EdgeNGram"))
                                            .EdgeNGram("named_edgeNGram")
                                            .Length(x => x.CustomPart("Length"))
                                            .Length("named_length")
                                            .Lowercase(x => x.CustomPart("Lowercase"))
                                            .Lowercase("named_lowercase")
                                            .NGram(x => x.CustomPart("NGram"))
                                            .NGram("named_nGram")
                                            .PorterStem(x => x.CustomPart("PorterStem"))
                                            .PorterStem("named_porterStem")
                                            .Shingle(x => x.CustomPart("Shingle"))
                                            .Shingle("named_shingle")
                                            .Standard(x => x.CustomPart("Standard"))
                                            .Standard("named_standard")
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_contain_asciifolding_part = () => result.ShouldContain("'asciifolding': { 'type': 'asciifolding',Asciifolding }".AltQuote());

        It should_contain_named_asciifolding_part = () => result.ShouldContain("'named_asciifolding': { 'type': 'asciifolding' }".AltQuote());

        It should_contain_edgeNGram_part = () => result.ShouldContain("'edgeNGram': { 'type': 'edgeNGram',EdgeNGram }".AltQuote());

        It should_contain_named_edgeNGram_part = () => result.ShouldContain("'named_edgeNGram': { 'type': 'edgeNGram' }".AltQuote());

        It should_contain_length_part = () => result.ShouldContain("'length': { 'type': 'length',Length }".AltQuote());

        It should_contain_named_length_part = () => result.ShouldContain("'named_length': { 'type': 'length' }".AltQuote());

        It should_contain_lowercase_part = () => result.ShouldContain("'lowercase': { 'type': 'lowercase',Lowercase }".AltQuote());

        It should_contain_named_lowercase_part = () => result.ShouldContain("'named_lowercase': { 'type': 'lowercase' }".AltQuote());

        It should_contain_nGram_part = () => result.ShouldContain("'nGram': { 'type': 'nGram',NGram }".AltQuote());

        It should_contain_named_nGram_part = () => result.ShouldContain("'named_nGram': { 'type': 'nGram' }".AltQuote());

        It should_contain_porterStem_part = () => result.ShouldContain("'porterStem': { 'type': 'porterStem',PorterStem }".AltQuote());

        It should_contain_named_porterStem_part = () => result.ShouldContain("'named_porterStem': { 'type': 'porterStem' }".AltQuote());

        It should_contain_shingle_part = () => result.ShouldContain("'shingle': { 'type': 'shingle',Shingle }".AltQuote());

        It should_contain_named_shingle_part = () => result.ShouldContain("'named_shingle': { 'type': 'shingle' }".AltQuote());

        It should_contain_standard_part = () => result.ShouldContain("'standard': { 'type': 'standard',Standard }".AltQuote());

        It should_contain_named_standard_part = () => result.ShouldContain("'named_standard': { 'type': 'standard' }".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'token_filter': { " +
                                                                    "'asciifolding': { 'type': 'asciifolding',Asciifolding }," +
                                                                    "'named_asciifolding': { 'type': 'asciifolding' }," +
                                                                    "'edgeNGram': { 'type': 'edgeNGram',EdgeNGram }," +
                                                                    "'named_edgeNGram': { 'type': 'edgeNGram' }," +
                                                                    "'length': { 'type': 'length',Length }," +
                                                                    "'named_length': { 'type': 'length' }," +
                                                                    "'lowercase': { 'type': 'lowercase',Lowercase }," +
                                                                    "'named_lowercase': { 'type': 'lowercase' }," +
                                                                    "'nGram': { 'type': 'nGram',NGram }," +
                                                                    "'named_nGram': { 'type': 'nGram' }," +
                                                                    "'porterStem': { 'type': 'porterStem',PorterStem }," +
                                                                    "'named_porterStem': { 'type': 'porterStem' }," +
                                                                    "'shingle': { 'type': 'shingle',Shingle }," +
                                                                    "'named_shingle': { 'type': 'shingle' }," +
                                                                    "'standard': { 'type': 'standard',Standard }," +
                                                                    "'named_standard': { 'type': 'standard' }," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}