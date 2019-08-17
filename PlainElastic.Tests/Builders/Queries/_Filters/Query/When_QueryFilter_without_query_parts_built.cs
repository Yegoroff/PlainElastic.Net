using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(QueryFilter<>))]
    class When_QueryFilter_without_Query_parts_built
    {
        Because of = () => result = new QueryFilter<FieldsTestClass>()
                                                .Name("FilterName")
                                                .QueryString(q => q)
                                                .ToString();

        It should_return_empty_query = () => result.ShouldEqual("");

        private static string result;
    }
}
