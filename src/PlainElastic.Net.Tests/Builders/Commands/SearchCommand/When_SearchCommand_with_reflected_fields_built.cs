using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(SearchCommand))]
    class When_SearchCommand_with_reflected_fields_built
    {

        Because of = () => result = new SearchCommand(index:"Index", type:"Type")
            .Fields<FieldsTestClass>(c => c.StringProperty,
                                     c => c.BoolProperty)
            .BuildCommand();


        It should_starts_with_index_type = () => result.ShouldStartWith("index/type");

        It should_contain_first_parameter_fields_with_StringProperty_and_BoolProperty = () => result.ShouldContain("?fields=StringProperty,BoolProperty");

        It should_return_correct_value = () => result.ShouldEqual(@"index/type/_search?fields=StringProperty,BoolProperty");


        private static string result;
    }
}
