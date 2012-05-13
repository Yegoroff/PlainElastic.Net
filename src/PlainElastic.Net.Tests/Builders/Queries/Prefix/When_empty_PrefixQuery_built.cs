using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(PrefixQuery<>))]
    class When_empty_PrefixQuery_built
    {
        Because of = () => result = new PrefixQuery<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Prefix("")
                                                .Boost(5)
                                                .Rewrite(Rewrite.top_terms_boost_n, 100)
                                                .Custom("")
                                                .ToString();

        It should_return_empty_string = () =>
            result.ShouldBeEmpty();

        private static string result;
    }
}
