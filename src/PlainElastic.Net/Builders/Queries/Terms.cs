using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    public class Terms<T> : IJsonConvertible
    {
        private string termsValues;
        private string termsField;
        private string minimumMatchValue;


        public Terms<T> Field(Expression<Func<T, object>> field)
        {
            termsField = field.GetQuotatedPropertyName();

            return this;
        }

        public Terms<T> Values(IEnumerable<string> values)
        {
            if (values != null)
                termsValues = values.LowerAndQuotate().JoinWithComma();

            return this;
        }
    
        public Terms<T> MinimumMatch(int count)
        {
            minimumMatchValue = count.AsString();

            return this;
        }

        

        string IJsonConvertible.ToJson()
        {
            if (termsValues.IsNullOrEmpty())
                return "";

            var minimumMatchPart = "";
            if (!minimumMatchValue.IsNullOrEmpty())
                minimumMatchPart = ", 'minimum_match' :{0}".SmartQuoteF(minimumMatchValue);

            var result = "{{ 'terms': {{ {0} : [ {1} ] {2} }} }}".SmartQuoteF(termsField, termsValues, minimumMatchPart);

            return result;
        }

    }
}