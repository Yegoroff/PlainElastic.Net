using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.QueryBuilder
{
    public class Sort<T> : IJsonConvertible
    {
        #region Query Templates

        private const string sortTemplate = "\"sort\": [{0}]";

        private const string fieldTemplate = "{{ {0} : {{ {1} }} }}";
        private const string orderTemplate = "\"order\": {0}";
        private const string missingTemplate = "\"_missing\": {0}";
        private const string scriptTemplate = "\"_script\" : {0}, \"type\": {1}, \"order\": {2}, \"params\": {3} ";
        private const string customTemplate = "{{ {0} }}";

        #endregion


        private readonly List<string> sortExpressions = new List<string>();


        /// <summary>
        /// Sort result using specified field.
        /// There can be several Sort parameters (order is important).
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="order">The sort order. By default descendant.</param>
        /// <param name="missing">The missing value handling strategy. Use _last, _first or custom value.</param>
        /// <returns></returns>
        public Sort<T> Field(Expression<Func<T, object>> field, SortDirection order = SortDirection.desc, string missing = null)
        {
            var fieldName = field.GetPropertyName();
            
            return Field(fieldName, order, missing);
        }

        /// <summary>
        /// Sort result using specified field.
        /// There can be several Sort parameters (order is important).
        /// </summary>
        /// <param name="field">The field. Use _score to sort by score.</param>
        /// <param name="order">The sort order. By default descendant.</param>
        /// <param name="missing">The missing value handling strategy. Use _last, _first or custom value.</param>
        /// <returns></returns>
        public Sort<T> Field(string field, SortDirection order = SortDirection.desc, string missing = null)
        {
            var fieldParams = "";
            if (order != SortDirection.desc)
                fieldParams = orderTemplate.F(order);

            if (!missing.IsNullOrEmpty())
                fieldParams = fieldParams + ", " + missingTemplate.F(missing);  

            if (fieldParams.IsNullOrEmpty())
                sortExpressions.Add(field.Quotate());
            else 
                sortExpressions.Add(fieldTemplate.F(field.Quotate(), fieldParams));

            return this;
        }


        public Sort<T> Script(string script, string type, SortDirection order, string [] @params)
        {

            var expression = scriptTemplate.F(script, type, order.ToString(), @params.JoinWithComma() );
            sortExpressions.Add(expression);

            return this;
        }

        public Sort<T> Custom(string customSortExpression)
        {
            var expression = customTemplate.F(customSortExpression);
            sortExpressions.Add(expression);
            return this;
        }

   
        string IJsonConvertible.ToJson()
        {
            if (sortExpressions.Count == 0)
                return "";

            var result = sortTemplate.F(sortExpressions.JoinWithComma());
            return result;
        }
    }
}