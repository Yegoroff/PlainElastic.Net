using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(BoostingQuery<>))]
    class When_complete_BoostingQuery_built
    {
        Because of = () => result = new BoostingQuery<FieldsTestClass>()
                                                .Positive( p => p
                                                    .Custom("Positive")
                                                )
                                                .Negative(n => n
                                                    .Custom("Negative")
                                                )
                                                .Boost(10)
                                                .NegativeBoost(0.5)
                                                .Custom("Custom")
                                                .ToString();


        It should_start_with_boosting = () => result.ShouldContain("'boosting': {".AltQuote());

        It should_contain_positive_part = () => result.ShouldContain("'positive': { Positive }".AltQuote());

        It should_contain_negative_part = () => result.ShouldContain("'negative': { Negative }".AltQuote());

        It should_contain_boost_part = () => result.ShouldContain("'boost': 10".AltQuote());

        It should_contain_negative_boost_part = () => result.ShouldContain("'negative_boost': 0.5".AltQuote());

        It should_return_correct_result = () => result.ShouldEqual(("{ 'boosting': { " +
                                                                           "'positive': { Positive }," +
                                                                           "'negative': { Negative }," +
                                                                           "'boost': 10," +
                                                                           "'negative_boost': 0.5," +
                                                                           "Custom " +
                                                                       "} " +
                                                                   "}").AltQuote());

        private static string result;
    }
}
