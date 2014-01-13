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
                                                .Statistical(s => s
                                                    .FacetName("Statistical")
                                                    .Field(f=>f.IntProperty)
                                                )
                                                .TermsStats(ts => ts
                                                    .FacetName("TermsStats")
                                                    .KeyField(f => f.StringProperty)
                                                    .ValueField(f => f.IntProperty)   
                                                )
                                                .GeoDistance(g => g
                                                    .FacetName("GeoRange")
                                                    .Field(f => f.StringProperty)
                                                    .GeoPoint(lat:10, lon:20)
                                                    .Ranges(i => i
                                                        .FromTo(from: 1, to: 5)
                                                    )
                                                )
                                                .Histogram(h => h
                                                    .FacetName("Histogram")
                                                    .Field(f => f.IntProperty)
                                                    .Interval(10)
                                                )
                                                .DateHistogram(dh => dh
                                                    .FacetName("DateHistogram")
                                                    .Field(f => f.DateProperty)
                                                    .Interval("3m")
                                                )
                                                .ToString();

        It should_starts_with_facets_declaration = () => result.ShouldStartWith("'facets': ".AltQuote());

        It should_contain_terms_facet_part = () => result.ShouldContain("'Terms': { 'terms': { 'field': 'StringProperty' } }".AltQuote());

        It should_contain_filter_facet_part = () => result.ShouldContain("'Filter': { 'filter': { 'term': { 'StringProperty': 'test' } } }".AltQuote());

        It should_contain_range_facet_part = () => result.ShouldContain("'Range': { 'range': { 'ranges': [ { 'from': 1, 'to': 5 } ] } }".AltQuote());

        It should_contain_statistical_facet_part = () => result.ShouldContain("'Statistical': { 'statistical': { 'field': 'IntProperty' } }".AltQuote());

        It should_contain_terms_stats_facet_part = () => result.ShouldContain("'TermsStats': { 'terms_stats': { 'key_field': 'StringProperty','value_field': 'IntProperty' } }".AltQuote());

        It should_contain_geo_distance_range_facet_part = () => result.ShouldContain("'GeoRange': { 'geo_distance': { 'StringProperty': { 'lat': 10,'lon': 20 },'ranges': [ { 'from': 1, 'to': 5 } ] } }".AltQuote());

        It should_contain_histogram_facet_part = () => result.ShouldContain("'Histogram': { 'histogram': { 'field': 'IntProperty','interval': 10 } }".AltQuote());

        It should_contain_date_histogram_facet_part = () => result.ShouldContain("'DateHistogram': { 'date_histogram': { 'field': 'DateProperty','interval': '3m' } }".AltQuote());

        It should_return_correct_JSON = () => result.ShouldEqual(("'facets': { " +
                                                                    "'Terms': { 'terms': { 'field': 'StringProperty' } }," +
                                                                    "'Filter': { 'filter': { 'term': { 'StringProperty': 'test' } } },"+
                                                                    "'Range': { 'range': { 'ranges': [ { 'from': 1, 'to': 5 } ] } }," +
                                                                    "'Statistical': { 'statistical': { 'field': 'IntProperty' } }," +
                                                                    "'TermsStats': { 'terms_stats': { 'key_field': 'StringProperty','value_field': 'IntProperty' } }," +
                                                                    "'GeoRange': { 'geo_distance': { 'StringProperty': { 'lat': 10,'lon': 20 },'ranges': [ { 'from': 1, 'to': 5 } ] } }," +
                                                                    "'Histogram': { 'histogram': { 'field': 'IntProperty','interval': 10 } }," +
                                                                    "'DateHistogram': { 'date_histogram': { 'field': 'DateProperty','interval': '3m' } }" +
                                                                 " }").AltQuote());

        private static string result;
    }
}
