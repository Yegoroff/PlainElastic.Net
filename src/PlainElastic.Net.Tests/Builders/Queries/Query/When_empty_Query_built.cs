using Machine.Specifications;
using PlainElastic.Net.Queries;


namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(Query<>))]
    class When_empty_Query_built
    {
        Because of = () => 
            result = new Query<FieldsTestClass>()
                        .ToString();

        It should_return_empty_string = () =>
            result.ShouldBeEmpty();

        private static string result;
    }
}
