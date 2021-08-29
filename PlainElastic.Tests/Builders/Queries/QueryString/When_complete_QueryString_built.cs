using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(QueryString<>))]
    class When_complete_QueryString_built
    {
        Because of = () => result = new QueryString<FieldsTestClass>()
                                                .DefaultField(f => f.StringProperty)
                                                .Fields(f => f.StringProperty, f=> f.BoolProperty)
                                                .FieldsOfCollection(f => f.CollectionProperty, collection => collection.EnumProperty, collection => collection.StringProperty)
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
                                                .UseDisMax(true)
                                                .TieBreaker(0.8)
                                                .Exists("StringField")
                                                .Missing("MissingField")
                                                .ToString();


        It should_contain_default_field_part = () => result.ShouldContain("'default_field': 'StringProperty'".AltQuote());

        It should_contain_fields_part = () => result.ShouldContain("'fields': [ 'StringProperty','BoolProperty','CollectionProperty.EnumProperty','CollectionProperty.StringProperty' ]".AltQuote());

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

        It should_contain_use_dis_max_part = () => result.ShouldContain("'use_dis_max': true".AltQuote());

        It should_contain_tie_breaker_part = () => result.ShouldContain("'tie_breaker': 0.8".AltQuote());

        It should_contain_exists_part = () => result.ShouldContain("'_exists_': 'StringField'".AltQuote());
        
        It should_contain_missing_part = () => result.ShouldContain("'_missing_': 'MissingField'".AltQuote());


        It should_return_correct_query = () => result.ShouldEqual(("{ " +
                                                                      "'query_string': { " +
                                                                          "'fields': [ 'StringProperty','BoolProperty','CollectionProperty.EnumProperty','CollectionProperty.StringProperty' ]," +
                                                                          "'default_field': 'StringProperty'," +
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
                                                                          "'use_dis_max': true," +
                                                                          "'tie_breaker': 0.8," +
                                                                          "'_exists_': 'StringField'," +
                                                                          "'_missing_': 'MissingField' " +
                                                                      "} " +
                                                                  "}").AltQuote());

        private static string result;
    }
}
