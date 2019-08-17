using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(Facets<>))]
    class When_Facets_with_one_facet_built
    {
        Because of = () => result = new Facets<FieldsTestClass>()
                                                .Terms(t=>t
                                                    .FacetName("First")
                                                    .Field(f=>f.StringProperty)
                                                )
                                                .ToString();

        It should_return_correct_JSON = () => result.ShouldEqual("'facets': { 'First': { 'terms': { 'field': 'StringProperty' } } }".AltQuote());

        private static string result;
    }
}
