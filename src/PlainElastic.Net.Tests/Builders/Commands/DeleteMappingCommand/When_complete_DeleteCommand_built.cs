using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(DeleteMappingCommand))]
    class When_complete_DeleteMappingCommand_built
    {

        Because of = () => result = new DeleteMappingCommand(index: "Index", type: "Type")
            .BuildCommand();


        It should_starts_with_index_type = () => result.ShouldStartWith("index/type");

        It should_return_correct_value = () => result.ShouldEqual(@"index/type");


        private static string result;
    }
}
