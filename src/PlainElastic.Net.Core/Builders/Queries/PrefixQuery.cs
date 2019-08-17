using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Matches documents that have fields containing terms with a specified prefix (not analyzed).
    /// The prefix query maps to Lucene PrefixQuery
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/prefix-query.html
    /// </summary>
    public class PrefixQuery<T> : FieldQueryBase<T, PrefixQuery<T>>
    {
        private bool hasValue;


        public PrefixQuery<T> Prefix(string prefix)
        {
            if (!prefix.IsNullOrEmpty())
            {
                RegisterJsonPart("'prefix': {0}", prefix.Quotate());
                hasValue = true;
            }

            return this;
        }

        /// <summary>
        /// Sets the boost value of the query. Defaults to 1.0.
        /// </summary>
        public PrefixQuery<T> Boost(double boost = 1)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());
            
            return this;
        }

        /// <summary>
        /// Allows to control how  multi term queries will get rewritten.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/multi-term-rewrite.html
        /// </summary>
        public PrefixQuery<T> Rewrite(Rewrite rewrite, int n = 0)
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
                return "{{ 'prefix': {{ {0} }} }}".AltQuoteF(body);

            return "{{ 'prefix': {{ {0}: {{ {1} }} }} }}".AltQuoteF(RegisteredField, body);
        }

    }
}