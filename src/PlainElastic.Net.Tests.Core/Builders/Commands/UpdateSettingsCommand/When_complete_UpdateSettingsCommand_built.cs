using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(UpdateSettingsCommand))]
    class When_complete_UpdateSettingsCommand_built
    {

        Because of = () => result = new UpdateSettingsCommand(index: "Index")
            .BuildCommand();

        It should_starts_with_index = () => result.ShouldStartWith("index");

        It should_contains_settings_verb = () => result.ShouldContain("_settings");

        It should_return_correct_value = () => result.ShouldEqual(@"index/_settings");


        private static string result;
    }
}
