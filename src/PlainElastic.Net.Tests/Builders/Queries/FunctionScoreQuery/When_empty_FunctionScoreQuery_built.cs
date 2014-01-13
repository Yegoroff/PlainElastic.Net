using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(FunctionScoreQuery<>))]
    class When_empty_FunctionScoreQuery_built
    {
        Because of = () => result = new FunctionScoreQuery<FieldsTestClass>()
                                                .Query(q => q)
                                                .Filter(f => f)
                                                .ScoreMode(FunctionScoreMode.max)
                                                .Boost(2)
                                                .BoostMode(FunctionBoostMode.min)
                                                .Function(fn => fn)
                                                .Functions(fns => fns)
                                                .MaxBoost(10)
                                                .ToString();


        It should_return_empty_result = () => result.ShouldBeEmpty();

        private static string result;
    }
}
