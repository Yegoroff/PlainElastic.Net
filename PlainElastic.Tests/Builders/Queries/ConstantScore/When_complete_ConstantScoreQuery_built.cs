using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(ConstantScoreQuery<>))]
    class When_complete_ConstantScoreQuery_built
    {
        Because of = () => result = new ConstantScoreQuery<FieldsTestClass>()
                                                .Query(q => q.Custom("{ query }"))
                                                .Filter(f => f.Custom("{ filter }"))
                                                .Boost(5)
                                                .Custom("{ custom part }")
                                                .ToString();

        It should_return_correct_result = () => result.ShouldEqual("{ 'constant_score': { 'query': { query },'filter': { filter },'boost': 5,{ custom part } } }".AltQuote());

        private static string result;
    }
}
