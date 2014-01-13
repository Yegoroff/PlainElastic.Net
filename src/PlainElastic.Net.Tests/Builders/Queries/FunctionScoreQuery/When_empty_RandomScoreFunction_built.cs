using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(RandomScoreFunction<>))]
    class When_empty_RandomScoreFunction_built
    {
        Because of = () => result = new RandomScoreFunction<FieldsTestClass>()
                                                .ToString();

        It should_return_correct_result = () => result.ShouldEqual(("'random_score': {  }").AltQuote());

        private static string result;
    }
}
