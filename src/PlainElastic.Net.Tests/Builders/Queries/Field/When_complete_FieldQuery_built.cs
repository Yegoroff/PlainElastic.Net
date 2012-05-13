using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(FieldQuery<>))]
    class When_complete_FieldQuery_built
    {
        Because of = () => result = new FieldQuery<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Boost(5)
                                                .Rewrite(Rewrite.top_terms_boost_n, 100)
                                                .Query("query text")
                                                .DefaultOperator(Operator.AND)
                                                .Analyzer(DefaultAnalyzers.snowball)
                                                .AllowLeadingWildcard(true)
                                                .LowercaseExpandedTerms(false)
                                                .EnablePositionIncrements(true)
                                                .FuzzyPrefixLength(10)
                                                .FuzzyMinSim(0.7)
                                                .PhraseSlop(5)
                                                .AnalyzeWildcard(false)
                                                .AutoGeneratePhraseQueries(true)
                                                .MinimumShouldMatch("50%")
                                                .Custom("custom part")
                                                .ToString();


        It should_starts_with_field_declaration = () => result.ShouldStartWith("{ 'field': {".AltQuote());

        It should_contain_field_name_part = () => result.ShouldContain("'StringProperty': {".AltQuote());

        It should_contain_boost_part = () => result.ShouldContain("'boost': 5".AltQuote());

        It should_contain_rewrite_part = () => result.ShouldContain("'rewrite': 'top_terms_boost_100'".AltQuote());

        It should_contain_query_part = () => result.ShouldContain("'query': 'query text'".AltQuote());

        It should_contain_default_operator_part = () => result.ShouldContain("'default_operator': 'AND'".AltQuote());
        
        It should_contain_analyzer_part = () => result.ShouldContain("'analyzer': 'snowball'".AltQuote());

        It should_contain_allow_leading_wildcard_part = () => result.ShouldContain("'allow_leading_wildcard': true".AltQuote());

        It should_contain_lowercase_expanded_terms_part = () => result.ShouldContain("'lowercase_expanded_terms': false".AltQuote());

        It should_contain_enable_position_increments_part = () => result.ShouldContain("'enable_position_increments': true".AltQuote());

        It should_contain_fuzzy_prefix_length_part = () => result.ShouldContain("'fuzzy_prefix_length': 10".AltQuote());

        It should_contain_fuzzy_min_sim_part = () => result.ShouldContain("'fuzzy_min_sim': 0.7".AltQuote());

        It should_contain_phrase_slop_part = () => result.ShouldContain("'phrase_slop': 5".AltQuote());

        It should_contain_analyze_wildcard_part = () => result.ShouldContain("'analyze_wildcard': false".AltQuote());
            
        It should_contain_auto_generate_phrase_queries_part = () => result.ShouldContain("'auto_generate_phrase_queries': true".AltQuote());

        It should_contain_minimum_should_match_part = () => result.ShouldContain("'minimum_should_match': '50%'".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("custom part".AltQuote());


        It should_return_correct_query = () => result.ShouldEqual(("{ " +
                                                              "'field': { " +
                                                                  "'StringProperty': { " +
                                                                      "'boost': 5," +
                                                                      "'rewrite': 'top_terms_boost_100'," +
                                                                      "'query': 'query text'," +
                                                                      "'default_operator': 'AND'," +
                                                                      "'analyzer': 'snowball'," +
                                                                      "'allow_leading_wildcard': true," +
                                                                      "'lowercase_expanded_terms': false," +
                                                                      "'enable_position_increments': true," +
                                                                      "'fuzzy_prefix_length': 10," +
                                                                      "'fuzzy_min_sim': 0.7," +
                                                                      "'phrase_slop': 5," +
                                                                      "'analyze_wildcard': false," +
                                                                      "'auto_generate_phrase_queries': true," +
                                                                      "'minimum_should_match': '50%'," +
                                                                      "custom part " +
                                                                  "} " +
                                                              "} " +
                                                          "}").AltQuote());

        private static string result;
    }
}
