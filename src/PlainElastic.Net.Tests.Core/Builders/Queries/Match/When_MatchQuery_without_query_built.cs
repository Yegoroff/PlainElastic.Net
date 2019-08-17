using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(MatchQuery<>))]
    class When_MatchQuery_without_query_built
    {
        Because of = () => result = new MatchQuery<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
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

        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
