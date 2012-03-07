using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Buildres.Queries
{
    [Subject(typeof(QueryBuilder<>))]
    class When_empty_QueryBuilder_built
    {
        Because of = () => 
            result = new QueryBuilder<FieldsTestClass>()                         
                        .From(10)
                        .Size(20)
                        .Sort(s=>s
                            .Field("_score")
                         )
                        .ToString();

        It should_return_empty_string = () =>
            result.ShouldBeEmpty();

        private static string result;
    }
}
