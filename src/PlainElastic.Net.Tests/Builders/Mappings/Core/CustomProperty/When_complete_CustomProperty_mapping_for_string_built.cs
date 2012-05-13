using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(CustomPropertyMap<>))]
    class When_complete_CustomProperty_mapping_for_string_built
    {
        Because of = () => result = new CustomPropertyMap<FieldsTestClass>("FieldName", typeof(string))
                                                .Analyzer(DefaultAnalyzers.snowball)
                                                .Boost(5)
                                                .Format("date format")                                                
                                                .IncludeInAll(true)
                                                .Index(IndexState.not_analyzed)
                                                .IndexName("index name")
                                                .IndexAnalyzer(DefaultAnalyzers.stop)
                                                .NullValue("null value")
                                                .OmitNorms(true)
                                                .OmitTermFreqAndPositions(true)
                                                .PrecisionStep(10)
                                                .SearchAnalyzer(DefaultAnalyzers.whitespace)
                                                .Store(true)
                                                .TermVector(TermVector.with_offsets)
                                                .ToString();


        It should_start_from_specified_field_name = () => result.ShouldStartWith("'FieldName': {".AltQuote());

        It should_contain_string_type_declaration_part = () => result.ShouldContain("'type': 'string'".AltQuote());

        It should_contain_analyzer_part = () => result.ShouldContain("'analyzer': 'snowball'".AltQuote());

        It should_contain_boost_part = () => result.ShouldContain("'boost': 5".AltQuote());

        It should_contain_format_part = () => result.ShouldContain("'format': 'date format'".AltQuote());

        It should_contain_include_in_all_part = () => result.ShouldContain("'include_in_all': true".AltQuote());

        It should_contain_index_part = () => result.ShouldContain("'index': 'not_analyzed'".AltQuote());

        It should_contain_index_name_part = () => result.ShouldContain("'index_name': 'index name'".AltQuote());

        It should_contain_index_analyzer_part = () => result.ShouldContain("'index_analyzer': 'stop'".AltQuote());

        It should_contain_null_value_part = () => result.ShouldContain("'null_value': 'null value'".AltQuote());

        It should_contain_omit_norms_part = () => result.ShouldContain("'omit_norms': true".AltQuote());

        It should_contain_omit_term_freq_and_positions_part = () => result.ShouldContain("'omit_term_freq_and_positions': true".AltQuote());

        It should_contain_precision_step_part = () => result.ShouldContain("'precision_step': 10".AltQuote());

        It should_contain_search_analyzer_part = () => result.ShouldContain("'search_analyzer': 'whitespace'".AltQuote());

        It should_contain_store_part = () => result.ShouldContain("'store': true".AltQuote());

        It should_contain_term_vector_part = () => result.ShouldContain("'term_vector': 'with_offsets'".AltQuote());


        It should_generate_correct_JSON_result = () =>
            result.ShouldEqual(("'FieldName': { " +
                                    "'type': 'string'," +
                                    "'analyzer': 'snowball'," +
                                    "'boost': 5," +
                                    "'format': 'date format'," +
                                    "'include_in_all': true," +
                                    "'index': 'not_analyzed'," +
                                    "'index_name': 'index name'," +
                                    "'index_analyzer': 'stop'," +
                                    "'null_value': 'null value'," +
                                    "'omit_norms': true," +
                                    "'omit_term_freq_and_positions': true," +
                                    "'precision_step': 10," +
                                    "'search_analyzer': 'whitespace'," +
                                    "'store': true," +
                                    "'term_vector': 'with_offsets' " +
                                "}").AltQuote());
    

        private static string result;
    }
}
