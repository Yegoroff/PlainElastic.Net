using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(IndicesQuery<>))]
    class When_IndicesQuery_with_all_no_match_query_built
    {
        Because of = () => result = new IndicesQuery<FieldsTestClass>()
                                                .Indices("One", "Two")
                                                .Query(q => q
                                                    .Custom("{ Query }")
                                                )
                                                .NoMatchQuery(IndicesNoMatchMode.all)                                               
                                                .ToString();


        It should_start_with_indices_declaration = () => result.ShouldContain("'indices': {".AltQuote());

        It should_contain_indices_part = () => result.ShouldContain("'indices': [ 'One','Two' ]".AltQuote());

        It should_contain_query_part = () => result.ShouldContain("'query': { Query }".AltQuote());

        It should_contain_no_match_query_equals_to_all_part = () => result.ShouldContain("'no_match_query': 'all'".AltQuote());


        It should_return_correct_result = () => result.ShouldEqual(("{ 'indices': { " +
                                                                           "'indices': [ 'One','Two' ]," +
                                                                           "'query': { Query }," +
                                                                           "'no_match_query': 'all' " +                                                                           
                                                                       "} " +
                                                                   "}").AltQuote());

        private static string result;
    }
}
