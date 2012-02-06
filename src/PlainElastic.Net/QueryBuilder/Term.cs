using System;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.QueryBuilder
{
    public class Term<T> : IJsonConvertible
    {

        #region Query Templates

        private const string termTemplate = @" ""term"": {{ {0} : {{ {1} }} }} ";

        private const string valueTemplate = "\"value\" :{0}";
        private const string boostTemplate = "\"boost\": {0}";

        #endregion


        private string termValue;
        private string termField;
        private string boostValue;


        public Term<T> Field(Expression<Func<T, object>> field)
        {
            termField = field.GetQuotatedPropertyName();

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
            boostValue = boost.ToString().Quotate();
            
            return this;
        }

         
        string IJsonConvertible.ToJson()
        {
            if (termValue.IsNullOrEmpty())
                return "";

            var body = valueTemplate.F(termValue);

            if (!boostValue.IsNullOrEmpty())
                body += ", " + boostTemplate.F(boostValue);

            var result = termTemplate.F(termField, body);

            return result;
        }
    }
}