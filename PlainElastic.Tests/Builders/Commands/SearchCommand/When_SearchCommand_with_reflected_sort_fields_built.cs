using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(SearchCommand))]
    class When_SearchCommand_with_reflected_sort_fields_built
    {

        Because of = () => result = new SearchCommand(index:"Index", type:"Type")
            .Sort<FieldsTestClass>(c => c.StringProperty, SortDirection.asc)
            .Sort<FieldsTestClass>(c => c.DateProperty, SortDirection.desc)
            .BuildCommand();


        It should_starts_with_index_type = () => result.ShouldStartWith("index/type");

        It should_contain_first_parameter_sort_with_StringProperty_ask = () => result.ShouldContain("?sort=StringProperty:asc");

        It should_contain_second_parameter_sort_with_DateProperty_ask = () => result.ShouldContain("&sort=DateProperty:desc");

        It should_return_correct_value = () => result.ShouldEqual(@"index/type/_search?sort=StringProperty:asc&sort=DateProperty:desc");


        private static string result;
    }
}
