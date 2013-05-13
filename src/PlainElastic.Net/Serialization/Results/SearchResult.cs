using System.Collections.Generic;
using System.Linq;

namespace PlainElastic.Net.Serialization
{
    public class SearchResult<T> : BaseResult
    {
        public int took;
        public bool timed_out;
        public ShardsResult _shards;
        public Hits hits;
        public Facets facets;
        
        public IEnumerable<T> Documents
        {
            get { return hits.hits.Select(hit => hit._source); }
        }


        public class Hits
        {
            public int total;
            public double ?max_score;
            public Hit[] hits;
        }

        public class Hit
        {
            public string _index;
            public string _type;
            public string _id;
            public double _score;
            public dynamic[] sort;
            public T _source;
            public Highlight highlight;
        }

        public class Facets : Dictionary<string, FacetResult>
        {
            public TFacet Facet<TFacet>(string facetName) where TFacet : FacetResult
            {
                return this[facetName] as TFacet;
            }
        }

        public class Highlight : Dictionary<string, string[]> 
        { }
    }
}
