using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(RefreshCommand))]
    class When_empty_RefreshCommand_built
    {

        Because of = () => result = new RefreshCommand()
            .BuildCommand();

        It should_return_correct_value = () => result.ShouldEqual(@"_refresh");


        private static string result;
    }
}
