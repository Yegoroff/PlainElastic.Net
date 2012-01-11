using System;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.QueryBuilder
{
    public class ExistsFilter<T> : IJsonConvertible
    {
        #region Filter Templates

        private const string existsFilterTemplate = 
@"  {{
        ""exists"": {{
             ""field"" : {0}        
        }}
    }}";

        #endregion


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

            var result = existsFilterTemplate.F(existsField);

            return result;
        }
    }
}