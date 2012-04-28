using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(GetMappingCommand))]
    class When_complete_GetMappingCommand_built
    {
        Because of = () => result = new GetMappingCommand(index: "Index", type: "Type")
            .BuildCommand();


        It should_starts_with_index_and_type = () => result.ShouldStartWith("index/type");

        It should_contains_mapping_verb = () => result.ShouldContain("_mapping");


        It should_return_correct_value = () => result.ShouldEqual(@"index/type/_mapping");


        private static string result;
    }
}
