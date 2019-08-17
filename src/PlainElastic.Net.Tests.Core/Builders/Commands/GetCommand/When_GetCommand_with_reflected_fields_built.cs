using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(GetCommand))]
    class When_GetCommand_with_reflected_fields_built
    {
        Establish context = () =>
        {
            command = new GetCommand(index:"Index", type:"Type", id:"Id");
        };


        Because of = () => result = command
            .Fields<FieldsTestClass>(c => c.StringProperty,
                                     c => c.BoolProperty)
            .BuildCommand();


        It should_starts_with_index_type_and_id = () => result.ShouldStartWith("index/type/id");

        It should_contain_first_parameter_fields_with_StringProperty_and_BoolProperty = () => result.ShouldContain("?fields=StringProperty,BoolProperty");

        It should_return_correct_value = () => result.ShouldEqual(@"index/type/id?fields=StringProperty,BoolProperty");

        private static GetCommand command;
        private static string result;
    }
}
