using Machine.Specifications;
using PlainElastic.Net.Queries;


namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(Query<>))]
    class When_Query_with_empty_subqueries_built
    {
        Because of = () => 
            result = new Query<FieldsTestClass>()
                        .Text(q => q)
                        .Bool(q => q)
                        .ConstantScore(q => q)
                        .DisMax(q => q)
                        .Filtered(q => q)
                        .Fuzzy(q => q)
                        .Nested(q => q)
                        .QueryString(q => q)
                        .Range(q => q)
                        .Term(q => q)
                        .Terms(q => q)
                        .CustomFiltersScore(q => q)
                        .Custom("")
                        .ToString();

        It should_return_empty_string = () =>
            result.ShouldBeEmpty();

        private static string result;
    }
}
