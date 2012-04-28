using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(TermFilter<>))]
    class When_TermFilter_with_custom_part_built
    {
        Because of = () => result = new TermFilter<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Value("One")
                                                .Custom("'name': '{0}'".AltQuote(), "filterName")
                                                .ToString();

        It should_contain_custom_part = () => result.ShouldContain(@"'name': 'filterName'".AltQuote());

        It should_return_correct_query = () => result.ShouldEqual(@"{ 'term': { 'StringProperty': 'One','name': 'filterName' } }".AltQuote());

        private static string result;
    }
}
