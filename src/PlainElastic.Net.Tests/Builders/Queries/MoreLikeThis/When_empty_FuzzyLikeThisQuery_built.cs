using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(MoreLikeThisQuery<>))]
    class When_empty_MoreLikeThisQuery_built
    {
        Because of = () => result = new MoreLikeThisQuery<FieldsTestClass>()
                                                .Fields(f => f.StringProperty, f => f.BoolProperty)
                                                .FieldsOfCollection(f => f.CollectionProperty, collection => collection.EnumProperty, collection => collection.StringProperty)
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
