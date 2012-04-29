using Machine.Specifications;
using PlainElastic.Net.Queries;


namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(Query<>))]
    class When_Query_with_nested_custom_text_built
    {
        Because of = () => result = new Query<FieldsTestClass>()
                                                .Term(t=> t.Custom("term's query"))
                                                .ToString();

        It should_return_correct_result = () => result.ShouldEqual("\"query\": { \"term\": { term's query } }");

        private static string result;
    }
}
