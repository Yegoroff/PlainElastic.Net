using System;
using System.Linq.Expressions;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    public class ExistsFilter<T> : IJsonConvertible
    {
        private string existsField;
        private bool shouldExists;

        public ExistsFilter<T> Field(Expression<Func<T, object>> field)
        {
            existsField = field.GetQuotatedPropertyName();

            return this;
        }


        public ExistsFilter<T> ShouldExists(bool? value)
        {
            shouldExists = value.HasValue && value.Value;
            return this;
        }



        string IJsonConvertible.ToJson()
        {
            if (!shouldExists)
                return "";

            var result = "{{ 'exists': {{ 'field' : {0} }} }}".SmartQuoteF(existsField);

            return result;
        }
    }
}