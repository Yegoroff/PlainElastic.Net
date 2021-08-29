using Machine.Specifications;
using PlainElastic.Net.Queries;


namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(AndFilter<>))]
    class When_empty_AndFilter_built
    {
        Because of = () => result = new AndFilter<FieldsTestClass>()
                                            .ToString();

        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
