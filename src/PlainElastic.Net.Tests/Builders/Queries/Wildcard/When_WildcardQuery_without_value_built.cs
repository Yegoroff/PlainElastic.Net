using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(WildcardQuery<>))]
    class When_WildcardQuery_without_value_built
    {
        Because of = () => result = new WildcardQuery<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Boost(5)
                                                .ToString();

        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
