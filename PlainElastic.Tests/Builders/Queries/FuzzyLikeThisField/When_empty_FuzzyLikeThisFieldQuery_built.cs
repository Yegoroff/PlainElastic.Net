using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(FuzzyLikeThisFieldQuery<>))]
    class When_empty_FuzzyLikeThisFieldQuery_built
    {
        Because of = () => result = new FuzzyLikeThisFieldQuery<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
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
