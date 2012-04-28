using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(MultiField<>))]
    class When_complete_MultiField_mapping_built
    {
        Because of = () => result = new MultiField<FieldsTestClass>()
                                                .Field(doc => doc.StringProperty)
                                                .Fields(f => f
                                                    .Binary("binaryField")
                                                    .Boolean("boolField")
                                                    .Date("dateField")
                                                    .Number("numberField", n => n.Type(NumberMappingType.Integer))
                                                    .String("stringField", s => s.Index(IndexState.analyzed))
                                                )
                                                .ToString();


        It should_start_from_specified_field_name = () => result.ShouldStartWith("'StringProperty': {".AltQuote());

        It should_contain_multi_field_type_declaration_part = () => result.ShouldContain("'type': 'multi_field'".AltQuote());

        It should_contain_fields_part = () => result.ShouldContain("'fields': {".AltQuote());

        It should_contain_binary_property_mapping_part = () => result.ShouldContain("'binaryField': { 'type': 'binary' }".AltQuote());

        It should_contain_boolean_property_mapping_part = () => result.ShouldContain("'boolField': { 'type': 'boolean' }".AltQuote());

        It should_contain_date_property_mapping_part = () => result.ShouldContain("'dateField': { 'type': 'date' }".AltQuote());

        It should_contain_integer_property_mapping_part = () => result.ShouldContain("'numberField': { 'type': 'integer' }".AltQuote());

        It should_contain_string_property_mapping_part = () => result.ShouldContain("'stringField': { 'type': 'string','index': 'analyzed' }".AltQuote());


        It should_generate_correct_JSON_result = () => result.ShouldEqual(("'StringProperty': { " +
                                                                            "'type': 'multi_field'," +
                                                                            "'fields': { " +
                                                                                "'binaryField': { 'type': 'binary' }," +
                                                                                "'boolField': { 'type': 'boolean' }," +
                                                                                "'dateField': { 'type': 'date' }," +
                                                                                "'numberField': { 'type': 'integer' }," +
                                                                                "'stringField': { 'type': 'string','index': 'analyzed' } " +
                                                                            "} " +
                                                                           "}").AltQuote());

        private static string result;
    }
}
