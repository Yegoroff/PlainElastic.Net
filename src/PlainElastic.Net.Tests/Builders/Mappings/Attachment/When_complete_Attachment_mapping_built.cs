using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(Attachment<>))]
    class When_complete_Attachment_mapping_built
    {
        Because of = () => result = new Attachment<FieldsTestClass>()
                                                .Field(doc => doc.StringProperty)
                                                .Fields(f => f
                                                    .String("first", s => s.Index(IndexState.analyzed))
                                                    .Boolean("second", s => s.Store(false))
                                                )
                                                .ToString();


        It should_start_from_specified_field_name = () => result.ShouldStartWith("'StringProperty': {".AltQuote());

        It should_contain_multi_field_type_declaration_part = () => result.ShouldContain("'type': 'attachment'".AltQuote());

        It should_contain_fields_part = () => result.ShouldContain("'fields': {".AltQuote());

        It should_contain_first_string_property_mapping_part = () => result.ShouldContain("'first': { 'type': 'string','index': 'analyzed' }".AltQuote());

        It should_contain_second_string_property_mapping_part = () => result.ShouldContain("'second': { 'type': 'boolean','store': false }".AltQuote());


        It should_generate_correct_JSON_result = () => result.ShouldEqual(("'StringProperty': { " +
                                                                            "'type': 'attachment'," +
                                                                            "'fields': { " +
                                                                                "'first': { 'type': 'string','index': 'analyzed' }," +
                                                                                "'second': { 'type': 'boolean','store': false } " +
                                                                            "} " +
                                                                           "}").AltQuote());

        private static string result;
    }
}
