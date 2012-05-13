using Machine.Specifications;
using PlainElastic.Net.Queries;


namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(TypeFilter<>))]
    class When_empty_TypeFilter_built
    {
        Because of = () => result = new TypeFilter<FieldsTestClass>()
                                                .Value(null)
                                                .ToString();

        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
