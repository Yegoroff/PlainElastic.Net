using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(MultiMatchQuery<>))]
    class When_complete_MultiMatchQuery_built
    {
        Because of = () => result = new MultiMatchQuery<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Fields(f=> f.BoolProperty, f=> f.EnumProperty)
                                                .UseDisMax(true)
                                                .TieBreaker(0.8)
                                                .Query("One")
                                                .Boost(5)
                                                .Type(TextQueryType.phrase)
                                                .Operator(Operator.AND)
                                                .Analyzer(DefaultAnalyzers.standard)
                                                .Fuzziness(0.3)
                                                .PrefixLength(7)
                                                .MaxExpansions(10)
                                                .Slop(4)
                                                .CutoffFrequency(6.5)
                                                .MinimumShouldMatch("msm")
                                                .FuzzyRewrite(Rewrite.top_terms_n, 25)
                                                .FuzzyTranspositions(true)
                                                .Lenient(true)
                                                .ZeroTermsQuery(ZeroTermsQuery.ALL)
                                                .Rewrite(Rewrite.top_terms_boost_n, 100)
                                                .ToString();

        It should_contain_fields_part = () => result.ShouldContain("'fields': [ 'BoolProperty','EnumProperty','StringProperty' ]".AltQuote());

        It should_contain_use_dis_max_part = () => result.ShouldContain("'use_dis_max': true".AltQuote());

        It should_contain_tie_breaker_part = () => result.ShouldContain("'tie_breaker': 0.8".AltQuote());

        It should_contain_boost_part = () => result.ShouldContain("'boost': 5".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'phrase'".AltQuote());

        It should_contain_operator_part = () => result.ShouldContain("'operator': 'AND'".AltQuote());

        It should_contain_analyzer_part = () => result.ShouldContain("'analyzer': 'standard'".AltQuote());

        It should_contain_fuzziness_part = () => result.ShouldContain("'fuzziness': 0.3".AltQuote());

        It should_contain_prefix_length_part = () => result.ShouldContain("'prefix_length': 7".AltQuote());

        It should_contain_max_expansions_part = () => result.ShouldContain("'max_expansions': 10".AltQuote());

        It should_contain_slop_part = () => result.ShouldContain("'slop': 4".AltQuote());

        It should_contain_rewrite_part = () => result.ShouldContain("'rewrite': 'top_terms_boost_100'".AltQuote());

        It should_contain_cutoff_frequency_part = () => result.ShouldContain("'cutoff_frequency': 6.5".AltQuote());

        It should_contain_minimum_should_match_part = () => result.ShouldContain("'minimum_should_match': 'msm'".AltQuote());

        It should_contain_fuzzy_rewrite_part = () => result.ShouldContain("'fuzzy_rewrite': 'top_terms_25'".AltQuote());

        It should_contain_fuzzy_transpositions_part = () => result.ShouldContain("'fuzzy_transpositions': true".AltQuote());

        It should_contain_lenient_part = () => result.ShouldContain("'lenient': true".AltQuote());

        It should_contain_zero_terms_query_part = () => result.ShouldContain("'zero_terms_query': 'ALL'".AltQuote());


        It should_return_correct_query = () => result.ShouldEqual(("{ 'multi_match': { " +
                                                                            "'fields': [ 'BoolProperty','EnumProperty','StringProperty' ]," +
                                                                            "'use_dis_max': true," +
                                                                            "'tie_breaker': 0.8," +
                                                                            "'query': 'One'," +
                                                                            "'boost': 5," +
                                                                            "'type': 'phrase'," +
                                                                            "'operator': 'AND'," +
                                                                            "'analyzer': 'standard'," +
                                                                            "'fuzziness': 0.3," +
                                                                            "'prefix_length': 7," +
                                                                            "'max_expansions': 10," +
                                                                            "'slop': 4," +
                                                                            "'cutoff_frequency': 6.5," +
                                                                            "'minimum_should_match': 'msm'," +
                                                                            "'fuzzy_rewrite': 'top_terms_25'," +
                                                                            "'fuzzy_transpositions': true," +
                                                                            "'lenient': true," +
                                                                            "'zero_terms_query': 'ALL'," +
                                                                            "'rewrite': 'top_terms_boost_100' " +
                                                                     "} " +
                                                                   "}").AltQuote());

        private static string result;
    }
}

