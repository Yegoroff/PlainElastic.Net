using Machine.Specifications;

namespace PlainElastic.Net.Tests.Integration
{
    [Subject(typeof(GetCommandBuilder))]
    class When_GetCommand_with_reflected_fields_built
    {
        Establish context = () =>
        {
            command = new GetCommandBuilder(index:"Index", type:"Type", id:"Id");
        };


        Because of = () => result = command
            .Fields<FieldsTestClass>(c => c.Property1,
                                     c => c.Property2)
            .BuildCommand();


        It should_starts_with_index_type_and_id = () => result.ShouldStartWith("index/type/id");

        It should_contain_first_parameter_fields_with_property1_and_property2 = () => result.ShouldContain("?fields=Property1,Property2");

        It should_return_correct_value = () => result.ShouldEqual(@"index/type/id?fields=Property1,Property2");

        private static GetCommandBuilder command;
        private static string result;
    }
}
