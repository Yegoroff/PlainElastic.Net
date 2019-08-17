using System;
using Machine.Specifications;
using PlainElastic.Net.Serialization;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Serialization
{
    [Subject(typeof(JsonNetSerializer))]
    class When_date_histogram_facets_result_deserialized
    {
        #region Date Histogram Facets Json Result
        private static readonly string dateHistogramFacetsJsonResult =
@"{
    'took': 1,
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
            '_type': 'date_histogram',
            'entries': [
                {
                    'time': 1262304000000,
                    'count': 1
                },
                {
                    'time': 1265068800000,
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
            result = jsonSerializer.ToSearchResult<object>(dateHistogramFacetsJsonResult);
            

        It should_contain_correct_hits_count = () =>
            result.hits.total.ShouldEqual(2);

        It should_contain_facet_with_filter_type = () =>
            result.facets["histo1"]._type.ShouldEqual("date_histogram");

        It should_deserialize_facet_to_DateHistogramFacetResult_type = () =>
            result.facets["histo1"].ShouldBeOfType<DateHistogramFacetResult>();

        It should_contain_facet_with_correct_key_value = () =>
            result.facets["histo1"].As<DateHistogramFacetResult>().entries[0].time.ShouldEqual(1262304000000);

        It should_contain_facet_with_correct_count_value = () =>
            result.facets["histo1"].As<DateHistogramFacetResult>().entries[0].count.ShouldEqual(1);

        It should_contain_facet_with_correct_UtcTime_value = () =>
            result.facets["histo1"].As<DateHistogramFacetResult>().entries[0].UtcTime().ShouldEqual(new DateTime(2010, 01, 01));

        It should_contain_second_facet_with_correct_key_value = () =>
            result.facets["histo1"].As<DateHistogramFacetResult>().entries[1].time.ShouldEqual(1265068800000);

        It should_contain_second_facet_with_correct_count_value = () =>
            result.facets["histo1"].As<DateHistogramFacetResult>().entries[1].count.ShouldEqual(2);

        It should_contain_second_facet_with_correct_UtcTime_value = () =>
            result.facets["histo1"].As<DateHistogramFacetResult>().entries[1].UtcTime().ShouldEqual(new DateTime(2010, 02, 02));


        private static JsonNetSerializer jsonSerializer;
        private static SearchResult<object> result;
    }

}