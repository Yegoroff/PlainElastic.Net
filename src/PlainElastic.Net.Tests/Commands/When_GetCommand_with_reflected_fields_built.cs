using Machine.Specifications;

namespace PlainElastic.Net.Tests.Integration
{
    [Subject(typeof(GetCommandBuilder))]
    class When_GetCommand_with_reflected_fields_built
    {
        Establish context = () =>
        {
            command = new GetCommandBuilder().ForIndex("Index").OfType("Type").WithId("Id");
        };


        Because of = () => result = command
            .Fields<FieldsTestClass>(c => c.Property1,
                                     c => c.Property2)
            .BuildCommand();


        It should_starts_with_index_type_and_id = () => result.ShouldStartWith("/index/type/id");

        It should_contain_first_parameter_fields_with_property1_and_property2 = () => result.ShouldContain("?fields=property1,property2");

        It should_return_correct_value = () => result.ShouldEqual(@"/index/type/id?fields=property1,property2");

        private static GetCommandBuilder command;
        private static string result;
    }

    public class FieldsTestClass
    {
        public string Property1 { get; set; }
        public bool Property2 { get; set; }
    }

}
