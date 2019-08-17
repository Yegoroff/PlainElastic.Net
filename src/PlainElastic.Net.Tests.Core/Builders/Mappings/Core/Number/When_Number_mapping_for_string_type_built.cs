using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(NumberMap<>))]
    class When_Number_mapping_for_string_type_built
    {
        Because of = () => result = new NumberMap<FieldsTestClass>()
                                                .Field(doc => doc.StringProperty)
                                                .Fields(f => f.String("multi_field"))
                                                .ToString();


        It should_start_from_specified_field_name = () => result.ShouldStartWith("'StringProperty': {".AltQuote());

        It should_contain_double_type_declaration_part = () => result.ShouldContain("'type': 'double'".AltQuote());

        It should_generate_correct_JSON_result = () => result.ShouldEqual(("'StringProperty': { 'type': 'double','fields': { 'multi_field': { 'type': 'string' } } }").AltQuote());

        It should_contain_fields_part = () => result.ShouldContain("'fields': { 'multi_field': { 'type': 'string' } }".AltQuote());

        private static string result;
    }
}
