using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(MatchAllQuery<>))]
    class When_MatchAllQuery_with_collection_field_built
    {
        Because of = () => result = new MatchAllQuery<FieldsTestClass>()
                                                .NormsFieldOfCollection(f => f.CollectionProperty, c => c.StringProperty)
                                                .ToString();

        It should_contain_norm_field_with_full_field_path = () => result.ShouldContain("'norms_field': 'CollectionProperty.StringProperty'".AltQuote());

        It should_return_correct_query = () => result.ShouldEqual("{ 'match_all': { 'norms_field': 'CollectionProperty.StringProperty' } }".AltQuote());

        private static string result;
    }
}
