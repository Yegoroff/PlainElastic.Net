using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(IpMap<>))]
    class When_complete_Ip_mapping_built
    {
        Because of = () => result = new IpMap<FieldsTestClass>()
                                                .Field(doc => doc.StringProperty)
                                                .Boost(5)
                                                .IncludeInAll(false)
                                                .Index(IndexState.analyzed)
                                                .IndexName("Index Name")
                                                .NullValue("Null Value")
                                                .PrecisionStep(10)
                                                .Store(true)
                                                .ToString();


        It should_start_from_specified_field_name = () => result.ShouldStartWith("'StringProperty': {".AltQuote());

        It should_contain_ip_type_declaration_part = () => result.ShouldContain("'type': 'ip'".AltQuote());

        It should_contain_boost_part = () => result.ShouldContain("'boost': 5".AltQuote());

        It should_contain_include_in_all_part = () => result.ShouldContain("'include_in_all': false".AltQuote());

        It should_contain_index_part = () => result.ShouldContain("'index': 'analyzed'".AltQuote());

        It should_contain_index_name_part = () => result.ShouldContain("'index_name': 'Index Name'".AltQuote());

        It should_contain_null_value_part = () => result.ShouldContain("'null_value': 'Null Value'".AltQuote());

        It should_contain_precisiion_step_part = () => result.ShouldContain("'precision_step': 10".AltQuote());

        It should_contain_store_part = () => result.ShouldContain("'store': true".AltQuote());


        It should_generate_correct_JSON_result = () => result.ShouldEqual(("'StringProperty': { " +
                                                                            "'type': 'ip'," +
                                                                            "'boost': 5," +
                                                                            "'include_in_all': false," +
                                                                            "'index': 'analyzed'," +
                                                                            "'index_name': 'Index Name'," +
                                                                            "'null_value': 'Null Value'," +
                                                                            "'precision_step': 10," +
                                                                            "'store': true " +
                                                                          "}").AltQuote());

        private static string result;
    }
}
