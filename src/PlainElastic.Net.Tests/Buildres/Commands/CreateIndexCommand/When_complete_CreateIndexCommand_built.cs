using Machine.Specifications;

namespace PlainElastic.Net.Tests.Buildres.Commands
{
    [Subject(typeof(CreateIndexCommand))]
    class When_complete_CreateIndexCommand_built
    {

        Because of = () => result = new CreateIndexCommand(index: "Index")
            .BuildCommand();


        It should_return_correct_value = () => result.ShouldEqual("index");


        private static string result;
    }
}
