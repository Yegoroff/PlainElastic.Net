using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Buildres.Queries
{
    [Subject(typeof(RangeQuery<>))]
    class When_complete_RangeQuery_built
    {
        private Because of = () => result = new RangeQuery<FieldsTestClass>()
                                                .Field(f => f.Property1)
                                                .From("1")
                                                .To("100")
                                                .IncludeLower(true)
                                                .IncludeUpper(false)
                                                .Boost(5)
                                                .Custom("'custom': {0}", "123")
                                                .ToString();

        It should_contain_boost_part = () => result.ShouldContain(@"'boost': 5".SmartQuote());

        It should_return_correct_query = () => result.ShouldEqual(@"{ 'range': { 'Property1': { 'from': '1','to': '100','include_lower': true,'include_upper': false,'boost': 5,'custom': 123 } } }".SmartQuote());

        private static string result;
    }
}
