using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(TopChildrenQuery<>))]
    class When_complete_TopChildrenQuery_built
    {
        Because of = () => result = new TopChildrenQuery<FieldsTestClass>()
                                                .Type("childType")
                                                .Query(q => q.Custom("{ query }"))
                                                .Scope("query_scope")
                                                .IncrementalFactor(5)
                                                .Factor(10)
                                                .Score(TopChildrenScoreMode.avg)
                                                .Boost(5)
                                                .Custom("{ custom part }")
                                                .ToString();


        It should_starts_with_top_children_declaration = () =>
            result.ShouldStartWith("{ 'top_children':".AltQuote());

        It should_contain_type_part = () =>
            result.ShouldContain("'type': 'childType'".AltQuote());

        It should_contain_query_part = () =>
            result.ShouldContain("'query': { query }".AltQuote());

        It should_contain_scope_part = () =>
            result.ShouldContain("'_scope': 'query_scope'".AltQuote());

        It should_contain_incremental_factor_part = () =>
            result.ShouldContain("'incremental_factor': 5".AltQuote());

        It should_contain_factor_part = () =>
                   result.ShouldContain("'factor': 10".AltQuote());

        It should_contain_score_part = () =>
            result.ShouldContain("'score': 'avg'".AltQuote());

        It should_contain_boost_part = () =>
            result.ShouldContain("'boost': 5".AltQuote());

        It should_contain_custom_part = () =>
            result.ShouldContain("{ custom part }".AltQuote());


        It should_return_correct_result = () =>
            result.ShouldEqual(("{ " +
                                    "'top_children': { " +
                                        "'type': 'childType'," +    
                                        "'query': { query }," +
                                        "'_scope': 'query_scope'," +
                                        "'incremental_factor': 5," +
                                        "'factor': 10," +
                                        "'score': 'avg'," +
                                        "'boost': 5," +
                                        "{ custom part } " +
                                   "} " +
                               "}").AltQuote());

        private static string result;
    }
}
