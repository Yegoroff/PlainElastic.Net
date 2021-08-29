using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(IndexExistsCommand))]
    class When_complete_IndexExistsCommand_built
    {

        Because of = () => result = new IndexExistsCommand(index: "Index")
            .BuildCommand();

        It should_return_correct_value = () => result.ShouldEqual("index");


        private static string result;
    }
}
