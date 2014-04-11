using Machine.Specifications;
using PlainElastic.Net.Builders.Commands;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(IndexAliasCommand))]
    class When_partial_IndexAliasCommand_built_without_alias
    {

        Because of = () => result = new IndexAliasCommand(index: "Index")
            .IgnoreIndices(IndexAliasCommand.IgnoreIndicesOption.None)
            .Pretty()
            .BuildCommand();

        It should_contain_alias_command_key = () => result.ShouldStartWith("index/_aliases");

        It should_return_correct_value = () => result.ShouldEqual(@"index/_aliases?ignore_indices=none&pretty=true");

        private static string result;
    }
}