using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using PlainElastic.Net.Serialization;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Serialization
{
    [Subject(typeof(JsonNetSerializer))]
    class When_terms_stats_facets_result_deserialized
    {
        #region TermsStat Facets Json Result
        private static readonly string termsStatFacetsJsonResult =
@"{
    'took': 7,
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
        'TestTermsStats': {
            '_type': 'terms_stats',
            'missing': 1,
            'terms': [
                {
                    'term': 'One',
                    'count': 596,
                    'total_count': 596,
                    'min': 2.0,
                    'max': 35.0,
                    'total': 4876.5,
                    'mean': 8.182046979865772
                },
                {
                    'term': 'Two',
                    'count': 125,
                    'total_count': 125,
                    'min': 6.5,
                    'max': 175.0,
                    'total': 2289.5,
                    'mean': 18.316
                }
            ]
        }
    }
}".AltQuote();
        #endregion

        Establish context = () => 
        {
            jsonSerializer = new JsonNetSerializer();
            
            expectedFacetTerms = new[] {
                new TermsStatsFacetResult.Term{ term ="One", count = 596, total_count = 596, min = 2.0, max = 35.0, total = 4876.5, mean = 8.182046979865772},
                new TermsStatsFacetResult.Term{ term ="Two", count = 125, total_count = 125, min = 6.5, max = 175.0, total = 2289.5, mean = 18.316 }
            };
        };


        Because of = () => result = jsonSerializer.ToSearchResult<object>(termsStatFacetsJsonResult);
            

        It should_contain_correct_hits_count = () =>
            result.hits.total.ShouldEqual(759);

        It should_contain_TermsStats_facet_with_terms_type = () =>
            result.facets["TestTermsStats"]._type.ShouldEqual("terms_stats");

        It should_deserialize_TermsStats_facet_to_TermsStatsFacetResults_type = () =>
            result.facets["TestTermsStats"].ShouldBeOfType<TermsStatsFacetResult>();

        It should_contain_TermsStats_facet_with_correct_missing_count = () =>
            result.facets["TestTermsStats"].As<TermsStatsFacetResult>().missing.ShouldEqual(1);

        It should_contain_TermsStats_facet_with_2_terms_stats_facets = () =>
            result.facets["TestTermsStats"].As<TermsStatsFacetResult>().terms.Count.ShouldEqual(2);

        It should_contain_TermsStats_facet_with_2_term_facets_named_One_Two = () =>
            result.facets["TestTermsStats"].As<TermsStatsFacetResult>().terms.ShouldBeSameAs(expectedFacetTerms).ShouldBeTrue();
        

        private static JsonNetSerializer jsonSerializer;
        private static SearchResult<object> result;
        private static TermsStatsFacetResult.Term[] expectedFacetTerms;
    }


    public static class TermsStatsFacetComparator
    {
        public static bool ShouldBeSameAs(this IEnumerable<TermsStatsFacetResult.Term> terms, TermsStatsFacetResult.Term[] expectedTerms)
        {
            return terms.Select((term, i) => 
                term.term == expectedTerms[i].term  &&
                term.count == expectedTerms[i].count &&
                term.total_count == expectedTerms[i].total_count &&
                term.min == expectedTerms[i].min &&
                term.max == expectedTerms[i].max &&
                term.total == expectedTerms[i].total &&
                term.mean == expectedTerms[i].mean
                )                
                .All(b => b);
        }
    }
}