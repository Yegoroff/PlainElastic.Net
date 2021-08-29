using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    public abstract class HistogramFacetBase<TFacet, T> : FacetBase<TFacet, T> where TFacet : HistogramFacetBase<TFacet, T>
    {
        /// <summary>
        /// The field to execute facet against.
        /// </summary>
        public TFacet Field(string fieldName)
        {
            RegisterJsonPart("'field': {0}", fieldName.Quotate());
            return (TFacet)this;
        }

        /// <summary>
        /// The field to execute facet against.
        /// </summary>
        public TFacet Field(Expression<Func<T, object>> field)
        {
            return Field(field.GetPropertyPath());
        }

        /// <summary>
        /// The field to execute facet against.
        /// </summary>
        public TFacet FieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> field)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fieldName = collectionProperty + "." + field.GetPropertyPath();

            return Field(fieldName);
        }

        /// <summary>
        /// The field to check if its value falls within an interval.
        /// </summary>
        public TFacet KeyField(string fieldName)
        {
            RegisterJsonPart("'key_field': {0}", fieldName.Quotate());
            return (TFacet)this;
        }

        /// <summary>
        /// The field to check if its value falls within an interval.
        /// </summary>
        public TFacet KeyField(Expression<Func<T, object>> keyField)
        {
            return KeyField(keyField.GetPropertyPath());
        }

        /// <summary>
        /// The field to check if its value falls within an interval.
        /// </summary>
        public TFacet KeyFieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> keyField)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fieldName = collectionProperty + "." + keyField.GetPropertyPath();

            return KeyField(fieldName);
        }

        /// <summary>
        /// The field to compute aggregated data per interval.
        /// </summary>
        public TFacet ValueField(string fieldName)
        {
            RegisterJsonPart("'value_field': {0}", fieldName.Quotate());
            return (TFacet)this;
        }

        /// <summary>
        /// The field to compute aggregated data per interval.
        /// </summary>
        public TFacet ValueField(Expression<Func<T, object>> valueField)
        {
            return ValueField(valueField.GetPropertyPath());
        }

        /// <summary>
        /// The field to compute aggregated data per interval.
        /// </summary>
        public TFacet ValueFieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> valueField)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fieldName = collectionProperty + "." + valueField.GetPropertyPath();

            return ValueField(fieldName);
        }

        /// <summary>
        /// The script to get value to check if it falls within an interval.
        /// </summary>
        public TFacet KeyScript(string keyScript)
        {
            RegisterJsonPart("'key_script': {0}", keyScript.Quotate());
            return (TFacet)this;
        }

        /// <summary>
        /// The script to get value to compute aggregated data per interval.
        /// </summary>
        public TFacet ValueScript(string valueScript)
        {
            RegisterJsonPart("'value_script': {0}", valueScript.Quotate());
            return (TFacet)this;
        }

        /// <summary>
        /// Sets a scripting language used for scripts.
        /// By default used mvel language.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
        public TFacet Lang(string lang)
        {
            RegisterJsonPart("'lang': {0}", lang.Quotate());
            return (TFacet)this;
        }

        /// <summary>
        /// Sets a scripting language used for scripts.
        /// By default used mvel language.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
        public TFacet Lang(ScriptLangs lang)
        {
            return Lang(lang.AsString());
        }

        /// <summary>
        /// Sets parameters used for scripts.
        /// </summary>
        public TFacet Params(string paramsBody)
        {
            RegisterJsonPart("'params': {0}", paramsBody);
            return (TFacet)this;
        }

    }
}