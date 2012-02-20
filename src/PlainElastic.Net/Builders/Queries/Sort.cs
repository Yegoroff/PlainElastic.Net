using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    public class Sort<T> : IJsonConvertible
    {
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
            var fieldName = field.GetPropertyPath();
            
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
                fieldParams = "'order': {0}".SmartQuoteF(order.ToString().Quotate());

            if (!missing.IsNullOrEmpty())
                fieldParams = fieldParams + ", " + "'_missing': {0}".SmartQuoteF(missing.Quotate());

            if (fieldParams.IsNullOrEmpty())
                sortExpressions.Add(field.Quotate());
            else
                sortExpressions.Add("{{ {0} : {{ {1} }} }}".SmartQuoteF(field.Quotate(), fieldParams));

            return this;
        }


        public Sort<T> Script(string script, string type, SortDirection order, string [] @params)
        {
            var expression = "'_script' : {0}, 'type': {1}, 'order': {2}, 'params': {3} ".SmartQuoteF(script, type.Quotate(), order.ToString().Quotate(), @params.JoinWithComma());
            sortExpressions.Add(expression);

            return this;
        }

        public Sort<T> Custom(string customSortExpression)
        {
            var expression = "{{ {0} }}".SmartQuoteF(customSortExpression);
            sortExpressions.Add(expression);
            return this;
        }

   
        string IJsonConvertible.ToJson()
        {
            if (sortExpressions.Count == 0)
                return "";

            var result = "'sort': [{0}]".SmartQuoteF(sortExpressions.JoinWithComma());
            return result;
        }

        public override string ToString()
        {
            return ((IJsonConvertible)this).ToJson();
        }
    }
}