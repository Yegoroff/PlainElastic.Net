using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Buildres.Queries
{
    [Subject(typeof(Sort<>))]
    class When_Sort_with_reflected_field_built
    {
        Because of = () => result = new Sort<FieldsTestClass>()
                                                .Field(f => f.StringProperty, order: SortDirection.ask, missing: "_last")
                                                .ToString();

        It should_contain_correct_order = () => result.ShouldContain(@"'order': 'ask'".AltQuote());

        It should_contain_correct_missing_value = () => result.ShouldContain(@"'missing': '_last'".AltQuote());

        It should_return_correct_value = () => result.ShouldEqual(@"'sort': [{ 'StringProperty': { 'order': 'ask','missing': '_last' } }]".AltQuote());

        private static string result;
    }
}
