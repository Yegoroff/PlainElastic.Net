using System;
using System.Linq.Expressions;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    public class TermFilter<T> : IJsonConvertible
    {
        private string termField;
        private string termValue;


        public TermFilter<T> Field(Expression<Func<T, object>> field)
        {
            termField = field.GetQuotatedPropertyName();

            return this;
        }


        public TermFilter<T> Value(object value)
        {
            termValue = value.ToString().LowerAndQuotate();

            return this;
        }      

        public TermFilter<T> Value(string value)
        {
            termValue = value.Quotate();            

            return this;
        }


        string IJsonConvertible.ToJson()
        {
            if (termValue.IsNullOrEmpty())
                return "";

            var result = "{{ 'term': {{ {0} : {1} }} }}".SmartQuoteF(termField, termValue);

            return result;
        }
    }
}