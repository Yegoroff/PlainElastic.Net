using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Buildres.Queries
{
    [Subject(typeof(RangeFilter<>))]
    class When_RangeFilter_without_range_parts_built
    {
        private Because of = () => result = new RangeFilter<FieldsTestClass>()                                                
                                                .Field(f=> f.StringProperty)
                                                .ToString();

        It should_return_empty_query = () => result.ShouldEqual("");

        private static string result;
    }
}
