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
                                            .Kstem(x => x.CustomPart("Kstem"))
                                            .Kstem("named_kstem")
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
                                            .Snowball(x => x.CustomPart("Snowball"))
                                            .Snowball("named_snowball")
                                            .Standard(x => x.CustomPart("Standard"))
                                            .Standard("named_standard")
                                            .Stemmer(x => x.CustomPart("Stemmer"))
                                            .Stemmer("named_stemmer")
                                            .Stop(x => x.CustomPart("Stop"))
                                            .Stop("named_stop")
                                            .WordDelimiter(x => x.CustomPart("WordDelimiter"))
                                            .WordDelimiter("named_word_delimiter")
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_contain_asciifolding_part = () => result.ShouldContain("'asciifolding': { 'type': 'asciifolding',Asciifolding }".AltQuote());

        It should_contain_named_asciifolding_part = () => result.ShouldContain("'named_asciifolding': { 'type': 'asciifolding' }".AltQuote());

        It should_contain_edgeNGram_part = () => result.ShouldContain("'edgeNGram': { 'type': 'edgeNGram',EdgeNGram }".AltQuote());

        It should_contain_named_edgeNGram_part = () => result.ShouldContain("'named_edgeNGram': { 'type': 'edgeNGram' }".AltQuote());

        It should_contain_kstem_part = () => result.ShouldContain("'kstem': { 'type': 'kstem',Kstem }".AltQuote());

        It should_contain_named_kstem_part = () => result.ShouldContain("'named_kstem': { 'type': 'kstem' }".AltQuote());

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

        It should_contain_snowball_part = () => result.ShouldContain("'snowball': { 'type': 'snowball',Snowball }".AltQuote());

        It should_contain_named_snowball_part = () => result.ShouldContain("'named_snowball': { 'type': 'snowball' }".AltQuote());

        It should_contain_standard_part = () => result.ShouldContain("'standard': { 'type': 'standard',Standard }".AltQuote());

        It should_contain_named_standard_part = () => result.ShouldContain("'named_standard': { 'type': 'standard' }".AltQuote());

        It should_contain_stemmer_part = () => result.ShouldContain("'stemmer': { 'type': 'stemmer',Stemmer }".AltQuote());

        It should_contain_named_stemmer_part = () => result.ShouldContain("'named_stemmer': { 'type': 'stemmer' }".AltQuote());

        It should_contain_stop_part = () => result.ShouldContain("'stop': { 'type': 'stop',Stop }".AltQuote());

        It should_contain_named_stop_part = () => result.ShouldContain("'named_stop': { 'type': 'stop' }".AltQuote());

        It should_contain_word_delimiter_part = () => result.ShouldContain("'word_delimiter': { 'type': 'word_delimiter',WordDelimiter }".AltQuote());

        It should_contain_named_word_delimiter_part = () => result.ShouldContain("'named_word_delimiter': { 'type': 'word_delimiter' }".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'token_filter': { " +
                                                                    "'asciifolding': { 'type': 'asciifolding',Asciifolding }," +
                                                                    "'named_asciifolding': { 'type': 'asciifolding' }," +
                                                                    "'edgeNGram': { 'type': 'edgeNGram',EdgeNGram }," +
                                                                    "'named_edgeNGram': { 'type': 'edgeNGram' }," +
                                                                    "'kstem': { 'type': 'kstem',Kstem }," +
                                                                    "'named_kstem': { 'type': 'kstem' }," +
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
                                                                    "'snowball': { 'type': 'snowball',Snowball }," +
                                                                    "'named_snowball': { 'type': 'snowball' }," +
                                                                    "'standard': { 'type': 'standard',Standard }," +
                                                                    "'named_standard': { 'type': 'standard' }," +
                                                                    "'stemmer': { 'type': 'stemmer',Stemmer }," +
                                                                    "'named_stemmer': { 'type': 'stemmer' }," +
                                                                    "'stop': { 'type': 'stop',Stop }," +
                                                                    "'named_stop': { 'type': 'stop' }," +
                                                                    "'word_delimiter': { 'type': 'word_delimiter',WordDelimiter }," +
                                                                    "'named_word_delimiter': { 'type': 'word_delimiter' }," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}