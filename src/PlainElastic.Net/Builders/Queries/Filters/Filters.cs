using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    using System;

    /// <summary>
    /// Defines a named filter.
    /// <remarks>
    /// Used in <see cref="FiltersAggregation{T}"/>.
    ///  </remarks>
    /// </summary>
    public class Filters<T> : Filter<T>
    {
        private string _filterName = null;

        /// <summary>
        /// A filter that matches documents using AND boolean operator on other queries.
        /// This filter is more performant then bool filter. 
        /// Can be placed within queries that accept a filter.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/and-filter.html
        /// </summary>
        public Filters<T> FilterName(string name)
        {
            _filterName = name;
            return this;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return string.Format("{{ '{0}' : {1} }} ", _filterName, body.AltQuoteF());
        }
    }
}
