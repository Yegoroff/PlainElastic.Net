using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Facets provide aggregated data based on a search query.
    /// see http://www.elasticsearch.org/guide/reference/api/search/facets/index.html
    /// </summary>
    public class Facets<T> : QueryBase<Facets<T>>
    {

        /// <summary>
        /// Allows to specify field facets that return the N most frequent terms
        /// see http://www.elasticsearch.org/guide/reference/api/search/facets/terms-facet.html
        /// </summary>
        public Facets<T> Terms(Func<TermsFacet<T>, TermsFacet<T>> termsFacet)
        {
            RegisterJsonPartExpression(termsFacet);
            return this;
        }

        /// <summary>
        /// Allows you to return a count of the hits matching the filter.
        /// see http://www.elasticsearch.org/guide/reference/api/search/facets/filter-facet.html
        /// </summary>
        public Facets<T> FilterFacets(Func<FilterFacet<T>, FilterFacet<T>> filterFacet)
        {
            RegisterJsonPartExpression(filterFacet);
            return this;
        }


        protected override bool HasRequiredParts()
        {
            return true;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "'facets': {{ {0} }}".AltQuoteF(body);
        }
    }
}