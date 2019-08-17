using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(RangeFilter<>))]
    class When_RangeFilter_without_range_parts_built
    {
        Because of = () => result = new RangeFilter<FieldsTestClass>()                                                
                                                .Field(f=> f.StringProperty)
                                                .ToString();

        It should_return_empty_query = () =>
            result.ShouldBeEmpty();

        private static string result;
    }
}
