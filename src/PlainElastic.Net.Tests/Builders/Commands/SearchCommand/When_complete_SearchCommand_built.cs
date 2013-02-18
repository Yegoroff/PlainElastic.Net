using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(SearchCommand))]
    class When_complete_SearchCommand_built
    {

        Because of = () => result = new SearchCommand(index:"Index", type:"Type")
            .AnalyzeWildcard(true)
            .Analyzer("analyzer")
            .DefaultOperator(Operator.OR)
            .Df("defaultField")
            .Explain()
            .Fields("field1, field2")
            .From(123)
            .LowercaseExpandedTerms(false)
            .Q("query:test")
            .Routing("route")
            .SearchType(SearchType.dfs_query_then_fetch)
            .Scroll("1h")
            .Size(321)
            .Sort("field1", SortDirection.desc)
            .Sort("field2", SortDirection.asc)
            .Timeout("1m")
            .TrackScores(true)
            .Pretty()
            .BuildCommand();


        It should_starts_with_index_type = () => result.ShouldStartWith("index/type");

        It should_contains_search_verb = () => result.ShouldContain("_search");


        It should_contain_first_parameter_AnalyzeWildcard_equals_to_true = () => result.ShouldContain("?analyze_wildcard=true");

        It should_contain_parameter_analyzer_equals_to_analyzer = () => result.ShouldContain("&analyzer=analyzer");

        It should_contain_parameter_default_operator_equals_to_OR = () => result.ShouldContain("&default_operator=OR");

        It should_contain_parameter_df_equals_to_defaultField = () => result.ShouldContain("&df=defaultField");

        It should_contain_parameter_explain_equals_to_true = () => result.ShouldContain("&explain=true");

        It should_contain_parameter_fields_equals_to_true = () => result.ShouldContain("&fields=field1, field2");

        It should_contain_parameter_from_equals_to_123 = () => result.ShouldContain("&from=123");

        It should_contain_parameter_LowercaseExpandedTerms_equals_to_false = () => result.ShouldContain("&lowercase_expanded_terms=false");

        It should_contain_parameter_q_equals_to_query_test = () => result.ShouldContain("&q=query:test");

        It should_contain_parameter_routing_equals_to_route = () => result.ShouldContain("&routing=route");

        It should_contain_parameter_search_type_equals_to_dfs_query_then_fetch = () => result.ShouldContain("&search_type=dfs_query_then_fetch");

        It should_contain_parameter_scroll_equals_to_1h = () => result.ShouldContain("&scroll=1h");

        It should_contain_parameter_sort_equals_to_field1_desc = () => result.ShouldContain("&sort=field1:desc");

        It should_contain_parameter_sort_equals_to_field2_asc = () => result.ShouldContain("&sort=field2:asc");

        It should_contain_parameter_timeout_equals_to_1m = () => result.ShouldContain("&timeout=1m");

        It should_contain_parameter_track_scores_equals_to_true = () => result.ShouldContain("&track_scores=true");

        It should_return_correct_value = () => result.ShouldEqual(@"index/type/_search?analyze_wildcard=true&analyzer=analyzer&default_operator=OR&df=defaultField&explain=true&fields=field1, field2&from=123&lowercase_expanded_terms=false&q=query:test&routing=route&search_type=dfs_query_then_fetch&scroll=1h&size=321&sort=field1:desc&sort=field2:asc&timeout=1m&track_scores=true&pretty=true");


        private static string result;
    }
}
