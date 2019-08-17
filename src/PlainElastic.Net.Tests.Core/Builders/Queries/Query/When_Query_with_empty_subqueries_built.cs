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
                        .Boosting(b => b)
                        .Ids(i => i)
                        .CustomScore(q => q)
                        .ConstantScore(q => q)
                        .DisMax(q => q)
                        .Filtered(q => q)
                        .FuzzyLikeThis(f => f)
                        .FuzzyLikeThisField(f => f)
                        .Fuzzy(q => q)
                        .MoreLikeThis(m => m)
                        .MoreLikeThisField(m => m)
                        .HasChild<AnotherTestClass>(h => h)
                        .Nested(q => q)
                        .QueryString(q => q)
                        .Prefix(p => p)
                        .Range(q => q)
                        .Term(q => q)
                        .Terms(q => q)
                        .CustomFiltersScore(q => q)
                        .HasChild<AnotherTestClass>(q => q)
                        .HasParent<AnotherTestClass>(q => q)
                        .TopChildren(q => q)
                        .Wildcard(q => q)
                        .Indices(i => i)
                        .Custom("")
                        .ToString();

        It should_return_empty_string = () =>
            result.ShouldBeEmpty();

        private static string result;
    }
}
