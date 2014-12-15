using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(StringMap<>))]
    class When_complete_String_mapping_built
    {
        Because of = () => result = new StringMap<FieldsTestClass>()
                                                .Field(doc => doc.StringProperty)
                                                .Fields(f => f.String("multi_field"))
                                                .Boost(5)
                                                .IncludeInAll(false)
                                                .Index(IndexState.analyzed)
                                                .IndexName("Index Name")
                                                .NullValue("Null Value")                                                
                                                .Store(true)
                                                .Analyzer(DefaultAnalyzers.stop)
                                                .IndexAnalyzer(DefaultAnalyzers.simple)
                                                .OmitNorms(true)
                                                .OmitTermFreqAndPositions(true)
                                                .SearchAnalyzer(DefaultAnalyzers.keyword)
                                                .TermVector(TermVector.with_positions)
                                                .Custom("custom mapping")
                                                .ToString();


        It should_start_from_specified_field_name = () => result.ShouldStartWith("'StringProperty': {".AltQuote());

        It should_contain_string_type_declaration_part = () => result.ShouldContain("'type': 'string'".AltQuote());

        It should_contain_boost_part = () => result.ShouldContain("'boost': 5".AltQuote());

        It should_contain_include_in_all_part = () => result.ShouldContain("'include_in_all': false".AltQuote());

        It should_contain_index_part = () => result.ShouldContain("'index': 'analyzed'".AltQuote());

        It should_contain_index_name_part = () => result.ShouldContain("'index_name': 'Index Name'".AltQuote());

        It should_contain_null_value_part = () => result.ShouldContain("'null_value': 'Null Value'".AltQuote());

        It should_contain_store_part = () => result.ShouldContain("'store': true".AltQuote());

        It should_contain_analyzer_part = () => result.ShouldContain("'analyzer': 'stop'".AltQuote());

        It should_contain_index_analyzer_part = () => result.ShouldContain("'index_analyzer': 'simple'".AltQuote());

        It should_contain_omit_norms_part = () => result.ShouldContain("'omit_norms': true".AltQuote());

        It should_contain_omit_term_freq_and_positions_part = () => result.ShouldContain("'omit_term_freq_and_positions': true".AltQuote());

        It should_contain_search_analyzer_part = () => result.ShouldContain("'search_analyzer': 'keyword'".AltQuote());

        It should_contain_term_vector_part = () => result.ShouldContain("'term_vector': 'with_positions'".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("custom mapping");

        It should_contain_fields_part = () => result.ShouldContain("'fields': { 'multi_field': { 'type': 'string' } }".AltQuote());

        It should_generate_correct_JSON_result = () => result.ShouldEqual(("'StringProperty': { " +
                                                                            "'type': 'string'," +
                                                                            "'fields': { 'multi_field': { 'type': 'string' } }," +
                                                                            "'boost': 5," +
                                                                            "'include_in_all': false," +
                                                                            "'index': 'analyzed'," +
                                                                            "'index_name': 'Index Name'," +
                                                                            "'null_value': 'Null Value'," +
                                                                            "'store': true," +
                                                                            "'analyzer': 'stop'," +
                                                                            "'index_analyzer': 'simple'," +
                                                                            "'omit_norms': true," +
                                                                            "'omit_term_freq_and_positions': true," +
                                                                            "'search_analyzer': 'keyword'," +
                                                                            "'term_vector': 'with_positions'," +
                                                                            "custom mapping " +
                                                                          "}").AltQuote());

        private static string result;
    }
}
