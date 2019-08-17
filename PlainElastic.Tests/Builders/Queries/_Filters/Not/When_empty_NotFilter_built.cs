using Machine.Specifications;
using PlainElastic.Net.Queries;


namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(NotFilter<>))]
    class When_empty_NotFilter_built
    {
        Because of = () => result = new NotFilter<FieldsTestClass>()
                                                .Filter( f => f)
                                                .Cache(true)
                                                .ToString();

        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
