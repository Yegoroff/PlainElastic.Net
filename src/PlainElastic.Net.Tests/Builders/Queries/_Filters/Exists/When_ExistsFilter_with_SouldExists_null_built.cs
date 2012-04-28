using Machine.Specifications;
using PlainElastic.Net.Queries;


namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(ExistsFilter<>))]
    class When_ExistsFilter_with_SouldExists_null_built
    {
        Because of = () => result = new ExistsFilter<FieldsTestClass>()                                                
                                                .Field(f => f.StringProperty)
                                                .ShouldExists(null)
                                                .ToString();

        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
