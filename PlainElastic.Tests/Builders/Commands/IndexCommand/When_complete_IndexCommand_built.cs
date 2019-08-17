using System;
using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(IndexCommand))]
    class When_complete_IndexCommand_built
    {

        Because of = () => result = new IndexCommand(index:"Index", type:"Type", id: "Id")
            .Consistency(WriteConsistency.quorum)
            .OperationType(IndexOperation.create)
            .Parent("parentId")
            .Percolate(PercolateMode.Color, "green" )
            .Refresh(true)
            .Replication(DocumentReplication.async)           
            .Routing("route")
            .TTL("1h")
            .Timeout("1d")
            .Timestamp(new DateTime(2007, 10, 8))
            .VersionType(VersionType.external)
            .Version(3)
            .Pretty()
            .BuildCommand();


        It should_starts_with_index_type_and_id = () => result.ShouldStartWith("index/type/id");

        It should_contain_first_parameter_consistency_equals_to_quorum = () => result.ShouldContain("?consistency=quorum");

        It should_contain_parameter_operationType_equal_to_create = () => result.ShouldContain("&op_type=create");

        It should_contain_parameter_Parent_equals_to_parentId = () => result.ShouldContain("&parent=parentId");

        It should_contain_parameter_Percolate_equals_to_color_green = () => result.ShouldContain("&percolate=color:green");

        It should_contain_parameter_refresh_equals_to_true = () => result.ShouldContain("&refresh=true");

        It should_contain_parameter_replication_equals_to_async = () => result.ShouldContain("&replication=async");

        It should_contain_parameter_routing_equals_to_route = () => result.ShouldContain("&routing=route");

        It should_contain_parameter_ttl_equals_to_1h = () => result.ShouldContain("&ttl=1h");

        It should_contain_parameter_timeout_equals_to_1d = () => result.ShouldContain("&timeout=1d");

        It should_contain_parameter_timestamp_equals_to_2007_10_08 = () => result.ShouldContain("&timestamp=2007-10-08T00:00:00");

        It should_contain_parameter_version_tyoe_equals_to_external = () => result.ShouldContain("&version_type=external");

        It should_contain_parameter_version_equals_to_3 = () => result.ShouldContain("&version=3");

        It should_return_correct_value = () => result.ShouldEqual("index/type/id?consistency=quorum&op_type=create&parent=parentId&percolate=color:green&refresh=true&replication=async&routing=route&ttl=1h&timeout=1d&timestamp=2007-10-08T00:00:00&version_type=external&version=3&pretty=true");


        private static string result;
    }
}
