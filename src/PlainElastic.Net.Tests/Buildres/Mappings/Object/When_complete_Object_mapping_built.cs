using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Buildres.Mappings
{
    [Subject(typeof(Object<>))]
    class When_complete_Object_mapping_built
    {
        Because of = () => result = new Object<FieldsTestClass>()
                                                .Dynamic(false)
                                                .IncludeInAll(false)
                                                .Field("TestObject")
                                                .Enabled(true)
                                                .Path("TestObject.Path")
                                                .Properties(p => p
                                                    .Binary(b => b.ObjectProperty)
                                                    .Boolean(b => b.BoolProperty)
                                                    .Date( d=> d.DateProperty)
                                                    .Number( n=> n.IntProperty)
                                                    .String(f => f.StringProperty)
                                                )
                                                .ToString();

        It should_start_from_specified_field_name = () => result.ShouldStartWith("'TestObject': {".AltQuote());

        It should_contain_object_type_declaration_part = () => result.ShouldContain("'type': 'object'".AltQuote());

        It should_contain_dynamic_part = () => result.ShouldContain("'dynamic': false".AltQuote());

        It should_contain_include_in_all_part = () => result.ShouldContain("'include_in_all': false".AltQuote());

        It should_contain_enabled_part = () => result.ShouldContain("'enabled': true".AltQuote());

        It should_contain_path_part = () => result.ShouldContain("'path': 'TestObject.Path'".AltQuote());

        It should_contain_properties_part = () => result.ShouldContain("'properties': { ".AltQuote());

        It should_contain_properties_mapping_part = () => result.ShouldContain("'properties': { ".AltQuote());

        It should_contain_binary_property_mapping_part = () => result.ShouldContain("'ObjectProperty': { 'type': 'binary' }".AltQuote());

        It should_contain_bool_property_mapping_part = () => result.ShouldContain("'BoolProperty': { 'type': 'boolean' }".AltQuote());

        It should_contain_date_property_mapping_part = () => result.ShouldContain("'DateProperty': { 'type': 'date' }".AltQuote());

        It should_contain_int_property_mapping_part = () => result.ShouldContain("'IntProperty': { 'type': 'integer' }".AltQuote());

        It should_contain_string_property_mapping_part = () => result.ShouldContain("'StringProperty': { 'type': 'string' }".AltQuote());


        It should_generate_correct_JSON_result = () => result.ShouldEqual(("'TestObject': {" +
                                                                            " 'type': 'object'," +
                                                                            "'dynamic': false," +
                                                                            "'include_in_all': false," +
                                                                            "'enabled': true," +
                                                                            "'path': 'TestObject.Path'," +
                                                                            "'properties': { " +
                                                                                "'ObjectProperty': { 'type': 'binary' }," +
                                                                                "'BoolProperty': { 'type': 'boolean' }," +
                                                                                "'DateProperty': { 'type': 'date' }," +
                                                                                "'IntProperty': { 'type': 'integer' }," +
                                                                                "'StringProperty': { 'type': 'string' } " +
                                                                            "} " +
                                                                          "}").AltQuote());

        private static string result;
    }
}
