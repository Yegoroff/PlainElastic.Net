using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(FilteredScoreFunction<>))]
    class When_empty_FilteredScoreFunction_built
    {
        Because of = () => result = new FilteredScoreFunction<FieldsTestClass>()
                                                .Filter(f => f)
                                                .BoostFactor(fn => fn)
                                                .ToString();


        It should_return_empty_result = () => result.ShouldBeEmpty();

        private static string result;
    }
}
