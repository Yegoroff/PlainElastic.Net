using System;
using System.Collections.Generic;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A query can be used when executed across multiple indices, 
    /// allowing to have a query that executes only when executed on an index that matches a specific list of indices,
    /// and another query that executes when it is executed on an index that does not match the listed indices.
    /// see: http://www.elasticsearch.org/guide/reference/query-dsl/indices-query.html
    /// </summary>
    public class IndicesQuery<T> : QueryBase<IndicesQuery<T>>
    {
        private bool hasRequiredParts;

        /// <summary>
        /// A list of indices to match.
        /// </summary>
        public IndicesQuery<T> Indices(IEnumerable<string> indices)
        {
            string propertyJson = JsonHelper.BuildJsonStringsProperty("indices", indices);
            RegisterJsonPart(propertyJson);
            return this;
        }

        /// <summary>
        /// A list of indices to match.
        /// </summary>
        public IndicesQuery<T> Indices(params string[] indices)
        {
            return Indices((IEnumerable<string>)indices);
        }

        /// <summary>
        /// The query to execute on matched indices.
        /// </summary>
        public IndicesQuery<T> Query(Func<Query<T>, Query<T>> query)
        {
            var result = RegisterJsonPartExpression(query);
            hasRequiredParts = hasRequiredParts || !result.GetIsEmpty();
            return this;
        }

        /// <summary>
        /// Sets the query to use when it executes on an index that does not match the indices provided.
        /// </summary>
        public IndicesQuery<T> NoMatchQuery(Func<NoMatchQuery<T>, Query<T>> noMatchQuery)
        {
            RegisterJsonPartExpression(noMatchQuery);            
            return this;
        }

        /// <summary>
        /// The simplified no match query. Use "all" to match all documents, or "none" to math none.
        /// </summary>
        public IndicesQuery<T> NoMatchQuery(IndicesNoMatchMode noMatchQuery)
        {
            RegisterJsonPart("'no_match_query': {0}", noMatchQuery.AsString().Quotate());           
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