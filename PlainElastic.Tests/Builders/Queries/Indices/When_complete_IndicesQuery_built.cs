using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(IndicesQuery<>))]
    class When_complete_IndicesQuery_built
    {
        Because of = () => result = new IndicesQuery<FieldsTestClass>()
                                                .Indices("One", "Two")
                                                .Query(q => q
                                                    .Custom("{ Query }")
                                                )
                                                .NoMatchQuery(n => n
                                                    .Custom("No Match Query")
                                                )                                               
                                                .Custom("Custom")
                                                .ToString();


        It should_start_with_indices_declaration = () => result.ShouldContain("'indices': {".AltQuote());

        It should_contain_indices_part = () => result.ShouldContain("'indices': [ 'One','Two' ]".AltQuote());

        It should_contain_query_part = () => result.ShouldContain("'query': { Query }".AltQuote());

        It should_contain_no_match_query_part = () => result.ShouldContain("'no_match_query': { No Match Query }".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("Custom".AltQuote());

        It should_return_correct_result = () => result.ShouldEqual(("{ 'indices': { " +
                                                                           "'indices': [ 'One','Two' ]," +
                                                                           "'query': { Query }," +
                                                                           "'no_match_query': { No Match Query }," +
                                                                           "Custom " +
                                                                       "} " +
                                                                   "}").AltQuote());

        private static string result;
    }
}
