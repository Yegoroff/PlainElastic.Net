using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(RefreshCommand))]
    class When_complete_RefreshCommand_built
    {

        Because of = () => result = new RefreshCommand(index: "Index")
            .BuildCommand();


        It should_starts_with_index = () => result.ShouldStartWith("index");

        It should_contains_refresh_verb = () => result.ShouldContain("_refresh");

        It should_return_correct_value = () => result.ShouldEqual(@"index/_refresh");


        private static string result;
    }
}
