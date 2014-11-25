using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(BooleanMap<>))]
    class When_complete_Boolean_mapping_built
    {
        Because of = () => result = new BooleanMap<FieldsTestClass>()
                                                .Fields(f => f.String("multi_field"))
                                                .Field(doc => doc.BoolProperty)
                                                .Boost(5)
                                                .IncludeInAll(false)
                                                .Index(IndexState.analyzed)
                                                .IndexName("Index Name")
                                                .NullValue("Null Value")                                                
                                                .Store(true)
                                                .Custom("custom mapping")
                                                .ToString();


        It should_start_from_specified_field_name = () => result.ShouldStartWith("'BoolProperty': {".AltQuote());

        It should_contain_boolean_type_declaration_part = () => result.ShouldContain("'type': 'boolean'".AltQuote());

        It should_contain_boost_part = () => result.ShouldContain("'boost': 5".AltQuote());

        It should_contain_include_in_all_part = () => result.ShouldContain("'include_in_all': false".AltQuote());

        It should_contain_index_part = () => result.ShouldContain("'index': 'analyzed'".AltQuote());

        It should_contain_index_name_part = () => result.ShouldContain("'index_name': 'Index Name'".AltQuote());

        It should_contain_fields_part = () => result.ShouldContain("'fields': { 'multi_field': { 'type': 'string' } }".AltQuote());

        It should_contain_null_value_part = () => result.ShouldContain("'null_value': 'Null Value'".AltQuote());

        It should_contain_store_part = () => result.ShouldContain("'store': true".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("custom mapping");

        It should_generate_correct_JSON_result = () => result.ShouldEqual(("'BoolProperty': { " +
                                                                            "'type': 'boolean'," +
                                                                            "'fields': { 'multi_field': { 'type': 'string' } }," +
                                                                            "'boost': 5," +
                                                                            "'include_in_all': false," +
                                                                            "'index': 'analyzed'," +
                                                                            "'index_name': 'Index Name'," +
                                                                            "'null_value': 'Null Value'," +
                                                                            "'store': true," +
                                                                            "custom mapping " +
                                                                          "}").AltQuote());

        private static string result;
    }
}
