using Machine.Specifications;
using PlainElastic.Net.Builders.Commands;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(IndexAliasCommand))]
    class When_complete_IndexAliasCommand_built
    {

        Because of = () => result = new IndexAliasCommand(index: "Index", alias: "Index_Alias")
            .IgnoreIndices(IndexAliasCommand.IgnoreIndicesOption.None)
            .Pretty()
            .BuildCommand();

        It should_start_with_index_type = () => result.ShouldStartWith("index/");

        It should_contain_alias_command_key = () => result.ShouldStartWith("index/_alias");

        It should_contain_alias = () => result.ShouldStartWith("index/_alias/index_alias");

        It should_return_correct_value = () => result.ShouldEqual(@"index/_alias/index_alias?ignore_indices=none&pretty=true");

        private static string result;
    }
}
