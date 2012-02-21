using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Matches documents that have fields that contain a term (not analyzed). The term query maps to Lucene TermQuery
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/term-query.html
    /// </summary>
    public class Term<T> : IJsonConvertible
    {
        private string termValue;
        private string termField;
        private string boostValue;


        public Term<T> Field(Expression<Func<T, object>> field)
        {
            termField = field.GetQuotatedPropertyPath();

            return this;
        }

        public Term<T> FieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> field)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fieldName = collectionProperty + "." + field.GetPropertyPath();

            termField = fieldName.Quotate();

            return this;
        }



        public Term<T> Value(object value)
        {
            if (value == null)
                return this;

            return Value(value.ToString());
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

        public override string ToString()
        {
            return ((IJsonConvertible)this).ToJson();
        }
    }
}