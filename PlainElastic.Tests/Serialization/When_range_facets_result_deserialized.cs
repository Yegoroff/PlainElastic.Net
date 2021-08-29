using Machine.Specifications;
using PlainElastic.Net.Serialization;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Serialization
{
    [Subject(typeof(JsonNetSerializer))]
    class When_range_facets_result_deserialized
    {
        #region Range Facets Json Result
        private static readonly string rangeFacetsJsonResult =
@"{
    'took': 16,
    'timed_out': false,
    '_shards': {
        'total': 5,
        'successful': 5,
        'failed': 0
    },
    'hits': {
        'total': 3000,
        'max_score': 1.0,
        'hits': [ ]
    },
    'facets': {
        'quantity': {
            '_type': 'range',
            'ranges': [
                {
                    'to': 50.0,
                    'count': 1000,
                    'min': 0.0,
                    'max': 10.0,
                    'total_count': 1100,
                    'total': 1200.0,
                    'mean': 15.5
                },
                {
                    'from': 20.0,
                    'to': 70.0,
                    'count': 2000,
                    'min': 20.0,
                    'max': 70.0,
                    'total_count': 2100,
                    'total': 50000.0,
                    'mean': 30.5
                }
            ]
        }
    }
}".AltQuote();
        #endregion

        Establish context = () => 
            jsonSerializer = new JsonNetSerializer();


        Because of = () => 
            result = jsonSerializer.ToSearchResult<object>(rangeFacetsJsonResult);
            

        It should_contain_correct_hits_count = () =>
            result.hits.total.ShouldEqual(3000);

        It should_contain_quantity_facet_with_filter_type = () =>
            result.facets["quantity"]._type.ShouldEqual("range");

        It should_deserialize_quantity_facet_to_RanfgeFacetResults_type = () =>
            result.facets["quantity"].ShouldBeOfType<RangeFacetResult>();

        It should_contain_quantity_facet_with_correct_from_value = () =>
            result.facets["quantity"].As<RangeFacetResult>().ranges[1].from.ShouldEqual(20);

        It should_contain_quantity_facet_with_correct_to_value = () =>
            result.facets["quantity"].As<RangeFacetResult>().ranges[1].to.ShouldEqual(70);

        It should_contain_quantity_facet_with_correct_count = () =>
            result.facets["quantity"].As<RangeFacetResult>().ranges[1].count.ShouldEqual(2000);

        It should_contain_quantity_facet_with_correct_total_count = () =>
            result.facets["quantity"].As<RangeFacetResult>().ranges[1].total_count.ShouldEqual(2100);

        It should_contain_quantity_facet_with_correct_total = () =>
            result.facets["quantity"].As<RangeFacetResult>().ranges[1].total.ShouldEqual(50000);

        It should_contain_quantity_facet_with_correct_min = () =>
            result.facets["quantity"].As<RangeFacetResult>().ranges[1].min.ShouldEqual(20);

        It should_contain_quantity_facet_with_correct_max = () =>
            result.facets["quantity"].As<RangeFacetResult>().ranges[1].max.ShouldEqual(70);

        It should_contain_quantity_facet_with_correct_mean = () =>
            result.facets["quantity"].As<RangeFacetResult>().ranges[1].mean.ShouldEqual(30.5);

        private static JsonNetSerializer jsonSerializer;
        private static SearchResult<object> result;
    }

}