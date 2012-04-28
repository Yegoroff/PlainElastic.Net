using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(QueryString<>))]
    class When_empty_QueryString_built
    {
        Because of = () => result = new QueryString<FieldsTestClass>()
                                                .DefaultField(f => f.StringProperty)
                                                .Fields(f => f.StringProperty, f=> f.BoolProperty)
                                                .FieldsOfCollection(f => f.CollectionProperty, collection => collection.EnumProperty, collection => collection.StringProperty)
                                                .Boost(5)
                                                .Rewrite(Rewrite.top_terms_boost_n, 100)
                                                .Query("")
                                                .ToString();


        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
