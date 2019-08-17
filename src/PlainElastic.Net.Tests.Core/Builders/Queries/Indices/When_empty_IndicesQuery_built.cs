using Machine.Specifications;
using PlainElastic.Net.Queries;


namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(IndicesQuery<>))]
    class When_empty_IndicesQuery_built
    {
        Because of = () => result = new IndicesQuery<FieldsTestClass>()
                                                .Indices("One", "Two")
                                                .Query(q => q
                                                    .Custom("")
                                                )
                                                .NoMatchQuery(n => n
                                                    .Custom("Non Match Query")
                                                )
                                                .Custom("")
                                                .ToString();

        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
