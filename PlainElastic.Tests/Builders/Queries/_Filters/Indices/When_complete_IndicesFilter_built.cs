using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(IndicesFilter<>))]
    class When_complete_IndicesFilter_built
    {
        Because of = () => result = new IndicesFilter<FieldsTestClass>()
                                                .Indices("One", "Two")
                                                .Filter(q => q
                                                    .Custom("{ Filter }")
                                                )
                                                .NoMatchFilter(n => n
                                                    .Custom("No Match Filter")
                                                )                                               
                                                .Custom("Custom")
                                                .ToString();


        It should_start_with_indices_declaration = () => result.ShouldContain("'indices': {".AltQuote());

        It should_contain_indices_part = () => result.ShouldContain("'indices': [ 'One','Two' ]".AltQuote());

        It should_contain_query_part = () => result.ShouldContain("'filter': { Filter }".AltQuote());

        It should_contain_no_match_query_part = () => result.ShouldContain("'no_match_filter': { No Match Filter }".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("Custom".AltQuote());

        It should_return_correct_result = () => result.ShouldEqual(("{ 'indices': { " +
                                                                           "'indices': [ 'One','Two' ]," +
                                                                           "'filter': { Filter }," +
                                                                           "'no_match_filter': { No Match Filter }," +
                                                                           "Custom " +
                                                                       "} " +
                                                                   "}").AltQuote());

        private static string result;
    }
}
