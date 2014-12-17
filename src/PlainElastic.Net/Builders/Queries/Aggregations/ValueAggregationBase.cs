using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
	/// A base class for all multi- and single-value aggregations
    /// </summary>
    public abstract class ValueAggregationBase<TAggregation, T> : AggregationBase<TAggregation, T> where TAggregation : ValueAggregationBase<TAggregation, T>
    {
        /// <summary>
		/// The field to execute aggregation against.
        /// </summary>
        public TAggregation Field(string fieldName)
        {
            RegisterJsonPart("'field': {0}", fieldName.Quotate());
            return (TAggregation)this;
        }

        /// <summary>
		/// The field to execute aggregation against.
        /// </summary>
        public TAggregation Field(Expression<Func<T, object>> field)
        {
            return Field(field.GetPropertyPath());
        }

        /// <summary>
		/// The field to execute aggregation against.
        /// </summary>
        public TAggregation FieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> field)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fieldName = collectionProperty + "." + field.GetPropertyPath();

            return Field(fieldName);
        }


        /// <summary>
		/// Allow to define a script to evaluate, with its value used to compute the aggregation.
        /// </summary>
        public TAggregation Script(string script)
        {
            RegisterJsonPart("'script': {0}", script.Quotate());
            return (TAggregation)this;
        }


        /// <summary>
        /// Sets a scripting language used for scripts.
        /// By default used groovy language.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
        public TAggregation Lang(string lang)
        {
            RegisterJsonPart("'lang': {0}", lang.Quotate());
            return (TAggregation)this;
        }

        /// <summary>
        /// Sets a scripting language used for scripts.
        /// By default used groovy language.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
        public TAggregation Lang(ScriptLangs lang)
        {
            return Lang(lang.AsString());
        }

        /// <summary>
        /// Sets parameters used for scripts.
        /// </summary>
        public TAggregation Params(string paramsBody)
        {
            RegisterJsonPart("'params': {0}", paramsBody);
            return (TAggregation)this;
        }

    }
}