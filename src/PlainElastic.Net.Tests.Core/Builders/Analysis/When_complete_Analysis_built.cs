using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(Analysis))]
    class When_complete_Analysis_built
    {
        Because of = () => result = new Analysis()
                                            .Analyzer(a => a.CustomPart("Analyzers"))
                                            .Tokenizer(t => t.CustomPart("Tokenizers"))
                                            .Filter(t => t.CustomPart("TokenFilters"))
                                            .CharFilter(c => c.CustomPart("CharFilters"))
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_contain_analyzer_part = () => result.ShouldContain("'analyzer': { Analyzers }".AltQuote());

        It should_contain_tokenizer_part = () => result.ShouldContain("'tokenizer': { Tokenizers }".AltQuote());

        It should_contain_filter_part = () => result.ShouldContain("'filter': { TokenFilters }".AltQuote());

        It should_contain_char_filter_part = () => result.ShouldContain("'char_filter': { CharFilters }".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'analysis': { " +
                                                                    "'analyzer': { Analyzers }," +
                                                                    "'tokenizer': { Tokenizers }," +
                                                                    "'filter': { TokenFilters }," +
                                                                    "'char_filter': { CharFilters }," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}