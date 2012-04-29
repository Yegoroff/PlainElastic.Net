using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(DeleteCommand))]
    class When_complete_DeleteCommand_built
    {

        Because of = () => result = new DeleteCommand(index:"Index", type:"Type", id: "Id")
            .Consistency(WriteConsistency.quorum)            
            .Parent("parentId")            
            .Refresh(true)
            .Replication(DocumentReplication.async)           
            .Routing("route")
            .Version(3)
            .Pretty()
            .BuildCommand();


        It should_starts_with_index_type_and_id = () => result.ShouldStartWith("index/type/id");

        It should_contain_first_parameter_consistency_equals_to_quorum = () => result.ShouldContain("?consistency=quorum");

        It should_contain_parameter_parent_equals_to_parentId = () => result.ShouldContain("&parent=parentId");

        It should_contain_parameter_refresh_equals_to_true = () => result.ShouldContain("&refresh=true");

        It should_contain_parameter_replication_equals_to_async = () => result.ShouldContain("&replication=async");

        It should_contain_parameter_routing_equals_to_route = () => result.ShouldContain("&routing=route");

        It should_contain_parameter_version_equals_to_3 = () => result.ShouldContain("&version=3");

        It should_return_correct_value = () => result.ShouldEqual(@"index/type/id?consistency=quorum&parent=parentId&refresh=true&replication=async&routing=route&version=3&pretty=true");


        private static string result;
    }
}
