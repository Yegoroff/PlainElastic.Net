using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(RangeQuery<>))]
    class When_RangeQuery_without_range_parts_built
    {
        Because of = () => result = new RangeQuery<FieldsTestClass>()                                                
                                                .Field(f=> f.StringProperty)
                                                .ToString();

        It should_return_empty_query = () => result.ShouldBeEmpty();

        private static string result;
    }
}
