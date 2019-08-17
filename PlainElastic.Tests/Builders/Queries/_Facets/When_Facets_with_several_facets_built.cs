using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(Facets<>))]
    class When_Facets_with_several_facets_built
    {
        Because of = () => result = new Facets<FieldsTestClass>()
                                                .Terms(t=>t
                                                    .FacetName("First")
                                                    .Field(f=>f.StringProperty)
                                                )
                                                .Terms(t => t
                                                    .FacetName("Second")
                                                    .Field(f => f.BoolProperty)
                                                )
                                                .ToString();

        It should_return_correct_JSON = () => result.ShouldEqual("'facets': { 'First': { 'terms': { 'field': 'StringProperty' } },'Second': { 'terms': { 'field': 'BoolProperty' } } }".AltQuote());

        private static string result;
    }
}
