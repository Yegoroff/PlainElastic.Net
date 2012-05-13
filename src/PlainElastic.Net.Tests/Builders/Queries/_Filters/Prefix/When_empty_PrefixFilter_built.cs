using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(PrefixFilter<>))]
    class When_empty_PrefixFilter_built
    {
        Because of = () => result = new PrefixFilter<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Prefix("")
                                                .Cache(true)
                                                .CacheKey("CacheKey")
                                                .Name("FilterName")
                                                .Custom("")
                                                .ToString();

        It should_return_empty_string = () =>
            result.ShouldBeEmpty();

        private static string result;
    }
}
