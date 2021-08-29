using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
	[Subject(typeof(SearchScrollCommand))]
    class When_complete_SearchScrollCommand_built
	{

        Because of = () => result = new SearchScrollCommand(scrollId: "ScrollId").Scroll("5m")
			.BuildCommand();

		It should_starts_with_search_scroll_verb = () => result.ShouldStartWith("_search/scroll");

        It should_contains_scroll_id_parameter = () => result.ShouldContain("scroll_id=ScrollId");

        It should_contains_scroll_parameter = () => result.ShouldContain("scroll=5m");

        It should_return_correct_value = () => result.ShouldEqual(@"_search/scroll?scroll_id=ScrollId&scroll=5m");

		private static string result;
	}
}