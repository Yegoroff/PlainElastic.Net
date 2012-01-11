using System;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.QueryBuilder
{
    public class TermFilter<T> : IJsonConvertible
    {

        #region Filter Templates

        private const string termFilterTemplate = 
@"  {{
        ""term"": {{
             {0} : {1}        
        }}
    }}";

        #endregion


        private string termField;
        private string termValue;


        public TermFilter<T> Field(Expression<Func<T, object>> field)
        {
            termField = field.GetQuotatedPropertyName();

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

            var result = termFilterTemplate.F(termField, termValue);

            return result;
        }
    }
}