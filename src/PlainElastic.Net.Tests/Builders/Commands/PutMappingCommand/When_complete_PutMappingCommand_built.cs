using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(PutMappingCommand))]
    class When_complete_PutMappingCommand_built
    {
        Because of = () => result = new PutMappingCommand(index: "Index", type: "Type")
            .IgnoreConflicts(true)
            .BuildCommand();


        It should_starts_with_index_and_type = () => result.ShouldStartWith("index/type");

        It should_contains_mapping_verb = () => result.ShouldContain("_mapping");

        It should_contain_ignore_conflicts_parameter_equals_to_true = () => result.ShouldContain("ignore_conflicts=true");


        It should_return_correct_value = () => result.ShouldEqual(@"index/type/_mapping?ignore_conflicts=true");


        private static string result;
    }
}
