using System;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{

    /// <summary>
    /// A query that applies a filter to the results of another query. This query maps to Lucene FilteredQuery.
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/filtered-query.html
    /// </summary>    
    public class FilteredQuery<T> : QueryBase<FilteredQuery<T>>
    {

        public FilteredQuery<T> Query(Func<Query<T>, Query<T>> query)
        {
            RegisterJsonPartExpression(query);

            return this;
        }

        public FilteredQuery<T> Filter(Func<Filter<T>, Filter<T>> filter)
        {
            RegisterJsonPartExpression(filter);

            return this;
        }

        protected override bool HasRequiredParts()
        {
            return true;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ 'filtered': {{ {0} }} }}".AltQuoteF(body);
        }

    }
}