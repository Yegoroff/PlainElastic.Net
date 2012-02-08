using Machine.Specifications;

namespace PlainElastic.Net.Tests.Integration
{
    [Subject(typeof(SearchCommandBuilder))]
    class When_SearchCommand_with_reflected_fields_built
    {

        Because of = () => result = new SearchCommandBuilder(index:"Index", type:"Type")
            .Fields<FieldsTestClass>(c => c.Property1,
                                     c => c.Property2)
            .BuildCommand();


        It should_starts_with_index_type = () => result.ShouldStartWith("index/type");

        It should_contain_first_parameter_fields_with_property1_and_property2 = () => result.ShouldContain("?fields=Property1,Property2");

        It should_return_correct_value = () => result.ShouldEqual(@"index/type/_search?fields=Property1,Property2");


        private static string result;
    }
}
