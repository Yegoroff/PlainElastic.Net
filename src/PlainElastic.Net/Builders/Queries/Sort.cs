using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    public class Sort<T> : QueryBase<Sort<T>>
    {

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
            var fieldParams = new List<string>();
            if (order != SortDirection.desc)
                fieldParams.Add("'order': {0}".SmartQuoteF(order.ToString().Quotate()));

            if (!missing.IsNullOrEmpty())
                fieldParams.Add("'missing': {0}".SmartQuoteF(missing.Quotate()));

            if (fieldParams.Any())
                RegisterJsonPart("{{ {0}: {{ {1} }} }}".SmartQuoteF(field.Quotate(), fieldParams.JoinWithComma()));
            else
                RegisterJsonPart(field.Quotate());                

            return this;
        }


        public Sort<T> Script(string script, string type, SortDirection order, string [] @params)
        {
            var expression = "'_script' : {0}, 'type': {1}, 'order': {2}, 'params': {3} ".SmartQuoteF(script, type.Quotate(), order.ToString().Quotate(), @params.JoinWithComma());
            RegisterJsonPart(expression);

            return this;
        }


        protected override bool HasRequiredParts()
        {
            return true;
        }


        protected override string ApplyJsonTemplate(string body)
        {
            return "'sort': [{0}]".SmartQuoteF(body);

        }
    }
}