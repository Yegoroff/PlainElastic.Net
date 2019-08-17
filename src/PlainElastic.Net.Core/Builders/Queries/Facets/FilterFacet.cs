using System;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Allows you to return a count of the hits matching the filter.
    /// see http://www.elasticsearch.org/guide/reference/api/search/facets/filter-facet.html
    /// </summary>
    public class FilterFacet<T> : FacetBase<FilterFacet<T>, T>
    {
       
        /// <summary>
        /// Filter that will be used to count facet matches.
        /// Note, filter facet filters are faster than query facet when using native filters (non query wrapper ones)
        /// </summary>
        public FilterFacet<T> Filter(Func<Filter<T>, Filter<T>> filter)
        {
            RegisterJsonPartExpression(filter);
            return this;
        }


        protected override string ApplyFacetBodyJsonTemplate(string body)
        {
            return body;
        }
        
    }
}