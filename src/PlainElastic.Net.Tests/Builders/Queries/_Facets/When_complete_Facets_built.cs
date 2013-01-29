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
                                                .Range(r => r
                                                    .FacetName("Range")
                                                    .Ranges(i => i
                                                        .FromTo(from: 1, to: 5)
                                                    )                                                
                                                )
                                                .ToString();

        It should_starts_with_facets_declaration = () => result.ShouldStartWith("'facets': ".AltQuote());

        It should_contain_terms_facet_part = () => result.ShouldContain("'Terms': { 'terms': { 'field': 'StringProperty' } }".AltQuote());

        It should_contain_filter_facet_part = () => result.ShouldContain("'Filter': { 'filter': { 'term': { 'StringProperty': 'test' } } }".AltQuote());

        It should_contain_range_facet_part = () => result.ShouldContain("'Range': { 'range': { 'ranges': [ { 'from': 1, 'to': 5 } ] } }".AltQuote());


        It should_return_correct_JSON = () => result.ShouldEqual(("'facets': { " +
                                                                    "'Terms': { 'terms': { 'field': 'StringProperty' } }," +
                                                                    "'Filter': { 'filter': { 'term': { 'StringProperty': 'test' } } },"+
                                                                    "'Range': { 'range': { 'ranges': [ { 'from': 1, 'to': 5 } ] } } " +
                                                                 "}").AltQuote());

        private static string result;
    }
}
