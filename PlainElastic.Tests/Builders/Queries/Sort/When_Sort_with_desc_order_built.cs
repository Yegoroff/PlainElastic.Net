using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(Sort<>))]
    class When_Sort_with_desc_order_built
    {
        Because of = () => result = new Sort<FieldsTestClass>()
                                                .Field("field", order: SortDirection.desc, missing: "_last", ignoreUnmapped: true)
                                                .ToString();

        It should_contain_correct_order = () => result.ShouldContain(@"'order': 'desc'".AltQuote());

        It should_contain_correct_missing_value = () => result.ShouldContain("'missing': '_last'".AltQuote());

        It should_return_correct_value = () => result.ShouldEqual("'sort': [{ 'field': { 'order': 'desc','missing': '_last','ignore_unmapped': true } }]".AltQuote());

        private static string result;
    }
}
