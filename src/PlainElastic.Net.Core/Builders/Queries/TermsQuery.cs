using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A query that match on any (configurable) of the provided terms.
    /// This is a simpler syntax query for using a bool query with several term queries in the should clauses
    /// see: http://www.elasticsearch.org/guide/reference/query-dsl/terms-query.html
    /// </summary>    
    public class TermsQuery<T> : FieldQueryBase<T, TermsQuery<T>>
    {
        private bool hasValues;


        public TermsQuery<T> Values(params string[] values)
        {
            return Values((IEnumerable<string>)values);
        }

        public TermsQuery<T> Values(IEnumerable<string> values)
        {
            if (values != null)
            {
                var termsValues = values.Where(v => !v.IsNullOrEmpty()).Quotate().JoinWithComma();
                if (!termsValues.IsNullOrEmpty())
                {
                    RegisterJsonPart("[ {0} ]", termsValues);
                    hasValues = true;
                }
            }

            return this;
        }
    
        public TermsQuery<T> MinimumMatch(int count)
        {
            RegisterJsonPart("'minimum_match': {0}", count.AsString());

            return this;
        }

        /// <summary>
        /// Sets the boost value of the query. Defaults to 1.0.
        /// </summary>
        public TermsQuery<T> Boost(double boost = 1)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());

            return this;
        }


        protected override bool HasRequiredParts()
        {
            return hasValues;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            if (RegisteredField.IsNullOrEmpty())
                return "{{ 'terms': {{ {0} }} }}".AltQuoteF(body);

            return "{{ 'terms': {{ {0}: {1} }} }}".AltQuoteF(RegisteredField, body);
        }
    }
}