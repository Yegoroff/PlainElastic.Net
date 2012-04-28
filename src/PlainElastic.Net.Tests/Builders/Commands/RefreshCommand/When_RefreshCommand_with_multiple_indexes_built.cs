using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(RefreshCommand))]
    class When_RefreshCommand_with_multiple_indexes_built
    {

        Because of = () => result = new RefreshCommand(indexes:new[] { "Index1", "Index2" })
            .BuildCommand();


        It should_starts_with_index = () => result.ShouldStartWith("index1,index2/");

        It should_contains_refresh_verb = () => result.ShouldContain("_refresh");

        It should_return_correct_value = () => result.ShouldEqual(@"index1,index2/_refresh");


        private static string result;
    }
}
