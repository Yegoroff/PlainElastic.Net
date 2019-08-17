using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(SearchCommand))]
    class When_SearchCommand_with_default_sort_direction_built
    {

        Because of = () => result = new SearchCommand(index:"Index", type:"Type")
            .Sort("name")
            .BuildCommand();


        It should_starts_with_index_type = () => result.ShouldStartWith("index/type");

        It should_contain_first_parameter_sort_with_name = () => result.ShouldContain("?sort=name");

        It should_return_correct_value = () => result.ShouldEqual(@"index/type/_search?sort=name");


        private static string result;
    }
}
