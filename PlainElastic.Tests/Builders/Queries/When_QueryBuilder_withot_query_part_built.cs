using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(QueryBuilder<>))]
    class When_QueryBuilder_withot_query_part_built
    {
        Because of = () => 
            result = new QueryBuilder<FieldsTestClass>()
                        .From(10)
                        .Size(20)
                        .Sort(s=>s
                            .Field("_score")
                         )
                        .Build();

        It should_return_from_part = () =>
            result.ShouldContain("'from': 10".AltQuote());

        It should_return_size_part = () =>
            result.ShouldContain("'size': 20".AltQuote());

        It should_return_sort_part = () =>
            result.ShouldContain("'sort': ['_score']".AltQuote());

        It should_return_correct_query = () =>
            result.ShouldEqual("{ 'from': 10,'size': 20,'sort': ['_score'] }".AltQuote());


        private static string result;
    }
}
