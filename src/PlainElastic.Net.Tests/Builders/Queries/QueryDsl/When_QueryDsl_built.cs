using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(Query<>))]
    class When_QueryDsl_built
    {
        Because of = () => result = new QueryDsl<FieldsTestClass>()
                                                .MatchAll()
                                                .ToString();



        It should_return_correct_result = () => result.ShouldEqual(("{ 'match_all': {  } }").AltQuote());

        private static string result;
    }
}
