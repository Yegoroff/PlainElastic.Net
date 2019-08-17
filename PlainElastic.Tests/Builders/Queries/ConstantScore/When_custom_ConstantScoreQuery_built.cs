using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(ConstantScoreQuery<>))]
    class When_custom_ConstantScoreQuery_built
    {
        Because of = () => result = new ConstantScoreQuery<FieldsTestClass>()
                                                .Custom("{ custom part }")
                                                .ToString();

        It should_return_correct_result = () => result.ShouldEqual(@"{ 'constant_score': { { custom part } } }".AltQuote());

        private static string result;
    }
}
