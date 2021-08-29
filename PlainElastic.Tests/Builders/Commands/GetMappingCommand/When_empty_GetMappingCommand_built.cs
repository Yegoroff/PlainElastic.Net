using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(GetMappingCommand))]
    class When_empty_GetMappingCommand_built
    {

        Because of = () => result = new GetMappingCommand()
            .BuildCommand();

        It should_return_correct_value = () => result.ShouldEqual(@"_mapping");


        private static string result;
    }
}
