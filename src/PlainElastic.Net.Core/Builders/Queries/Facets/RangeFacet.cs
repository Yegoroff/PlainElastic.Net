using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Allows to specify a set of ranges and get both the number of docs (count) that fall within each range,
    /// and aggregated data either based on the field, or using another field.
    /// see http://www.elasticsearch.org/guide/reference/api/search/facets/range-facet.html
    /// </summary>
    public class RangeFacet<T> : FacetBase<RangeFacet<T>, T>
    {
        private bool hasValue;

        /// <summary>
        /// The field to execute range facet against.
        /// </summary>
        public RangeFacet<T> Field(string fieldName)
        {
            RegisterJsonPart("'field': {0}", fieldName.Quotate());            
            return this;
        }

        /// <summary>
        /// The field to execute range facet against.
        /// </summary>
        public RangeFacet<T> Field(Expression<Func<T, object>> field)
        {
            return Field(field.GetPropertyPath());
        }

        /// <summary>
        /// The field to execute range facet against.
        /// </summary>
        public RangeFacet<T> FieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> field)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fieldName = collectionProperty + "." + field.GetPropertyPath();

            return Field(fieldName);
        }


        /// <summary>
        /// The field to check if its value falls within a range.
        /// </summary>
        public RangeFacet<T> KeyField(string fieldName)
        {
            RegisterJsonPart("'key_field': {0}", fieldName.Quotate());
            return this;
        }

        /// <summary>
        /// The field to check if its value falls within a range.
        /// </summary>
        public RangeFacet<T> KeyField(Expression<Func<T, object>> keyField)
        {
            return KeyField(keyField.GetPropertyPath());
        }

        /// <summary>
        /// The field to check if its value falls within a range.
        /// </summary>
        public RangeFacet<T> KeyFieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> keyField)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fieldName = collectionProperty + "." + keyField.GetPropertyPath();

            return KeyField(fieldName);
        }


        /// <summary>
        /// The field to compute aggregated data per range.
        /// </summary>
        public RangeFacet<T> ValueField(string fieldName)
        {
            RegisterJsonPart("'value_field': {0}", fieldName.Quotate());
            return this;
        }

        /// <summary>
        /// The field to compute aggregated data per range.
        /// </summary>
        public RangeFacet<T> ValueField(Expression<Func<T, object>> valueField)
        {
            return ValueField(valueField.GetPropertyPath());
        }

        /// <summary>
        /// The field to compute aggregated data per range.
        /// </summary>
        public RangeFacet<T> ValueFieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> valueField)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fieldName = collectionProperty + "." + valueField.GetPropertyPath();

            return ValueField(fieldName);
        }


        /// <summary>
        /// The script to get value to check if it falls within a range.
        /// </summary>
        public RangeFacet<T> KeyScript(string keyScript)
        {
            RegisterJsonPart("'key_script': {0}", keyScript.Quotate());
            return this;
        }


        /// <summary>
        /// The script to get value to compute aggregated data per range.
        /// </summary>
        public RangeFacet<T> ValueScript(string valueScript)
        {
            RegisterJsonPart("'value_script': {0}", valueScript.Quotate());
            return this;
        }


        /// <summary>
        /// The ranges of values to aggregate against, in format (from, to)
        /// </summary>
        public RangeFacet<T> Ranges(Func<RangeFromTo, RangeFromTo> ranges)
        {
            hasValue = !RegisterJsonPartExpression(ranges).GetIsEmpty();
            return this;
        }


        protected override string ApplyFacetBodyJsonTemplate(string body)
        {
            return "'range': {{ {0} }}".AltQuoteF(body);
        }

        protected override bool HasRequiredParts()
        {
            return hasValue;
        }

    }
}