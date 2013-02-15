using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(Sort<>))]
    class When_Sort_with_reflected_field_built
    {
        Because of = () => result = new Sort<FieldsTestClass>()
                                                .Field(f => f.StringProperty, order: SortDirection.asc, missing: "_last", ignoreUnmapped: true)
                                                .ToString();

        It should_contain_correct_order = () => result.ShouldContain(@"'order': 'asc'".AltQuote());

        It should_contain_correct_missing_value = () => result.ShouldContain(@"'missing': '_last'".AltQuote());

        It should_return_correct_value = () => result.ShouldEqual(@"'sort': [{ 'StringProperty': { 'order': 'asc','missing': '_last','ignore_unmapped': true } }]".AltQuote());

        private static string result;
    }
}
