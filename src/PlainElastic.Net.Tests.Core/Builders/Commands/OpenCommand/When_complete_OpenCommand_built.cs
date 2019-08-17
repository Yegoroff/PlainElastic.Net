using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(OpenCommand))]
    class When_complete_OpenCommand_built
    {

        Because of = () => result = new OpenCommand(index: "Index")
            .BuildCommand();

        It should_starts_with_index = () => result.ShouldStartWith("index");

        It should_contains_open_verb = () => result.ShouldContain("_open");

        It should_return_correct_value = () => result.ShouldEqual(@"index/_open");


        private static string result;
    }
}
