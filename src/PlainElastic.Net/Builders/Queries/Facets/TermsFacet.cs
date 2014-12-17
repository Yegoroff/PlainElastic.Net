using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Allows to specify field facets that return the N most frequent terms
    /// see http://www.elasticsearch.org/guide/reference/api/search/facets/terms-facet.html
    /// </summary>
    public class TermsFacet<T> : FacetBase<TermsFacet<T>, T>
    {
        private readonly List<string> facetFields = new List<string>();

        /// <summary>
        /// The field to execute term facet against.
        /// </summary>
        public TermsFacet<T> Field(string fieldName)
        {
            RegisterJsonPart("'field': {0}", fieldName.Quotate());            
            return this;
        }

        /// <summary>
        /// The field to execute term facet against.
        /// </summary>
        public TermsFacet<T> Field(Expression<Func<T, object>> field)
        {
            return Field(field.GetPropertyPath());
        }

        /// <summary>
        /// The field to execute term facet against.
        /// </summary>
        public TermsFacet<T> FieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> field)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fieldName = collectionProperty + "." + field.GetPropertyPath();

            return Field(fieldName);
        }


        /// <summary>
        /// The term facet can be executed against more than one field, returning the aggregation result across those fields.
        /// </summary>
        public TermsFacet<T> Fields(params string[] fields)
        {
            facetFields.AddRange(fields.Quotate());
            return this;
        }

        /// <summary>
        /// The term facet can be executed against more than one field, returning the aggregation result across those fields.
        /// </summary>
        public TermsFacet<T> Fields(params Expression<Func<T, object>>[] fields)
        {
            foreach (var field in fields)
                facetFields.Add(field.GetQuotatedPropertyPath());

            return this;
        }

        /// <summary>
        /// The term facet can be executed against more than one field, returning the aggregation result across those fields.
        /// </summary>
        public TermsFacet<T> FieldsOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, params Expression<Func<TProp, object>>[] fields)
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
        /// Allows to control the ordering of the terms facets, to be ordered by count, term, reverse_count or reverse_term. The default is count.
        /// </summary>
        public TermsFacet<T> Order(TermsFacetOrder order = TermsFacetOrder.count)
        {
            RegisterJsonPart("'order': {0}", order.AsString().Quotate());
            return this;
        }

        /// <summary>
        /// The number of the most frequent terms to return.
        /// </summary>
        public TermsFacet<T> Size(int size)
        {
            RegisterJsonPart("'size': {0}", size.AsString());

            return this;
        }

        /// <summary>
        /// Allow to get all the terms in the terms facet, ones that do not match a hit, will have a count of 0.
        /// Note, this should not be used with fields that have many terms.
        /// </summary>
        public TermsFacet<T> AllTerms(bool allTerms = true)
        {
            RegisterJsonPart("'all_terms': {0}", allTerms.AsString());

            return this;
        }

        /// <summary>
        /// Allows to specify a set of terms that should be excluded from the terms facet request result.
        /// </summary>
        public TermsFacet<T> Exclude(params string[] excludeTerms)
        {
            RegisterJsonPart("'exclude': [ {0} ]", excludeTerms.Quotate().JoinWithComma());

            return this;
        }

        /// <summary>
        /// The terms API allows to define regex expression that will control which terms will be included in the faceted list.
        /// </summary>
        public TermsFacet<T> Regex(string regex)
        {
            RegisterJsonPart("'regex': {0}", regex.Quotate());

            return this;
        }

        /// <summary>
        /// Allows to control the ordering of the terms facets, to be ordered by count, term, reverse_count or reverse_term. The default is count.
        /// see http://docs.oracle.com/javase/6/docs/api/java/util/regex/Pattern.html#field_summary
        /// </summary>
        public TermsFacet<T> RegexFlags(RegexFlags regexFlags)
        {
            RegisterJsonPart("'regex_flags': {0}", regexFlags.AsString().Quotate());
            return this;
        }

        /// <summary>
        /// Allow to define a script for terms facet to process the actual term
        /// that will be used in the term facet collection, and also optionally control its inclusion or not.
        /// </summary>
        public TermsFacet<T> Script(string script)
        {
            RegisterJsonPart("'script': {0}", script.Quotate());
            return this;
        }

        /// <summary>
        /// Allow to define a script for terms facet to process the actual term
        /// that will be used in the term facet collection, and also optionally control its inclusion or not.
        /// </summary>
        public TermsFacet<T> ScriptField(string scriptField)
        {
            RegisterJsonPart("'script_field': {0}", scriptField.Quotate());
            return this;
        }


        /// <summary>
        /// Sets a scripting language used for scripts.
        /// By default used mvel language.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
        public TermsFacet<T> Lang(string lang)
        {
            RegisterJsonPart("'lang': {0}", lang.Quotate());
            return this;
        }

        /// <summary>
        /// Sets a scripting language used for scripts.
        /// By default used mvel language.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
        public TermsFacet<T> Lang(ScriptLangs lang)
        {
            return Lang(lang.AsString());
        }

        /// <summary>
        /// Sets parameters used for scripts.
        /// </summary>
        public TermsFacet<T> Params(string paramsBody)
        {
            RegisterJsonPart("'params': {0}", paramsBody);
            return this;
        }


        protected override bool ForceJsonBuild()
        {
            return true;
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
                body = !body.IsNullOrEmpty() ? new[] {fields, body}.JoinWithComma() : fields;

            return "'terms': {{ {0} }}".AltQuoteF(body);
        }
        
    }
}