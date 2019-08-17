using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(RangeQuery<>))]
    class When_complete_RangeQuery_built
    {
        Because of = () => result = new RangeQuery<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .From("1")
                                                .To("100")
                                                .IncludeLower(true)
                                                .IncludeUpper(false)
                                                .Boost(5)
                                                .Custom("'custom': {0}".AltQuote(), "123")
                                                .ToString();

        It should_contain_boost_part = () => result.ShouldContain(@"'boost': 5".AltQuote());

        It should_return_correct_query = () => result.ShouldEqual(@"{ 'range': { 'StringProperty': { 'from': '1','to': '100','include_lower': true,'include_upper': false,'boost': 5,'custom': 123 } } }".AltQuote());

        private static string result;
    }
}
