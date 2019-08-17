using Machine.Specifications;
using PlainElastic.Net.Queries;


namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(OrFilter<>))]
    class When_empty_OrFilter_built
    {
        Because of = () => result = new OrFilter<FieldsTestClass>()
                                            .ToString();

        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
