using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(RootObject<>))]
    class When_RootObject_mapping_with_NestedProperty_built
    {
        Because of = () => result = new RootObject<FieldsTestClass>("TestObject")
                                                .Properties(p => p.NestedObject(f => f.ObjectProperty, opt => opt.IncludeInAll(false).Enabled(true)))
                                                .ToString();

        It should_start_from_specified_type_name = () => result.ShouldStartWith("'TestObject': {".AltQuote());

        It should_not_contain_object_type_declaration_part = () => result.ShouldNotContain("'type': 'object'".AltQuote());

        It should_contain_properties_mapping_part = () => result.ShouldContain("'properties': { ".AltQuote());

        It should_contain_binary_property_mapping_part = () => result.ShouldContain("'ObjectProperty': { 'type': 'nested','include_in_all': false,'enabled': true }".AltQuote());


        It should_generate_correct_JSON_result = () => result.ShouldEqual(("'TestObject': { " +
                                                                            "'properties': { " +
                                                                               "'ObjectProperty': { 'type': 'nested','include_in_all': false,'enabled': true } " +
                                                                            "} " +
                                                                          "}").AltQuote());

        private static string result;
    }
}
