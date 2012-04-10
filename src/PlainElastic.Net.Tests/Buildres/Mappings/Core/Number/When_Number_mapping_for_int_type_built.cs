using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Buildres.Mappings
{
    [Subject(typeof(NumberMap<>))]
    class When_Number_mapping_for_int_type_built
    {
        Because of = () => result = new NumberMap<FieldsTestClass>()
                                                .Field(doc => doc.IntProperty)
                                                .ToString();


        It should_start_from_specified_field_name = () => result.ShouldStartWith("'IntProperty': {".AltQuote());

        It should_contain_double_type_declaration_part = () => result.ShouldContain("'type': 'integer'".AltQuote());

        It should_generate_correct_JSON_result = () => result.ShouldEqual(("'IntProperty': { 'type': 'integer' }").AltQuote());

        private static string result;
    }
}
