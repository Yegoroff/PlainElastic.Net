using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(Object<>))]
    class When_Object_mapping_with_ObjectProperty_built
    {
        Because of = () => result = new Object<FieldsTestClass>()
                                                .Field("TestObject")
                                                .Properties(p => p
                                                    .Object(f => f.ObjectProperty, opt => opt.IncludeInAll(false).Enabled(true))
                                                )
                                                .ToString();

        It should_start_from_specified_field_name = () => result.ShouldStartWith("'TestObject': {".AltQuote());

        It should_contain_object_type_declaration_part = () => result.ShouldContain("'type': 'object'".AltQuote());

        It should_contain_properties_mapping_part = () => result.ShouldContain("'properties': { ".AltQuote());

        It should_contain_binary_property_mapping_part = () => result.ShouldContain("'ObjectProperty': { 'type': 'object','include_in_all': false,'enabled': true }".AltQuote());


        It should_generate_correct_JSON_result = () => result.ShouldEqual(("'TestObject': { " +
                                                                            "'type': 'object'," +
                                                                            "'properties': { " +
                                                                               "'ObjectProperty': { 'type': 'object','include_in_all': false,'enabled': true } " +
                                                                            "} " +
                                                                          "}").AltQuote());

        private static string result;
    }
}
