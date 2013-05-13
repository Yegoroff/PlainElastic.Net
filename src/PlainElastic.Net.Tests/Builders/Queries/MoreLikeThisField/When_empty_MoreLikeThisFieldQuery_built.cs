using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(MoreLikeThisFieldQuery<>))]
    class When_empty_MoreLikeThisFieldQuery_built
    {
        Because of = () => result = new MoreLikeThisFieldQuery<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .LikeText("")
                                                .PercentTermsToMatch(0.5)
                                                .MinTermFreq(5)
                                                .MaxQueryTerms(15)
                                                .StopWords("One", "Two", "Three")
                                                .MinDocFreq(10)
                                                .MaxDocFreq(18)
                                                .MinWordLen(2)
                                                .MaxWordLen(7)
                                                .BoostTerms(3)
                                                .Boost(5)
                                                .Analyzer(DefaultAnalyzers.snowball)
                                                .Custom("")
                                                .ToString();


        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
