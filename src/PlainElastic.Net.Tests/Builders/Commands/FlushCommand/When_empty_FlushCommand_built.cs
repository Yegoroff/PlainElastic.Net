using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(FlushCommand))]
    class When_empty_FlushCommand_built
    {

        Because of = () => result = new FlushCommand()
            .BuildCommand();

        It should_return_correct_value = () => result.ShouldEqual(@"_flush");


        private static string result;
    }
}
