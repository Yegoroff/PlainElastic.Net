using Machine.Specifications;
using PlainElastic.Net.Serialization;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Serialization
{
    [Subject(typeof(JsonNetSerializer))]
    class When_histogram_facets_result_deserialized
    {
        #region Histogram Facets Json Result
        private static readonly string histogramFacetsJsonResult =
@"{
    'took': 64,
    'timed_out': false,
    '_shards': {
        'total': 5,
        'successful': 5,
        'failed': 0
    },
    'hits': {
        'total': 2,
        'max_score': 1.0,
        'hits': []
    },
    'facets': {
        'histo1': {
            '_type': 'histogram',
            'entries': [
                {
                    'key': 10,
                    'count': 1
                },
                {
                    'key': 20,
                    'count': 2
                }
            ]
        }
    }
}".AltQuote();
        #endregion

        Establish context = () => 
            jsonSerializer = new JsonNetSerializer();


        Because of = () => 
            result = jsonSerializer.ToSearchResult<object>(histogramFacetsJsonResult);
            

        It should_contain_correct_hits_count = () =>
            result.hits.total.ShouldEqual(2);

        It should_contain_facet_with_filter_type = () =>
            result.facets["histo1"]._type.ShouldEqual("histogram");

        It should_deserialize_facet_to_HistogramFacetResult_type = () =>
            result.facets["histo1"].ShouldBeOfType<HistogramFacetResult>();

        It should_contain_facet_with_correct_key_value = () =>
            result.facets["histo1"].As<HistogramFacetResult>().entries[0].key.ShouldEqual(10);

        It should_contain_facet_with_correct_count_value = () =>
            result.facets["histo1"].As<HistogramFacetResult>().entries[0].count.ShouldEqual(1);
        
        It should_contain_second_facet_with_correct_key_value = () =>
            result.facets["histo1"].As<HistogramFacetResult>().entries[1].key.ShouldEqual(20);

        It should_contain_second_facet_with_correct_count_value = () =>
            result.facets["histo1"].As<HistogramFacetResult>().entries[1].count.ShouldEqual(2);

        private static JsonNetSerializer jsonSerializer;
        private static SearchResult<object> result;
    }

}