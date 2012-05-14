using Machine.Specifications;
using PlainElastic.Net.Queries;


namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(IndicesFilter<>))]
    class When_empty_IndicesFilter_built
    {
        Because of = () => result = new IndicesFilter<FieldsTestClass>()
                                                .Indices("One", "Two")
                                                .Filter(q => q
                                                    .Custom("")
                                                )
                                                .NoMatchFilter(n => n
                                                    .Custom("Non Match Filter")
                                                )
                                                .Custom("")
                                                .ToString();

        It should_return_empty_string = () => 
            result.ShouldBeEmpty();

        private static string result;
    }
}
