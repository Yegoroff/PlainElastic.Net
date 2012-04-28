using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(CustomPropertyMap<>))]
    class When_CustomProperty_mapping_with_true_condition_built
    {
        Because of = () => result = new CustomPropertyMap<FieldsTestClass>("FieldName", typeof(string))
                                                .When(true, p => p.Boost(5))
                                                .ToString();


        It should_start_from_specified_field_name = () => result.ShouldStartWith("'FieldName': {".AltQuote());

        It should_contain_string_type_declaration_part = () => result.ShouldContain("'type': 'string'".AltQuote());

        It should_contain_boost_part = () => result.ShouldContain("'boost': 5".AltQuote());


        It should_generate_correct_JSON_result = () =>
            result.ShouldEqual(("'FieldName': { " +
                                    "'type': 'string'," +
                                    "'boost': 5 " +
                                "}").AltQuote());
    

        private static string result;
    }
}
