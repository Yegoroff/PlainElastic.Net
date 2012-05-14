using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(IndicesFilter<>))]
    class When_IndicesFilter_with_all_no_match_query_built
    {
        Because of = () => result = new IndicesFilter<FieldsTestClass>()
                                                .Indices("One", "Two")
                                                .Filter(q => q
                                                    .Custom("{ Filter }")
                                                )
                                                .NoMatchFilter(IndicesNoMatchMode.all)                                               
                                                .ToString();


        It should_start_with_indices_declaration = () => result.ShouldContain("'indices': {".AltQuote());

        It should_contain_indices_part = () => result.ShouldContain("'indices': [ 'One','Two' ]".AltQuote());

        It should_contain_query_part = () => result.ShouldContain("'filter': { Filter }".AltQuote());

        It should_contain_no_match_query_equals_to_all_part = () => result.ShouldContain("'no_match_filter': 'all'".AltQuote());


        It should_return_correct_result = () => result.ShouldEqual(("{ 'indices': { " +
                                                                           "'indices': [ 'One','Two' ]," +
                                                                           "'filter': { Filter }," +
                                                                           "'no_match_filter': 'all' " +                                                                           
                                                                       "} " +
                                                                   "}").AltQuote());

        private static string result;
    }
}
