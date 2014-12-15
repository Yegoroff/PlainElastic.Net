using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(DateMap<>))]
    class When_complete_Date_mapping_built
    {
        Because of = () => result = new DateMap<FieldsTestClass>()
                                                .Fields(f => f.String("multi_field"))
                                                .Field(doc => doc.DateProperty)
                                                .Boost(5)
                                                .Format("date format")
                                                .IncludeInAll(true)
                                                .Index(IndexState.analyzed)
                                                .IndexName("index name")
                                                .NullValue("null value")
                                                .PrecisionStep(10)
                                                .Store(true)
                                                .FuzzyFactor(7)
                                                .ToString();


        It should_start_from_specified_field_name = () => result.ShouldStartWith("'DateProperty': {".AltQuote());

        It should_contain_date_type_declaration_part = () => result.ShouldContain("'type': 'date'".AltQuote());

        It should_contain_boost_part = () => result.ShouldContain("'boost': 5".AltQuote());

        It should_contain_format_part = () => result.ShouldContain("'format': 'date format'".AltQuote());

        It should_contain_include_in_all_part = () => result.ShouldContain("'include_in_all': true".AltQuote());

        It should_contain_index_part = () => result.ShouldContain("'index': 'analyzed'".AltQuote());

        It should_contain_index_name_part = () => result.ShouldContain("'index_name': 'index name'".AltQuote());

        It should_contain_null_value_part = () => result.ShouldContain("'null_value': 'null value'".AltQuote());

        It should_contain_precision_step_part = () => result.ShouldContain("'precision_step': 10".AltQuote());

        It should_contain_fields_part = () => result.ShouldContain("'fields': { 'multi_field': { 'type': 'string' } }".AltQuote());

        It should_contain_store_part = () => result.ShouldContain("'store': true".AltQuote());

        It should_contain_fuzzy_factor_declaration_part = () => result.ShouldContain("'fuzzy_factor': 7".AltQuote());


        It should_generate_correct_JSON_result = () =>
            result.ShouldEqual(("'DateProperty': { " +
                                    "'type': 'date'," +
                                    "'fields': { 'multi_field': { 'type': 'string' } }," +
                                    "'boost': 5," +
                                    "'format': 'date format'," +
                                    "'include_in_all': true," +
                                    "'index': 'analyzed'," +
                                    "'index_name': 'index name'," +
                                    "'null_value': 'null value'," +
                                    "'precision_step': 10," +
                                    "'store': true," +
                                    "'fuzzy_factor': 7 " +
                                "}").AltQuote());

        private static string result;
    }
}
