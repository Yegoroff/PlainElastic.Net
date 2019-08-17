using Machine.Specifications;
using PlainElastic.Net.Queries;


namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(TopChildrenQuery<>))]
    class When_empty_TopChildrenQuery_built
    {
        Because of = () => result = new TopChildrenQuery<FieldsTestClass>()
                                                .Type("childType")
                                                .Query(q => q.Custom(""))
                                                .Scope("query_scope")
                                                .IncrementalFactor(5)
                                                .Factor(10)
                                                .Score(TopChildrenScoreMode.avg)
                                                .Boost(5)
                                                .Custom("")
                                                .ToString();

        It should_return_empty_string = () => 
            result.ShouldBeEmpty();

        private static string result;
    }
}
