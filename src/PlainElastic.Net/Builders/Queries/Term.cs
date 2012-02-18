using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    public class Term<T> : IJsonConvertible
    {
        private string termValue;
        private string termField;
        private string boostValue;


        public Term<T> Field(Expression<Func<T, object>> field)
        {
            termField = field.GetQuotatedPropertyName();

            return this;
        }

        public Term<T> FieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> field)
        {
            var collectionProperty = collectionField.GetPropertyName();
            var fieldName = collectionProperty + "." + field.GetPropertyName();

            termField = fieldName.Quotate();

            return this;
        }



        public Term<T> Value(object value)
        {
            if (value != null)
                termValue = value.ToString().LowerAndQuotate();

            return this;
        }

        public Term<T> Value(string value)
        {
            if (!value.IsNullOrEmpty())
                termValue = value.LowerAndQuotate();

            return this;
        }

        public Term<T> Boost(double boost)
        {
            boostValue = boost.AsString();
            
            return this;
        }

         
        string IJsonConvertible.ToJson()
        {
            if (termValue.IsNullOrEmpty())
                return "";

            var body = "'value': {0}".SmartQuoteF(termValue);

            if (!boostValue.IsNullOrEmpty())
                body += ", 'boost': {0}".SmartQuoteF(boostValue);

            var result = "{{ 'term': {{ {0} : {{ {1} }} }} }}".SmartQuoteF(termField, body);

            return result;
        }
    }
}