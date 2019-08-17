using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(FuzzyLikeThisQuery<>))]
    class When_empty_FuzzyLikeThisQuery_built
    {
        Because of = () => result = new FuzzyLikeThisQuery<FieldsTestClass>()
                                                .Fields(f => f.StringProperty, f => f.BoolProperty)
                                                .FieldsOfCollection(f => f.CollectionProperty, collection => collection.EnumProperty, collection => collection.StringProperty)
                                                .LikeText("")
                                                .IgnoreTf(true)
                                                .MaxQueryTerms(10)
                                                .MinSimilarity(0.8)
                                                .PrefixLength(3)
                                                .Boost(5)
                                                .Analyzer(DefaultAnalyzers.snowball)
                                                .Custom("")
                                                .ToString();


        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
