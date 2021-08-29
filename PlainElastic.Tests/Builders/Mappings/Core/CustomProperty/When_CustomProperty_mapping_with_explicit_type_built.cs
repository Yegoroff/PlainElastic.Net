using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(CustomPropertyMap<>))]
    class When_CustomProperty_mapping_with_explicit_type_built
    {
        Because of = () => result = new CustomPropertyMap<FieldsTestClass>("FieldName", typeof(string))
                                                .Type("boolean")
                                                .ToString();


        It should_start_from_specified_field_name = () => result.ShouldStartWith("'FieldName': {".AltQuote());

        It should_contain_string_type_declaration_part = () => result.ShouldContain("'type': 'boolean'".AltQuote());


        It should_generate_correct_JSON_result = () =>
            result.ShouldEqual(("'FieldName': { 'type': 'boolean' }").AltQuote());
    

        private static string result;
    }
}
