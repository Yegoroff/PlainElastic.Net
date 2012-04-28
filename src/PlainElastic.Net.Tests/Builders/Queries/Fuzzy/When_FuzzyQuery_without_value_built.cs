using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(FuzzyQuery<>))]
    class When_FuzzyQuery_without_value_built
    {
        Because of = () => result = new FuzzyQuery<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Boost(5)
                                                .Boost(5)
                                                .MaxExpansions(10)
                                                .PrefixLength(7)
                                                .MinSimilarity(0.5)
                                                .ToString();

        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
