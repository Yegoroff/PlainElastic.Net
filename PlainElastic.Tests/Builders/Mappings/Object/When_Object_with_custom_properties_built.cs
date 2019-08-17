using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(Object<>))]
    class When_Object_with_custom_properties_built
    {
        Establish context = () => {

            properties = new[] {
                    new CustomPropertyMap<FieldsTestClass>("First", typeof(string)).When(true, p=>p.Analyzer(DefaultAnalyzers.simple).Store(true)),
                    new CustomPropertyMap<FieldsTestClass>("Second", typeof(int)).When(true, p=>p.Boost(10).Store(true))
                };

        };

        Because of = () => result = new Object<FieldsTestClass>()
                                                .Field("TestObject")
                                                .Properties(p=>p 
                                                    .CustomProperties( properties )
                                                )
                                                .ToString();

        It should_start_from_specified_field_name = () => result.ShouldStartWith("'TestObject': {".AltQuote());

        It should_contain_object_type_declaration_part = () => result.ShouldContain("'type': 'object'".AltQuote());

        It should_contain_first_custom_property_declaration_part = () => result.ShouldContain("'First': { 'type': 'string','analyzer': 'simple','store': true }".AltQuote());

        It should_contain_second_custom_property_declaration_part = () => result.ShouldContain("'Second': { 'type': 'integer','boost': 10,'store': true }".AltQuote());


        It should_generate_correct_JSON_result = () => result.ShouldEqual(("'TestObject': { " +
                                                                                "'type': 'object'," +
                                                                                "'properties': { " +
                                                                                    "'First': { 'type': 'string','analyzer': 'simple','store': true }," +
                                                                                    "'Second': { 'type': 'integer','boost': 10,'store': true } " +
                                                                                "} " +
                                                                           "}").AltQuote());

        private static string result;
        private static CustomPropertyMap<FieldsTestClass>[] properties;
    }
}
