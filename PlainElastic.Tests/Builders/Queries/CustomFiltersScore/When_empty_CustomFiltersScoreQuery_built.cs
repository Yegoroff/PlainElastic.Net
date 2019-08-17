using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(CustomFiltersScoreQuery<>))]
    class When_empty_CustomFiltersScoreQuery_built
    {
        Because of = () => result = new CustomFiltersScoreQuery<FieldsTestClass>()
                                                .Query(q => q)
                                                .Filters(f => f.Custom("Filters"))
                                                .ScoreMode(CustomFiltersScoreMode.total)
                                                .Lang("script lang")
                                                .Params("script params")
                                                .ToString();

        It should_return_empty_result = () => result.ShouldBeEmpty();

        private static string result;
    }
}
