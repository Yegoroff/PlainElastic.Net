using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(TermQuery<>))]
    class When_TermQuery_with_collection_field_built
    {
        Because of = () => result = new TermQuery<FieldsTestClass>()
                                                .FieldOfCollection(f => f.CollectionProperty, c => c.StringProperty)
                                                .Value("One")
                                                .ToString();

        It should_contain_full_field_path = () => result.ShouldContain("'CollectionProperty.StringProperty':".AltQuote());

        It should_return_correct_query = () => result.ShouldEqual("{ 'term': { 'CollectionProperty.StringProperty': { 'value': 'One' } } }".AltQuote());

        private static string result;
    }
}
