using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(StatusCommand))]
    class When_StatusCommand_with_multiple_indexes_built
    {

        Because of = () => result = new StatusCommand(indexes: new[] { "Index1", "Index2" })
            .BuildCommand();


        It should_starts_with_index = () => result.ShouldStartWith("index1,index2/");

        It should_contains_refresh_verb = () => result.ShouldContain("_status");

        It should_return_correct_value = () => result.ShouldEqual(@"index1,index2/_status");


        private static string result;
    }
}
