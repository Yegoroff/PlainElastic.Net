using Machine.Specifications;
using PlainElastic.Net.Queries;


namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(BoostingQuery<>))]
    class When_empty_BoostingQuery_built
    {
        Because of = () => result = new BoostingQuery<FieldsTestClass>()
                                                .Positive(p => p)
                                                .Negative(n => n)
                                                .Boost(10)
                                                .NegativeBoost(0.5)
                                                .ToString();

        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
