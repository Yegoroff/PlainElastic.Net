using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(MatchAllQuery<>))]
    class When_complete_MatchAllQuery_built
    {
        Because of = () => result = new MatchAllQuery<FieldsTestClass>()
                                                .Boost(5)
                                                .NormsField(f => f.StringProperty)
                                                .ToString();

        It should_contain_boost_part = () => result.ShouldContain(@"'boost': 5".AltQuote());

        It should_contain_norms_field_part = () => result.ShouldContain(@"'norms_field': 'StringProperty'".AltQuote());

        It should_return_correct_query = () => result.ShouldEqual(@"{ 'match_all': { 'boost': 5,'norms_field': 'StringProperty' } }".AltQuote());

        private static string result;
    }
}
