using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(RegExpFilter<>))]
    class When_RegExpFilter_without_value_built
    {
        Because of = () => result = new RegExpFilter<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Cache(true)
                                                .CacheKey("key")
                                                .Name("filterName")                                                
                                                .ToString();

        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
