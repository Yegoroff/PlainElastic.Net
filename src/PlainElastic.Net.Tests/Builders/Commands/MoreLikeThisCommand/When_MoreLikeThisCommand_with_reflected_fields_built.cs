using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(MoreLikeThisCommand))]
    class When_MoreLikeThisCommand_with_reflected_fields_built
    {
        Establish context = () =>
        {
            command = new MoreLikeThisCommand(index:"Index", type:"Type", id:"Id");
        };


        Because of = () => result = command
            .MltFields<FieldsTestClass>(c => c.StringProperty,
                                     c => c.BoolProperty)
            .BuildCommand();


        It should_starts_with_index_type_and_id = () => result.ShouldStartWith("index/type/id/_mlt");

        It should_contain_first_parameter_fields_with_StringProperty_and_BoolProperty = () => result.ShouldContain("?mlt_fields=StringProperty,BoolProperty");

        It should_return_correct_value = () => result.ShouldEqual(@"index/type/id/_mlt?mlt_fields=StringProperty,BoolProperty");

        private static MoreLikeThisCommand command;
        private static string result;
    }
}
