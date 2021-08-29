using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(OptimizeCommand))]
    class When_complete_OptimizeCommand_built
    {

        Because of = () => result = new OptimizeCommand(index: "Index", type: "Type")
            .MaxNumSegments(10)
            .OnlyExpungeDeletes(true)
            .Refresh(false)
            .Flush(true)
            .WaitForMerge(false)
            .BuildCommand();

        It should_starts_with_index_and_type = () => result.ShouldStartWith("index/type");

        It should_contains_optimize_verb = () => result.ShouldContain("_optimize");

        It should_contain_parameter_max_num_segments_equals_to_10 = () => result.ShouldContain("?max_num_segments=10");

        It should_contain_parameter_only_expunge_deletes_equals_to_true = () => result.ShouldContain("&only_expunge_deletes=true");

        It should_contain_parameter_refresh_equals_to_false = () => result.ShouldContain("&refresh=false");

        It should_contain_parameter_flush_equals_to_true = () => result.ShouldContain("&flush=true");

        It should_contain_parameter_wait_for_merge_equals_to_false = () => result.ShouldContain("&wait_for_merge=false");


        It should_return_correct_value = () => result.ShouldEqual(@"index/type/_optimize?max_num_segments=10&only_expunge_deletes=true&refresh=false&flush=true&wait_for_merge=false");


        private static string result;
    }
}
