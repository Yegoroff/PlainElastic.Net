using System;
using System.Collections.Generic;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A filter that will execute the wrapped filter only for the specified indices, and "match_all" when it does not match those indices (by default).
    /// </summary>
    public class IndicesFilter<T> : QueryBase<IndicesFilter<T>>
    {
        private bool hasRequiredParts;

        /// <summary>
        /// A list of indices to match.
        /// </summary>
        public IndicesFilter<T> Indices(IEnumerable<string> indices)
        {
            string propertyJson = JsonHelper.BuildJsonStringsProperty("indices", indices);
            RegisterJsonPart(propertyJson);
            return this;
        }

        /// <summary>
        /// A list of indices to match.
        /// </summary>
        public IndicesFilter<T> Indices(params string[] indices)
        {
            return Indices((IEnumerable<string>)indices);
        }

        /// <summary>
        /// The filter to execute on matched indices.
        /// </summary>
        public IndicesFilter<T> Filter(Func<Filter<T>, Filter<T>> filter)
        {
            var result = RegisterJsonPartExpression(filter);
            hasRequiredParts = hasRequiredParts || !result.GetIsEmpty();
            return this;
        }

        /// <summary>
        /// Sets the filter to use when it executes on an index that does not match the indices provided.
        /// </summary>
        public IndicesFilter<T> NoMatchFilter(Func<NoMatchFilter<T>, Filter<T>> noMatchFilter)
        {
            RegisterJsonPartExpression(noMatchFilter);            
            return this;
        }

        /// <summary>
        /// Sets the no match filter, can either be <tt>all</tt> or <tt>none</tt>.
        /// </summary>
        public IndicesFilter<T> NoMatchFilter(IndicesNoMatchMode noMatchFilter)
        {
            RegisterJsonPart("'no_match_filter': {0}", noMatchFilter.AsString().Quotate());           
            return this;
        }

        /// <summary>
        /// Allows to name filter, so the search response will include for each hit the matched_filters 
        /// it matched on (note, this feature make sense for or / bool filters).
        /// http://www.elasticsearch.org/guide/reference/api/search/named-filters.html 
        /// </summary>
        public IndicesFilter<T> Name(string filterName)
        {
            RegisterJsonPart("'_name': {0}", filterName.Quotate());
            return this;
        }


        protected override bool HasRequiredParts()
        {
            return hasRequiredParts;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ 'indices': {{ {0} }} }}".AltQuoteF(body);
        }

    }
}