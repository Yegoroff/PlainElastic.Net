using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(TermQuery<>))]
    class When_complete_TermQuery_built
    {
        Because of = () => result = new TermQuery<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Value("One")
                                                .Boost(5)
                                                .ToString();

        It should_contain_boost_part = () => result.ShouldContain(@"'boost': 5".AltQuote());

        It should_return_correct_query = () => result.ShouldEqual(@"{ 'term': { 'StringProperty': { 'value': 'One','boost': 5 } } }".AltQuote());

        private static string result;
    }
}
