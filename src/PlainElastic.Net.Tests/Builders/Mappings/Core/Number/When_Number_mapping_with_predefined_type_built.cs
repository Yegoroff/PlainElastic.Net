using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(NumberMap<>))]
    class When_Number_mapping_with_predefined_type_built
    {
        Because of = () => result = new NumberMap<FieldsTestClass>()
                                                .Field(doc => doc.BoolProperty)
                                                .Type(NumberMappingType.Integer)
                                                .ToString();


        It should_start_from_specified_field_name = () => result.ShouldStartWith("'BoolProperty': {".AltQuote());

        It should_contain_specified_type_declaration_part = () => result.ShouldContain("'type': 'integer'".AltQuote());


        It should_generate_correct_JSON_result = () => result.ShouldEqual(("'BoolProperty': { 'type': 'integer' }").AltQuote());

        private static string result;
    }
}
