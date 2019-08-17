using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(Object<>))]
    class When_Object_with_enum_property_mapping_built
    {
        Because of = () => result = new Object<FieldsTestClass>()
                                                .Field("TestObject")
                                                .Properties(p => p
                                                    .Number(f => f.EnumProperty, opt => opt.Boost(5))
                                                )
                                                .ToString();

        It should_start_from_specified_field_name = () => result.ShouldStartWith("'TestObject': {".AltQuote());

        It should_contain_object_type_declaration_part = () => result.ShouldContain("'type': 'object'".AltQuote());

        It should_contain_properties_part = () => result.ShouldContain("'properties': { ".AltQuote());

        It should_contain_properties_mapping_part = () => result.ShouldContain("'properties': { 'EnumProperty': { 'type': 'long','boost': 5 } }".AltQuote());

        It should_generate_correct_JSON_result = () => result.ShouldEqual("'TestObject': { 'type': 'object','properties': { 'EnumProperty': { 'type': 'long','boost': 5 } } }".AltQuote());

        private static string result;
    }
}
