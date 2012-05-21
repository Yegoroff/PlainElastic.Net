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
                                            .DictionaryDecompounder(x => x.CustomPart("DictionaryDecompounder"))
                                            .DictionaryDecompounder("named_dictionary_decompounder")
                                            .EdgeNGram(x => x.CustomPart("EdgeNGram"))
                                            .EdgeNGram("named_edgeNGram")
                                            .Elision(x => x.CustomPart("Elision"))
                                            .Elision("named_elision")
                                            .HyphenationDecompounder(x => x.CustomPart("HyphenationDecompounder"))
                                            .HyphenationDecompounder("named_hyphenation_decompounder")
                                            .Kstem(x => x.CustomPart("Kstem"))
                                            .Kstem("named_kstem")
                                            .Length(x => x.CustomPart("Length"))
                                            .Length("named_length")
                                            .Lowercase(x => x.CustomPart("Lowercase"))
                                            .Lowercase("named_lowercase")
                                            .NGram(x => x.CustomPart("NGram"))
                                            .NGram("named_nGram")
                                            .PatternReplace(x => x.CustomPart("PatternReplace"))
                                            .PatternReplace("named_pattern_replace")
                                            .Phonetic(x => x.CustomPart("Phonetic"))
                                            .Phonetic("named_phonetic")
                                            .PorterStem(x => x.CustomPart("PorterStem"))
                                            .PorterStem("named_porterStem")
                                            .Reverse(x => x.CustomPart("Reverse"))
                                            .Reverse("named_reverse")
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
                                            .Synonym(x => x.CustomPart("Synonym"))
                                            .Synonym("named_synonym")
                                            .Trim(x => x.CustomPart("Trim"))
                                            .Trim("named_trim")
                                            .Truncate(x => x.CustomPart("Truncate"))
                                            .Truncate("named_truncate")
                                            .Unique(x => x.CustomPart("Unique"))
                                            .Unique("named_unique")
                                            .WordDelimiter(x => x.CustomPart("WordDelimiter"))
                                            .WordDelimiter("named_word_delimiter")
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_contain_asciifolding_part = () => result.ShouldContain("'asciifolding': { 'type': 'asciifolding',Asciifolding }".AltQuote());

        It should_contain_named_asciifolding_part = () => result.ShouldContain("'named_asciifolding': { 'type': 'asciifolding' }".AltQuote());

        It should_contain_dictionary_decompounder_part = () => result.ShouldContain("'dictionary_decompounder': { 'type': 'dictionary_decompounder',DictionaryDecompounder }".AltQuote());

        It should_contain_named_dictionary_decompounder_part = () => result.ShouldContain("'named_dictionary_decompounder': { 'type': 'dictionary_decompounder' }".AltQuote());

        It should_contain_edgeNGram_part = () => result.ShouldContain("'edgeNGram': { 'type': 'edgeNGram',EdgeNGram }".AltQuote());

        It should_contain_named_edgeNGram_part = () => result.ShouldContain("'named_edgeNGram': { 'type': 'edgeNGram' }".AltQuote());

        It should_contain_elision_part = () => result.ShouldContain("'elision': { 'type': 'elision',Elision }".AltQuote());

        It should_contain_named_elision_part = () => result.ShouldContain("'named_elision': { 'type': 'elision' }".AltQuote());

        It should_contain_hyphenation_decompounder_part = () => result.ShouldContain("'hyphenation_decompounder': { 'type': 'hyphenation_decompounder',HyphenationDecompounder }".AltQuote());

        It should_contain_named_hyphenation_decompounder_part = () => result.ShouldContain("'named_hyphenation_decompounder': { 'type': 'hyphenation_decompounder' }".AltQuote());

        It should_contain_kstem_part = () => result.ShouldContain("'kstem': { 'type': 'kstem',Kstem }".AltQuote());

        It should_contain_named_kstem_part = () => result.ShouldContain("'named_kstem': { 'type': 'kstem' }".AltQuote());

        It should_contain_length_part = () => result.ShouldContain("'length': { 'type': 'length',Length }".AltQuote());

        It should_contain_named_length_part = () => result.ShouldContain("'named_length': { 'type': 'length' }".AltQuote());

        It should_contain_lowercase_part = () => result.ShouldContain("'lowercase': { 'type': 'lowercase',Lowercase }".AltQuote());

        It should_contain_named_lowercase_part = () => result.ShouldContain("'named_lowercase': { 'type': 'lowercase' }".AltQuote());

        It should_contain_nGram_part = () => result.ShouldContain("'nGram': { 'type': 'nGram',NGram }".AltQuote());

        It should_contain_named_nGram_part = () => result.ShouldContain("'named_nGram': { 'type': 'nGram' }".AltQuote());

        It should_contain_pattern_replace_part = () => result.ShouldContain("'pattern_replace': { 'type': 'pattern_replace',PatternReplace }".AltQuote());

        It should_contain_named_pattern_replace_part = () => result.ShouldContain("'named_pattern_replace': { 'type': 'pattern_replace' }".AltQuote());

        It should_contain_phonetic_part = () => result.ShouldContain("'phonetic': { 'type': 'phonetic',Phonetic }".AltQuote());

        It should_contain_named_phonetic_part = () => result.ShouldContain("'named_phonetic': { 'type': 'phonetic' }".AltQuote());

        It should_contain_porterStem_part = () => result.ShouldContain("'porterStem': { 'type': 'porterStem',PorterStem }".AltQuote());

        It should_contain_named_porterStem_part = () => result.ShouldContain("'named_porterStem': { 'type': 'porterStem' }".AltQuote());

        It should_contain_reverse_part = () => result.ShouldContain("'reverse': { 'type': 'reverse',Reverse }".AltQuote());

        It should_contain_named_reverse_part = () => result.ShouldContain("'named_reverse': { 'type': 'reverse' }".AltQuote());

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

        It should_contain_synonym_part = () => result.ShouldContain("'synonym': { 'type': 'synonym',Synonym }".AltQuote());

        It should_contain_named_synonym_part = () => result.ShouldContain("'named_synonym': { 'type': 'synonym' }".AltQuote());

        It should_contain_trim_part = () => result.ShouldContain("'trim': { 'type': 'trim',Trim }".AltQuote());

        It should_contain_named_trim_part = () => result.ShouldContain("'named_trim': { 'type': 'trim' }".AltQuote());

        It should_contain_truncate_part = () => result.ShouldContain("'truncate': { 'type': 'truncate',Truncate }".AltQuote());

        It should_contain_named_truncate_part = () => result.ShouldContain("'named_truncate': { 'type': 'truncate' }".AltQuote());

        It should_contain_unique_part = () => result.ShouldContain("'unique': { 'type': 'unique',Unique }".AltQuote());

        It should_contain_named_unique_part = () => result.ShouldContain("'named_unique': { 'type': 'unique' }".AltQuote());

        It should_contain_word_delimiter_part = () => result.ShouldContain("'word_delimiter': { 'type': 'word_delimiter',WordDelimiter }".AltQuote());

        It should_contain_named_word_delimiter_part = () => result.ShouldContain("'named_word_delimiter': { 'type': 'word_delimiter' }".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());

        It should_return_correct_result = () => result.ShouldEqual(("'filter': { " +
                                                                    "'asciifolding': { 'type': 'asciifolding',Asciifolding }," +
                                                                    "'named_asciifolding': { 'type': 'asciifolding' }," +
                                                                    "'dictionary_decompounder': { 'type': 'dictionary_decompounder',DictionaryDecompounder }," +
                                                                    "'named_dictionary_decompounder': { 'type': 'dictionary_decompounder' }," +
                                                                    "'edgeNGram': { 'type': 'edgeNGram',EdgeNGram }," +
                                                                    "'named_edgeNGram': { 'type': 'edgeNGram' }," +
                                                                    "'elision': { 'type': 'elision',Elision }," +
                                                                    "'named_elision': { 'type': 'elision' }," +
                                                                    "'hyphenation_decompounder': { 'type': 'hyphenation_decompounder',HyphenationDecompounder }," +
                                                                    "'named_hyphenation_decompounder': { 'type': 'hyphenation_decompounder' }," +
                                                                    "'kstem': { 'type': 'kstem',Kstem }," +
                                                                    "'named_kstem': { 'type': 'kstem' }," +
                                                                    "'length': { 'type': 'length',Length }," +
                                                                    "'named_length': { 'type': 'length' }," +
                                                                    "'lowercase': { 'type': 'lowercase',Lowercase }," +
                                                                    "'named_lowercase': { 'type': 'lowercase' }," +
                                                                    "'nGram': { 'type': 'nGram',NGram }," +
                                                                    "'named_nGram': { 'type': 'nGram' }," +
                                                                    "'pattern_replace': { 'type': 'pattern_replace',PatternReplace }," +
                                                                    "'named_pattern_replace': { 'type': 'pattern_replace' }," +
                                                                    "'phonetic': { 'type': 'phonetic',Phonetic }," +
                                                                    "'named_phonetic': { 'type': 'phonetic' }," +
                                                                    "'porterStem': { 'type': 'porterStem',PorterStem }," +
                                                                    "'named_porterStem': { 'type': 'porterStem' }," +
                                                                    "'reverse': { 'type': 'reverse',Reverse }," +
                                                                    "'named_reverse': { 'type': 'reverse' }," +
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
                                                                    "'synonym': { 'type': 'synonym',Synonym }," +
                                                                    "'named_synonym': { 'type': 'synonym' }," +
                                                                    "'trim': { 'type': 'trim',Trim }," +
                                                                    "'named_trim': { 'type': 'trim' }," +
                                                                    "'truncate': { 'type': 'truncate',Truncate }," +
                                                                    "'named_truncate': { 'type': 'truncate' }," +
                                                                    "'unique': { 'type': 'unique',Unique }," +
                                                                    "'named_unique': { 'type': 'unique' }," +
                                                                    "'word_delimiter': { 'type': 'word_delimiter',WordDelimiter }," +
                                                                    "'named_word_delimiter': { 'type': 'word_delimiter' }," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}