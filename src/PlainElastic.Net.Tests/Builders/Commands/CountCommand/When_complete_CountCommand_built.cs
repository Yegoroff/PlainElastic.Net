using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(CountCommand))]
    class When_complete_CountCommand_built
    {

        Because of = () => result = new CountCommand(index: "Index", type: "Type")
            .Analyzer("analyzer")
            .DefaultOperator(Operator.OR)
            .Df("defaultField")
            .Q("query:test")
            .Routing("route")
            .Pretty()
            .BuildCommand();


        It should_starts_with_index_type = () => result.ShouldStartWith("index/type");

        It should_contains_count_verb = () => result.ShouldContain("_count");

        It should_contain_parameter_analyzer_equals_to_analyzer = () => result.ShouldContain("?analyzer=analyzer");

        It should_contain_parameter_default_operator_equals_to_OR = () => result.ShouldContain("&default_operator=OR");

        It should_contain_parameter_df_equals_to_defaultField = () => result.ShouldContain("&df=defaultField");

        It should_contain_parameter_q_equals_to_query_test = () => result.ShouldContain("&q=query:test");

        It should_contain_parameter_routing_equals_to_route = () => result.ShouldContain("&routing=route");

        It should_return_correct_value = () => result.ShouldEqual(@"index/type/_count?analyzer=analyzer&default_operator=OR&df=defaultField&q=query:test&routing=route&pretty=true");


        private static string result;
    }
}
