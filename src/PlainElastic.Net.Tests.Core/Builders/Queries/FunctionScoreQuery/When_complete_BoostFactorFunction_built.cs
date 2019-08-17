using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(BoostFactorFunction<>))]
    class When_complete_BoostFactorFunction_built
    {
        Because of = () => result = new BoostFactorFunction<FieldsTestClass>()
                                                .BoostFactor(100)
                                                .ToString();

        It should_return_correct_result = () => result.ShouldEqual(("'boost_factor': 100").AltQuote());

        private static string result;
    }
}
