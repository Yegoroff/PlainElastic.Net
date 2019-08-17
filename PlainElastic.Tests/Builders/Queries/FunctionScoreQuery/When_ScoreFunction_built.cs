using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(ScoreFunction<>))]
    class When_ScoreFunction_built
    {
        Because of = () => result = new ScoreFunction<FieldsTestClass>()
                                                .RandomScore(r => r
                                                    .Seed(123)
                                                )
                                                .ToString();

        It should_contain_seed_part = () => result.ShouldContain("'seed': 123".AltQuote());

        It should_return_correct_result = () => result.ShouldEqual(("'random_score': { 'seed': 123 }").AltQuote());

        private static string result;
    }
}
