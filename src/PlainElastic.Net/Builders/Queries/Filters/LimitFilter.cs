using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A limit filter limits the number of documents (per shard) to execute on.
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/limit-filter.html
    /// </summary>    
    public class LimitFilter<T> : QueryBase<LimitFilter<T>>
    {

        /// <summary>
        /// Limits the number of documents (per shard) to execute on.
        /// </summary>
        public LimitFilter<T> Value(int? value)
        {
            if (value.HasValue)
            {
                RegisterJsonPart("'value': {0}", value.AsString());
            }

            return this;
        }

        protected override bool HasRequiredParts()
        {
            return true;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ 'limit': {{ {0} }} }}".AltQuoteF(body);
        }
    }
}