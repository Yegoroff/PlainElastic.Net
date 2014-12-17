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
                                                .Script( "script 'part'")
                                                .Custom("{ custom part }")
                                                .ToString();


        It should_starts_with_custom_score_declaration = () =>
            result.ShouldStartWith("{ 'custom_score':".AltQuote());

        It should_contain_query_part = () =>
            result.ShouldContain("'query': { query }".AltQuote());

        It should_contain_boost_part = () =>
            result.ShouldContain("'boost': 5".AltQuote());

        It should_contain_params_part = () =>
            result.ShouldContain("'params': { 'param1' : 2, 'param2' : 3.1 }".AltQuote());

        It should_contain_scripts_part = () =>
            result.ShouldContain("'script': 'script `part`'".AltQuote());

        It should_contain_custom_part = () =>
            result.ShouldContain("{ custom part }".AltQuote());


        It should_return_correct_result = () =>
            result.ShouldEqual(("{ " +
                                    "'custom_score': { " +
                                        "'query': { query }," +
                                        "'boost': 5," +
                                        "'lang': 'js'," +
                                        "'params': { 'param1' : 2, 'param2' : 3.1 }," +
                                        "'script': 'script `part`'," +
                                        "{ custom part } " +
                                   "} " +
                               "}").AltQuote());

        private static string result;
    }
}
