using System.Collections.Generic;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{

    /// <summary>
    /// A query that filters documents that only have the provided ids. 
    /// Note, this query does not require the _id field to be indexed since it works using the _uid field.
    /// see: http://www.elasticsearch.org/guide/reference/query-dsl/ids-query.html
    /// </summary>    
    public class IdsQuery<T> : QueryBase<IdsQuery<T>>
    {
        private bool hasRequiredParts;

        /// <summary>
        /// The index type this query apply to.
        /// </summary>
        public IdsQuery<T> Type(string type)
        {
            RegisterJsonPart("'type': {0}", type.Quotate());
            return this;
        }

        /// <summary>
        /// The collection of index types this query apply to.
        /// </summary>
        public IdsQuery<T> Types(IEnumerable<string> types)
        {
            string typesJson = JsonHelper.BuildJsonStringsProperty("types", types);
            RegisterJsonPart(typesJson);
            return this;
        }

        /// <summary>
        /// The collection of ids to use as filter.
        /// </summary>
        public IdsQuery<T> Values(IEnumerable<string> values)
        {
            string typesJson = JsonHelper.BuildJsonStringsProperty("values", values);
            RegisterJsonPart(typesJson);
            hasRequiredParts = !typesJson.IsNullOrEmpty();
            return this;
        }


        /// <summary>
        /// Sets the boost value of the query. Defaults to 1.0.
        /// </summary>
        public IdsQuery<T> Boost(double boost = 1)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());

            return this;
        }

        protected override bool HasRequiredParts()
        {
            return hasRequiredParts;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ 'ids': {{ {0} }} }}".AltQuoteF(body);
        }

    }
}