using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(Facets<>))]
    class When_complete_Facets_built
    {
        Because of = () => result = new Facets<FieldsTestClass>()
                                                .Terms(t => t
                                                    .FacetName("Terms")
                                                    .Field(f=>f.StringProperty)
                                                )
                                                .FilterFacets(ff => ff
                                                    .FacetName("Filter")
                                                    .Filter(f => f
                                                        .Term(t => t
                                                            .Field(doc => doc.StringProperty)
                                                            .Value("test")
                                                        )
                                                    )
                                                )
                                                .ToString();

        It should_starts_with_facets_declaration = () => result.ShouldStartWith("'facets': ".AltQuote());

        It should_contain_terms_facet_part = () => result.ShouldContain("'Terms': { 'terms': { 'field': 'StringProperty' } }".AltQuote());

        It should_contain_filter_facet_part = () => result.ShouldContain("'Filter': { 'filter': { 'term': { 'StringProperty': 'test' } } }".AltQuote());


        It should_return_correct_JSON = () => result.ShouldEqual(("'facets': { " +
                                                                    "'Terms': { 'terms': { 'field': 'StringProperty' } }," +
                                                                    "'Filter': { 'filter': { 'term': { 'StringProperty': 'test' } } } "+
                                                                 "}").AltQuote());

        private static string result;
    }
}
