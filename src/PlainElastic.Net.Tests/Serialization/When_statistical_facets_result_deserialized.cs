using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using PlainElastic.Net.Serialization;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Serialization
{
    [Subject(typeof(JsonNetSerializer))]
    class When_statistical_facets_result_deserialized
    {
        #region Statistical Facets Json Result
        private static readonly string statisticalFacetsJsonResult =
@"{
    'took': 12,
    'timed_out': false,
    '_shards': {
        'total': 10,
        'successful': 10,
        'failed': 0
    },
    'hits': {
        'total': 759,
        'max_score': 0.0,
        'hits': [
            
        ]
    },
    'facets': {
        'stats1': {
            '_type': 'statistical',
            'count': 759,
            'total': 7921.61,
            'min': 2.0,
            'max': 175.0,
            'mean': 10.436903820816864,
            'sum_of_squares': 167353.58289999998,
            'variance': 111.5632427193398,
            'std_deviation': 10.56235024600774
        }
    }
}".AltQuote();
        #endregion

        Establish context = () => 
        {
            jsonSerializer = new JsonNetSerializer();
        };


        Because of = () =>
            result = jsonSerializer.ToSearchResult<object>(statisticalFacetsJsonResult);
            

        It should_contain_correct_hits_count = () =>
            result.hits.total.ShouldEqual(759);

        It should_contain_Statistical_facet_with_terms_type = () =>
            result.facets["stats1"]._type.ShouldEqual("statistical");

        It should_deserialize_Statistical_facet_to_StatisticalFacetResult_type = () =>
            result.facets["stats1"].ShouldBeOfType<StatisticalFacetResult>();

        It should_contain_Statistical_facet_with_correct_total = () =>
            result.facets["stats1"].As<StatisticalFacetResult>().total.ShouldEqual(7921.61);

        It should_contain_Statistical_facet_with_correct_min = () =>
            result.facets["stats1"].As<StatisticalFacetResult>().min.ShouldEqual(2);

        It should_contain_Statistical_facet_with_correct_max = () =>
            result.facets["stats1"].As<StatisticalFacetResult>().max.ShouldEqual(175);

        It should_contain_Statistical_facet_with_correct_mean = () =>
            result.facets["stats1"].As<StatisticalFacetResult>().mean.ShouldEqual(10.436903820816864);

        It should_contain_Statistical_facet_with_correct_sum_of_squares = () =>
            result.facets["stats1"].As<StatisticalFacetResult>().sum_of_squares.ShouldEqual(167353.58289999998);

        It should_contain_Statistical_facet_with_correct_variance = () =>
            result.facets["stats1"].As<StatisticalFacetResult>().variance.ShouldEqual(111.5632427193398);

        It should_contain_Statistical_facet_with_correct_std_deviation = () =>
            result.facets["stats1"].As<StatisticalFacetResult>().std_deviation.ShouldEqual(10.56235024600774);


        private static JsonNetSerializer jsonSerializer;
        private static SearchResult<object> result;
    }

}