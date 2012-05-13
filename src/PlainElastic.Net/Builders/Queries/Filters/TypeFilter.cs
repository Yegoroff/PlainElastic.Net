using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Filters documents matching the provided document / mapping type. 
    /// Note, this filter can work even when the _type field is not indexed (using the _uid field)
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/type-filter.html
    /// </summary>
    public class TypeFilter<T> : QueryBase<TypeFilter<T>>
    {

        /// <summary>
        /// Limits the number of documents (per shard) to execute on.
        /// </summary>
        public TypeFilter<T> Value(string type)
        {
            if (!type.IsNullOrEmpty())
            {
                RegisterJsonPart("'value': {0}", type.Quotate());
            }
            return this;
        }


        protected override bool HasRequiredParts()
        {
            return true;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ 'type': {{ {0} }} }}".AltQuoteF(body);
        }
    }
}