using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(NumberMap<>))]
    class When_Number_mapping_with_field_name_and_predefined_type_built
    {
        Because of = () => result = new NumberMap<FieldsTestClass>()
                                                .Type(NumberMappingType.Float)
                                                .Field("NumberField")
                                                .ToString();


        It should_start_from_specified_field_name = () => result.ShouldStartWith("'NumberField': {".AltQuote());

        It should_contain_specified_type_declaration_part = () => result.ShouldContain("'type': 'float'".AltQuote());


        It should_generate_correct_JSON_result = () => result.ShouldEqual(("'NumberField': { 'type': 'float' }").AltQuote());

        private static string result;
    }
}
