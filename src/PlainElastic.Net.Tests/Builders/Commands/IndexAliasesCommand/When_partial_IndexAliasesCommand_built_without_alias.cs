using Machine.Specifications;
using PlainElastic.Net.Builders.Commands;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(IndexAliasesCommand))]
    class When_partial_IndexAliasesCommand_built_without_alias
    {

        Because of = () => result = new IndexAliasesCommand(index: "Index")
            .Pretty()
            .BuildCommand();

        It should_contain_alias_command_key = () => result.ShouldStartWith("index/_aliases");

        It should_return_correct_value = () => result.ShouldEqual(@"index/_aliases?pretty=true");

        private static string result;
    }
}