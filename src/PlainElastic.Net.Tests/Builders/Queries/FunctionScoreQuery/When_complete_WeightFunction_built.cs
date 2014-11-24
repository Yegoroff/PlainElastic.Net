using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(WeightFunction<>))]
    class When_complete_WeightFunction_built
    {
        Because of = () => result = new WeightFunction<FieldsTestClass>()
            .Weight(100)
            .ToString();

        It should_return_correct_result = () => result.ShouldEqual(("'weight': 100").AltQuote());

        private static string result;
    }
}