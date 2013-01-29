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
        /// The ranges of values to aggregate against, in format (to, from)
        /// </summary>
        public RangeFacet<T> Ranges(List<RangeToFrom> ranges)
        {
            var rangeList = new List<string>();

            foreach (var range in ranges)
            {
                if(range.From == null)
                {
                    rangeList.Add(string.Format("{{ 'to': {0} }}", range.To).AltQuote());
                }

                if(range.To == null)
                {
                    rangeList.Add(string.Format("{{ 'from': {0} }}", range.From).AltQuote());
                }

                if (range.From != null && range.To != null)
                {
                    rangeList.Add(string.Format("{{'from': {0}, 'to': {1}}}", range.From, range.To).AltQuote());
                }
            }

            RegisterJsonPart("'ranges': [ {0} ]", rangeList.JoinWithComma());

            return this;
            
        }

        protected override string ApplyFacetBodyJsonTemplate(string body)
        {
            return "'range': {{ {0} }}".AltQuoteF(body);
        }
    }

    public class RangeToFrom
    {
        public int? From { get; set; }
        public int? To { get; set; }
    }
}