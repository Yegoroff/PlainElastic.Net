using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(BoolQuery<>))]
    class When_complete_BoolQuery_built
    {
        Because of = () => result = new BoolQuery<FieldsTestClass>()
                                                .Must( m => m
                                                    .Custom("Must")
                                                )
                                                .MustNot(mn => mn
                                                    .Custom("Must Not")
                                                )
                                                .Should( s => s
                                                    .Custom("Should")
                                                )
                                                .MinimumNumberShouldMatch(2)
                                                .Boost(10)
                                                .DisableCoord(true)
                                                .Custom("Custom")
                                                .ToString();


        It should_contain_must_part = () => result.ShouldContain("'must': [ Must ]".AltQuote());

        It should_contain_must_not_part = () => result.ShouldContain("'must_not': [ Must Not ]".AltQuote());

        It should_contain_should_part = () => result.ShouldContain("'should': [ Should ]".AltQuote());


        It should_return_correct_result = () => result.ShouldEqual(("{ 'bool': { " +
                                                                           "'must': [ Must ]," +
                                                                           "'must_not': [ Must Not ]," +
                                                                           "'should': [ Should ]," +
                                                                           "'minimum_number_should_match': 2," +
                                                                           "'boost': 10," +
                                                                           "'disable_coord': true," +
                                                                           "Custom " +
                                                                       "} " +
                                                                   "}").AltQuote());

        private static string result;
    }
}
