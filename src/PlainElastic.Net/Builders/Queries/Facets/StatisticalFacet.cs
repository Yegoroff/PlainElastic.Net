using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Allows to compute statistical data on a numeric fields.
    /// The statistical data include count, total, sum of squares, mean (average), minimum, maximum, variance, and standard deviation.
    /// see http://www.elasticsearch.org/guide/reference/api/search/facets/statistical-facet/
    /// </summary>
    public class StatisticalFacet<T> : FacetBase<StatisticalFacet<T>, T>
    {
        private readonly List<string> facetFields = new List<string>();

        /// <summary>
        /// The field to execute statistical facet against.
        /// </summary>
        public StatisticalFacet<T> Field(string fieldName)
        {
            RegisterJsonPart("'field': {0}", fieldName.Quotate());            
            return this;
        }

        /// <summary>
        /// The field to execute statistical facet against.
        /// </summary>
        public StatisticalFacet<T> Field(Expression<Func<T, object>> field)
        {
            return Field(field.GetPropertyPath());
        }

        /// <summary>
        /// The field to execute statistical facet against.
        /// </summary>
        public StatisticalFacet<T> FieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> field)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fieldName = collectionProperty + "." + field.GetPropertyPath();

            return Field(fieldName);
        }


        /// <summary>
        /// The statistical facet can be executed against more than one field, returning the aggregation result across those fields.
        /// </summary>
        public StatisticalFacet<T> Fields(params string[] fields)
        {
            facetFields.AddRange(fields.Quotate());
            return this;
        }

        /// <summary>
        /// The statistical facet can be executed against more than one field, returning the aggregation result across those fields.
        /// </summary>
        public StatisticalFacet<T> Fields(params Expression<Func<T, object>>[] fields)
        {
            foreach (var field in fields)
                facetFields.Add(field.GetQuotatedPropertyPath());

            return this;
        }

        /// <summary>
        /// The statistical facet can be executed against more than one field, returning the aggregation result across those fields.
        /// </summary>
        public StatisticalFacet<T> FieldsOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, params Expression<Func<TProp, object>>[] fields)
        {
            var collectionProperty = collectionField.GetPropertyPath();

            foreach (var field in fields)
            {
                var fieldName = collectionProperty + "." + field.GetPropertyPath();
                facetFields.Add(fieldName.Quotate());
            }

            return this;
        }


        /// <summary>
        /// Allow to define a script to evaluate, with its value used to compute the statistical information.
        /// </summary>
        public StatisticalFacet<T> Script(string script)
        {
            RegisterJsonPart("'script': {0}", script.Quotate());
            return this;
        }


        /// <summary>
        /// Sets a scripting language used for scripts.
        /// By default used mvel language.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
        public StatisticalFacet<T> Lang(string lang)
        {
            RegisterJsonPart("'lang': {0}", lang.Quotate());
            return this;
        }

        /// <summary>
        /// Sets a scripting language used for scripts.
        /// By default used mvel language.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
        public StatisticalFacet<T> Lang(ScriptLangs lang)
        {
            return Lang(lang.AsString());
        }


        /// <summary>
        /// Sets parameters used for scripts.
        /// </summary>
        public StatisticalFacet<T> Params(string paramsBody)
        {
            RegisterJsonPart("'params': {0}", paramsBody);
            return this;
        }



        private string GenerateFieldsFacetPart()
        {
            var fields = facetFields.JoinWithComma();
            if (fields.IsNullOrEmpty())
                return "";

            return "'fields': [{0}]".AltQuoteF(fields);
        }


        protected override string ApplyFacetBodyJsonTemplate(string body)
        {
            string fields = GenerateFieldsFacetPart();
            if (!fields.IsNullOrEmpty())
                body = new[] {fields, body}.JoinWithComma();

            return "'statistical': {{ {0} }}".AltQuoteF(body);
        }
        
    }
}