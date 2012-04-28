using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(NumberMap<>))]
    class When_Number_mapping_for_bool_type_built
    {
        Because of = () => result = new NumberMap<FieldsTestClass>()
                                                .Field(doc => doc.BoolProperty)
                                                .ToString();


        It should_start_from_specified_field_name = () => result.ShouldStartWith("'BoolProperty': {".AltQuote());

        It should_contain_byte_type_declaration_part = () => result.ShouldContain("'type': 'byte'".AltQuote());


        It should_generate_correct_JSON_result = () => result.ShouldEqual(("'BoolProperty': { 'type': 'byte' }").AltQuote());

        private static string result;
    }
}
