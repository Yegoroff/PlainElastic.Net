using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Buildres.Mappings
{
    [Subject(typeof(MultiField<>))]
    class When_complete_MultiField_mapping_built
    {
        Because of = () => result = new MultiField<FieldsTestClass>()
                                                .Field(doc => doc.StringProperty)
                                                .Fields(f => f
                                                    .String("first", s=>s.Index(IndexState.analyzed))
                                                    .String("second", s => s.Index(IndexState.not_analyzed))
                                                )
                                                .ToString();


        It should_start_from_specified_field_name = () => result.ShouldStartWith("'StringProperty': {".AltQuote());

        It should_contain_multi_field_type_declaration_part = () => result.ShouldContain("'type': 'multi_field'".AltQuote());

        It should_contain_fields_part = () => result.ShouldContain("'fields': {".AltQuote());

        It should_contain_first_string_property_mapping_part = () => result.ShouldContain("'first': { 'type': 'string','index': 'analyzed'".AltQuote());

        It should_contain_second_string_property_mapping_part = () => result.ShouldContain("'second': { 'type': 'string','index': 'not_analyzed'".AltQuote());


        It should_generate_correct_JSON_result = () => result.ShouldEqual(("'StringProperty': { " +
                                                                            "'type': 'multi_field'," +
                                                                            "'fields': { " +
                                                                                "'first': { 'type': 'string','index': 'analyzed' }," +
                                                                                "'second': { 'type': 'string','index': 'not_analyzed' } " +                                                                           
                                                                            "} " +
                                                                           "}").AltQuote());

        private static string result;
    }
}
