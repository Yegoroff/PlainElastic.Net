using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(FieldQuery<>))]
    class When_empty_FieldQuery_built
    {
        Because of = () => result = new FieldQuery<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Boost(5)
                                                .Rewrite(Rewrite.top_terms_boost_n, 100)
                                                .Query("")
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
                                                .ToString();


        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
