using Machine.Specifications;

namespace PlainElastic.Net.Tests.Buildres.Commands
{
    [Subject(typeof(BulkCommand))]
    class When_complete_BulkCommand_built
    {

        Because of = () => result = new BulkCommand(index: "Index", type: "Type")
            .Consistency(WriteConsistency.quorum)
            .Refresh(true)
            .BuildCommand();


        It should_starts_with_index_type = () => result.ShouldStartWith("index/type");

        It should_contains_bulk_verb = () => result.ShouldContain("_bulk");

        It should_contain_parameter_consistency_equals_to_analyzer = () => result.ShouldContain("?consistency=quorum");

        It should_contain_parameter_refresh_equals_to_true = () => result.ShouldContain("&refresh=true");

        It should_return_correct_value = () => result.ShouldEqual("index/type/_bulk?consistency=quorum&refresh=true");


        private static string result;
    }
}
