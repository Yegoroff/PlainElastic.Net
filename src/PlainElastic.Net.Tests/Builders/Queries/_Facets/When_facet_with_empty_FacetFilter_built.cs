using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(Facets<>))]
    public class When_facet_with_empty_FacetFilter_built
    {
        Because of = () => result = new Facets<FieldsTestClass>()
                                               .Terms(ft => ft
                                                   .FacetName("Terms")
                                                   .Field(f => f.StringProperty)
                                                   .FacetFilter(ff => ff.Term(t => t.Field(f => f.StringProperty).Value("")))
                                               )
                                               .ToString();

        It should_return_correct_JSON = () => result.ShouldEqual("'facets': { 'Terms': { 'terms': { 'field': 'StringProperty' } } }".AltQuote());

        private static string result;
    }
}