using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(GetCommand))]
    class When_complete_GetCommand_built
    {

        Because of = () => result = new GetCommand(index:"Index", type:"Type", id: "Id")
            .Realtime(false)
            .Fields("field1,field2")
            .Routing("route")
            .Preference(GetPrefernce.custom, "preference")
            .Refresh(true)
            .Pretty()
            
            .BuildCommand();


        It should_starts_with_index_type_and_id = () => result.ShouldStartWith("index/type/id");

        It should_contain_first_parameter_realtime_equals_to_false = () => result.ShouldContain("?realtime=false");

        It should_contain_parameter_fields_with_filed2_and_field2 = () => result.ShouldContain("&fields=field1,field2");

        It should_contain_parameter_routing_equals_to_route = () => result.ShouldContain("&routing=route");

        It should_contain_parameter_preference_equals_to_preference = () => result.ShouldContain("&preference=preference");

        It should_contain_parameter_refresh_equals_to_true = () => result.ShouldContain("&refresh=true");

        It should_return_correct_value = () => result.ShouldEqual(@"index/type/id?realtime=false&fields=field1,field2&routing=route&preference=preference&refresh=true&pretty=true");


        private static string result;
    }
}
