using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(NumberMap<>))]
    class When_Number_mapping_for_enum_type_built
    {
        Because of = () => result = new NumberMap<FieldsTestClass>()
                                                .Field(doc => doc.EnumProperty)
                                                .ToString();


        It should_start_from_specified_field_name = () => result.ShouldStartWith("'EnumProperty': {".AltQuote());

        It should_contain_long_type_declaration_part = () => result.ShouldContain("'type': 'long'".AltQuote());

        It should_generate_correct_JSON_result = () => result.ShouldEqual(("'EnumProperty': { 'type': 'long' }").AltQuote());

        private static string result;
    }
}
