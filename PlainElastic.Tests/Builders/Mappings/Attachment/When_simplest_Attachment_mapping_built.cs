using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(Attachment<>))]
    class When_simplest_Attachment_mapping_built
    {
        Because of = () => result = new Attachment<FieldsTestClass>()
                                                .Field(doc => doc.StringProperty)
                                                .ToString();


        It should_start_from_specified_field_name = () => result.ShouldStartWith("'StringProperty': {".AltQuote());

        It should_contain_multi_field_type_declaration_part = () => result.ShouldContain("'type': 'attachment'".AltQuote());

 
        It should_generate_correct_JSON_result = () => result.ShouldEqual(("'StringProperty': { 'type': 'attachment' }").AltQuote());

        private static string result;
    }
}
