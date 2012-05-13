using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(CustomScoreQuery<>))]
    class When_complete_CustomScoreQuery_built
    {
        Because of = () => result = new CustomScoreQuery<FieldsTestClass>()
                                                .Query(q => q.Custom("{ query }"))
                                                .Boost(5)
                                                .Lang(ScriptLangs.js)
                                                .Params( "{ 'param1' : 2, 'param2' : 3.1 }".AltQuote())
                                                .Script( "script part")
                                                .Custom("{ custom part }")
                                                .ToString();

        It should_return_correct_result = () =>
            result.ShouldEqual(("{ " +
                                    "'custom_score': { " +
                                        "'query': { query }," +
                                        "'boost': 5," +
                                        "'lang': 'js'," +
                                        "'params': { 'param1' : 2, 'param2' : 3.1 }," +
                                        "'script': 'script part'," +
                                        "{ custom part } " +
                                   "} " +
                               "}").AltQuote());

        private static string result;
    }
}
