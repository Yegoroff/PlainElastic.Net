using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
	[Subject(typeof(StatusCommand))]
	class When_complete_StatusCommand_built
	{

		Because of = () => result = new StatusCommand(index: "Index").Recovery(true).Snapshot(true)
			.BuildCommand();

		It should_starts_with_index = () => result.ShouldStartWith("index");

		It should_contains_status_verb = () => result.ShouldContain("_status");

        It should_contains_recovery_parameter = () => result.ShouldContain("recovery=true");

        It should_contains_snapshot_parameter = () => result.ShouldContain("snapshot=true");

        It should_return_correct_value = () => result.ShouldEqual(@"index/_status?recovery=true&snapshot=true");


		private static string result;
	}
}