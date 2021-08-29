using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(FlushCommand))]
    class When_complete_FlushCommand_built
    {

        Because of = () => result = new FlushCommand(index: "Index", type: "Type")
            .Refresh(true)
            .BuildCommand();


        It should_starts_with_index_and_type = () => result.ShouldStartWith("index/type");

        It should_contains_flush_verb = () => result.ShouldContain("_flush");

        It should_contains_refresh_parameter_equals_to_true = () => result.ShouldContain("refresh=true");

        It should_return_correct_value = () => result.ShouldEqual(@"index/type/_flush?refresh=true");


        private static string result;
    }
}
