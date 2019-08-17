using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(MultiMatchQuery<>))]
    class When_MultiMatchQuery_without_query_built
    {
        Because of = () => result = new MultiMatchQuery<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Fields(f => f.BoolProperty, f => f.EnumProperty)
                                                .UseDisMax(true)
                                                .TieBreaker(0.8)
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
