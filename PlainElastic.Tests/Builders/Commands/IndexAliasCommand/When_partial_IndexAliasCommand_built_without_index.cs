using Machine.Specifications;
using PlainElastic.Net.Builders.Commands;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(IndexAliasCommand))]
    class When_partial_IndexAliasCommand_built_without_index
    {

        Because of = () => result = new IndexAliasCommand(alias: "Index_Alias")
            .IgnoreIndices(IndexAliasCommand.IgnoreIndicesOption.None)
            .Pretty()
            .BuildCommand();

        It should_contain_alias_command_key = () => result.ShouldStartWith("_alias");

        It should_contain_alias = () => result.ShouldStartWith("_alias/index_alias");

        It should_return_correct_value = () => result.ShouldEqual(@"_alias/index_alias?ignore_indices=none&pretty=true");

        private static string result;
    }
}