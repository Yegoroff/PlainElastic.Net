using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(RootObject<>))]
    class When_complete_RootObject_mapping_built
    {
        Because of = () => result = new RootObject<FieldsTestClass>("TestObject")
                                            .DateDetection(true)
                                            .DynamicDateFormats(new[] { "yyyy-MM-dd", "dd-MM-yyyy" })
                                            .NumericDetection(true)
                                            .DynamicTemplates("Template")
                                            .IndexAnalyzer(DefaultAnalyzers.keyword)
                                            .SearchAnalyzer(DefaultAnalyzers.standard)
                                            .Id(id => id
                                                .Index(IndexState.analyzed)
                                                .Path("obj_id")
                                                .Store(true)
                                            )            
                                            .Meta("{ 'meta': 'data' }".AltQuote())
                                            .Parent(parent => parent
                                                .Type("ParentType")
                                            )
                                            .All(all=>all
                                                .Enabled(true)
                                                .Analyzer(DefaultAnalyzers.snowball)
                                                .IndexAnalyzer(DefaultAnalyzers.simple)
                                                .SearchAnalyzer(DefaultAnalyzers.keyword)
                                                .Store(true)
                                                .TermVector(TermVector.yes)
                                            )
                                            .ToString();

        It should_generate_correct_JSON_result = () =>
            result.ShouldEqual(("'TestObject': { " +
                                    "'date_detection': true," +
                                    "'dynamic_date_formats': [ 'yyyy-MM-dd','dd-MM-yyyy' ]," +
                                    "'numeric_detection': true," +
                                    "'dynamic_templates': [ Template ]," +
                                    "'index_analyzer': 'keyword'," +
                                    "'search_analyzer': 'standard'," +
                                    "'_id': { " +
                                        "'index': 'analyzed'," +
                                        "'path': 'obj_id'," +
                                        "'store': true" +
                                    " }," +
                                    "'_meta': { 'meta': 'data' }," +
                                    "'_parent': { 'type': 'ParentType'  }," +
                                    "'_all': { " +
                                        "'enabled': true," +
                                        "'analyzer': 'snowball'," +
                                        "'index_analyzer': 'simple'," +
                                        "'search_analyzer': 'keyword'," +
                                        "'store': true," +
                                        "'term_vector': 'yes'" +
                                     " }" +
                                " }"            
            ).AltQuote());

        private static string result;
    }
}
