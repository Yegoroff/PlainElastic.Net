using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Buildres.Queries
{
    [Subject(typeof(Sort<>))]
    class When_Sort_with_desc_order_built
    {
        private Because of = () => result = new Sort<FieldsTestClass>()
                                                .Field("field", order: SortDirection.desc, missing: "_last")
                                                .ToString();

        It should_not_contain_order_part = () => result.ShouldNotContain("order");

        It should_contain_correct_missing_value = () => result.ShouldContain("'missing': '_last'".SmartQuote());

        It should_return_correct_value = () => result.ShouldEqual("'sort': [{ 'field': { 'missing': '_last' } }]".SmartQuote());

        private static string result;
    }
}
