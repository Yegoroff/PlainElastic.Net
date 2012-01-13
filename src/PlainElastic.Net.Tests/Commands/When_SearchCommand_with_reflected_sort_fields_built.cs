using Machine.Specifications;

namespace PlainElastic.Net.Tests.Integration
{
    [Subject(typeof(SearchCommandBuilder))]
    class When_SearchCommand_with_reflected_sort_fields_built
    {

        Because of = () => result = new SearchCommandBuilder(index:"Index", type:"Type")
            .Sort<FieldsTestClass>(c => c.Property1, SortDirection.ask)
            .BuildCommand();


        It should_starts_with_index_type = () => result.ShouldStartWith("index/type");

        It should_contain_first_parameter_sort_with_property1_ask = () => result.ShouldContain("?sort=property1:ask");

        It should_return_correct_value = () => result.ShouldEqual(@"index/type?sort=property1:ask");


        private static string result;
    }
}
