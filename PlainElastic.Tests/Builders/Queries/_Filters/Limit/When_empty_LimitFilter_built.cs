using Machine.Specifications;
using PlainElastic.Net.Queries;


namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(LimitFilter<>))]
    class When_empty_LimitFilter_built
    {
        Because of = () => result = new LimitFilter<FieldsTestClass>()
                                                .Value(null)
                                                .ToString();

        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
