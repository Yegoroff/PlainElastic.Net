using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Buildres.Queries
{
    [Subject(typeof(Sort<>))]
    class When_Sort_with_reflected_field_built
    {
        private Because of = () => result = new Sort<FieldsTestClass>()
                                                .Field(f => f.Property1, order: SortDirection.ask, missing: "_last")
                                                .ToString();

        It should_contain_correct_order = () => result.ShouldContain(@"'order': 'ask'".SmartQuote());

        It should_contain_correct_missing_value = () => result.ShouldContain(@"'missing': '_last'".SmartQuote());

        It should_return_correct_value = () => result.ShouldEqual(@"'sort': [{ 'Property1': { 'order': 'ask','missing': '_last' } }]".SmartQuote());

        private static string result;
    }
}
