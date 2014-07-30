using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(Object<>))]
    class When_simplest_RootObject_mapping_built
    {
        Because of = () => result = new RootObject<FieldsTestClass>()
                                                .Field("TestObject")
                                                .ToString();

        It should_start_from_specified_field_name = () => result.ShouldStartWith("'TestObject': {".AltQuote());

        It should_contain_object_type_declaration_part = () => result.ShouldContain("'type': 'object'".AltQuote());


        It should_generate_correct_JSON_result = () => result.ShouldEqual(("'TestObject': { 'type': 'object' }").AltQuote());

        private static string result;
    }
}
