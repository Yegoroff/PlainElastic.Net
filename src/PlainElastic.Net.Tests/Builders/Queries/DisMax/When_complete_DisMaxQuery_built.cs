using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(DisMaxQuery<>))]
    class When_complete_DisMaxQuery_built
    {
        Because of = () => result = new DisMaxQuery<FieldsTestClass>()
                                                .Queries(q => q
                                                    .Custom("Queries")
                                                )
                                                .Boost(10)
                                                .TieBreaker(0.5)
                                                .Custom("{ custom part }")
                                                .ToString();

        It should_return_correct_result = () => result.ShouldEqual(@"{ 'dis_max': { 'queries': [ Queries ],'boost': 10,'tie_breaker': 0.5,{ custom part } } }".AltQuote());

        private static string result;
    }
}
