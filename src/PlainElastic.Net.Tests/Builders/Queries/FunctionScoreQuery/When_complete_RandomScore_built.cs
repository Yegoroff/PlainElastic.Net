using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(RandomScoreFunction<>))]
    class When_complete_RandomScoreFunction_built
    {
        Because of = () => result = new RandomScoreFunction<FieldsTestClass>()
                                                .Seed(123)
                                                .ToString();

        It should_contain_seed_part = () => result.ShouldContain("'seed': 123".AltQuote());

        It should_return_correct_result = () => result.ShouldEqual(("'random_score': { " +
                                                                            "'seed': 123" +
                                                                        " }").AltQuote());

        private static string result;
    }
}
