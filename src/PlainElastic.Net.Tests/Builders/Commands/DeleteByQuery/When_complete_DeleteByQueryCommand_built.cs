using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(DeleteByQueryCommand))]
    class When_complete_DeleteByQueryCommand_built
    {

        Because of = () => result = new DeleteByQueryCommand(index: "Index", type: "Type")
            .Analyzer("analyzer")
            .DefaultOperator(Operator.OR)
            .Df("defaultField")
            .Q("query:test")
            .Routing("route")
            .Timeout("1m")
            .Replication(DocumentReplication.async)
            .Consistency(WriteConsistency.all)
            .Refresh()
            .Pretty()

            .BuildCommand();


        It should_starts_with_index_type = () => result.ShouldStartWith("index/type");

        It should_contains_query_verb = () => result.ShouldContain("_query");

        It should_contain_parameter_analyzer_equals_to_analyzer = () => result.ShouldContain("?analyzer=analyzer");

        It should_contain_parameter_default_operator_equals_to_OR = () => result.ShouldContain("&default_operator=OR");

        It should_contain_parameter_df_equals_to_defaultField = () => result.ShouldContain("&df=defaultField");

        It should_contain_parameter_q_equals_to_query_test = () => result.ShouldContain("&q=query:test");

        It should_contain_parameter_routing_equals_to_route = () => result.ShouldContain("&routing=route");

        It should_contain_parameter_timeout_equals_to_1m = () => result.ShouldContain("&timeout=1m");

        It should_contain_parameter_replication_equals_to_async = () => result.ShouldContain("&replication=async");

        It should_contain_parameter_consistency_equals_to_all = () => result.ShouldContain("&consistency=all");

        It should_return_correct_value = () => result.ShouldEqual(@"index/type/_query?analyzer=analyzer&default_operator=OR&df=defaultField&q=query:test&routing=route&timeout=1m&replication=async&consistency=all&refresh=true&pretty=true");


        private static string result;
    }
}
