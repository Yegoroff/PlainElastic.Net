using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(CloseCommand))]
    class When_complete_CloseCommand_built
    {

        Because of = () => result = new CloseCommand(index: "Index")
            .BuildCommand();

        It should_starts_with_index = () => result.ShouldStartWith("index");

        It should_contains_close_verb = () => result.ShouldContain("_close");

        It should_return_correct_value = () => result.ShouldEqual(@"index/_close");


        private static string result;
    }
}
