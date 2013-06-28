using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using PlainElastic.Net.Serialization;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Serialization
{
    [Subject(typeof(JsonNetSerializer))]
    class When_terms_facets_result_deserialized
    {
        #region Terms Facets Json Result
        private static readonly string termsFacetsJsonResult =
@"{
    'took': 0,
    'timed_out': false,
    '_shards': {
        'total': 5,
        'successful': 5,
        'failed': 0
    },
    'hits': {
        'total': 100,
        'max_score': 1.0,
        'hits': []
    },
    'facets': {
        'TestTerms': {
            '_type': 'terms',
            'missing': 200,
            'total': 6000,
            'other': 3000,
            'terms': [
                {
                    'term': 'One',
                    'count': 1000
                },
                {
                    'term': 'Two',
                    'count': 2000
                },
                {
                    'term': 'Three',
                    'count': 3000
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
                new TermsFacetResult.Term{ term ="One", count = 1000 },
                new TermsFacetResult.Term{ term ="Two", count = 2000 },
                new TermsFacetResult.Term{ term ="Three", count = 3000 }
            };
        };


        Because of = () => result = jsonSerializer.ToSearchResult<object>(termsFacetsJsonResult);
            

        It should_contain_correct_hits_count = () =>
            result.hits.total.ShouldEqual(100);

        It should_contain_TestTerms_facet_with_terms_type = () =>
            result.facets["TestTerms"]._type.ShouldEqual("terms");

        It should_deserialize_TestTerms_facet_to_TermsFacetResults_type = () =>
            result.facets["TestTerms"].ShouldBeOfType<TermsFacetResult>();

        It should_contain_TestTerms_facet_with_correct_total_count = () =>
            result.facets["TestTerms"].As<TermsFacetResult>().total.ShouldEqual(6000);

        It should_contain_TestTerms_facet_with_correct_missing_count = () =>
            result.facets["TestTerms"].As<TermsFacetResult>().missing.ShouldEqual(200);

        It should_contain_TestTerms_facet_with_correct_other_count = () =>
            result.facets["TestTerms"].As<TermsFacetResult>().other.ShouldEqual(3000);

        It should_contain_TestTerms_facet_with_3_terms_facets = () =>
            result.facets["TestTerms"].As<TermsFacetResult>().terms.Count.ShouldEqual(3);

        It should_contain_TestTerms_facet_with_3_term_facets_named_One_Two_Three = () =>
            result.facets["TestTerms"].As<TermsFacetResult>().terms.ShouldBeSameAs(expectedFacetTerms).ShouldBeTrue();
        

        private static JsonNetSerializer jsonSerializer;
        private static SearchResult<object> result;
        private static TermsFacetResult.Term[] expectedFacetTerms;
    }


    public static class TermsFacetComparator
    {
        public static bool ShouldBeSameAs(this IEnumerable<TermsFacetResult.Term> terms, TermsFacetResult.Term[] expectedTerms)
        {
            return terms.Select((term, i) => term.term == expectedTerms[i].term && term.count == expectedTerms[i].count).All(b => b);
        }
    }
}