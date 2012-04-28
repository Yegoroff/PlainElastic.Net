using Machine.Specifications;
using PlainElastic.Net.Queries;


namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(Filter<>))]
    class When_empty_Filter_built
    {
        Because of = () => result = new Filter<FieldsTestClass>()
                                            .ToString();

        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
