using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(MatchAllQuery<>))]
    class When_MatchAllQuery_without_value_built
    {
        Because of = () => 
            result = new MatchAllQuery<FieldsTestClass>()
                                                .ToString();

        It should_return_match_all_query = () =>
            result.ShouldEqual("{ 'match_all': {  } }".AltQuote());

        private static string result;
    }
}
