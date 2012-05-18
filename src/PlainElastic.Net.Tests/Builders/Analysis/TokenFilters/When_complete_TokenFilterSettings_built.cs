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
                                            .Length(x => x.CustomPart("Length"))
                                            .Length("named_length")
                                            .Lowercase(x => x.CustomPart("Lowercase"))
                                            .Lowercase("named_lowercase")
                                            .NGram(x => x.CustomPart("NGram"))
                                            .NGram("named_nGram")
                                            .Standard(x => x.CustomPart("Standard"))
                                            .Standard("named_standard")
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_contain_asciifolding_part = () => result.ShouldContain("'asciifolding': { 'type': 'asciifolding',Asciifolding }".AltQuote());

        It should_contain_named_asciifolding_part = () => result.ShouldContain("'named_asciifolding': { 'type': 'asciifolding' }".AltQuote());

        It should_contain_length_part = () => result.ShouldContain("'length': { 'type': 'length',Length }".AltQuote());

        It should_contain_named_length_part = () => result.ShouldContain("'named_length': { 'type': 'length' }".AltQuote());

        It should_contain_lowercase_part = () => result.ShouldContain("'lowercase': { 'type': 'lowercase',Lowercase }".AltQuote());

        It should_contain_named_lowercase_part = () => result.ShouldContain("'named_lowercase': { 'type': 'lowercase' }".AltQuote());

        It should_contain_nGram_part = () => result.ShouldContain("'nGram': { 'type': 'nGram',NGram }".AltQuote());

        It should_contain_named_nGram_part = () => result.ShouldContain("'named_nGram': { 'type': 'nGram' }".AltQuote());

        It should_contain_standard_part = () => result.ShouldContain("'standard': { 'type': 'standard',Standard }".AltQuote());

        It should_contain_named_standard_part = () => result.ShouldContain("'named_standard': { 'type': 'standard' }".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'token_filter': { " +
                                                                    "'asciifolding': { 'type': 'asciifolding',Asciifolding }," +
                                                                    "'named_asciifolding': { 'type': 'asciifolding' }," +
                                                                    "'length': { 'type': 'length',Length }," +
                                                                    "'named_length': { 'type': 'length' }," +
                                                                    "'lowercase': { 'type': 'lowercase',Lowercase }," +
                                                                    "'named_lowercase': { 'type': 'lowercase' }," +
                                                                    "'nGram': { 'type': 'nGram',NGram }," +
                                                                    "'named_nGram': { 'type': 'nGram' }," +
                                                                    "'standard': { 'type': 'standard',Standard }," +
                                                                    "'named_standard': { 'type': 'standard' }," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}