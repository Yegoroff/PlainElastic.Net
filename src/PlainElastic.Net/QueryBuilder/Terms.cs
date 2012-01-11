using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.QueryBuilder
{
    public class Terms<T> : IJsonConvertible
    {

        #region Query Templates

        private const string termsTemplate = 
@"  {{
        ""terms"": {{
            {0} : [ {1} ]
            {2}
        }}
    }}";

        private const string minimumMatchTemplate = "\"minimum_match\" :{0}";

        #endregion


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
            minimumMatchValue = count.ToString();

            return this;
        }

        

        string IJsonConvertible.ToJson()
        {
            if (termsValues.IsNullOrEmpty())
                return "";

            var minimumMatchPart = "";
            if (!minimumMatchValue.IsNullOrEmpty())
                minimumMatchPart = ", " + minimumMatchTemplate.F(minimumMatchValue);

            var result = termsTemplate.F(termsField, termsValues, minimumMatchPart);

            return result;
        }

    }
}