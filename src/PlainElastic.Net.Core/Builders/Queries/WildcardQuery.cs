using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Matches documents that have fields matching a wildcard expression (not analyzed).
    /// Supported wildcards are *, which matches any character sequence (including the empty one), 
    /// and ?, which matches any single character.
    /// Note that this query can be slow, as it needs to iterate over many terms. 
    /// In order to prevent extremely slow wildcard queries, 
    /// a wildcard term should not start with one of the wildcards * or ?. 
    /// The wildcard query maps to Lucene WildcardQuery.
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/wildcard-query.html
    /// </summary>
    public class WildcardQuery<T> : FieldQueryBase<T, WildcardQuery<T>>
    {
        private bool hasValue;

        public WildcardQuery<T> Value(string value)
        {
            if (!value.IsNullOrEmpty())
            {
                RegisterJsonPart("'value': {0}", value.Quotate());
                hasValue = true;
            }

            return this;
        }

        /// <summary>
        /// Sets the boost value of the query. Defaults to 1.0.
        /// </summary>
        public WildcardQuery<T> Boost(double boost = 1)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());
            
            return this;
        }


        /// <summary>
        /// Allows to control how  multi term queries will get rewritten.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/multi-term-rewrite.html
        /// </summary>
        public WildcardQuery<T> Rewrite(Rewrite rewrite, int n = 0)
        {
            var rewriteValue = rewrite.GetRewriteValue(n);
            RegisterJsonPart("'rewrite': {0}", rewriteValue.Quotate());
            return this;
        }




        protected override bool HasRequiredParts()
        {
            return hasValue;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            if (RegisteredField.IsNullOrEmpty())
                return "{{ 'wildcard': {{ {0} }} }}".AltQuoteF(body);

            return "{{ 'wildcard': {{ {0}: {{ {1} }} }} }}".AltQuoteF(RegisteredField, body);
        }
        
    }
}