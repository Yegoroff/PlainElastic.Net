using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Combines both the terms and statistical allowing to compute stats computed on a field, per term value driven by another field.
    /// see http://www.elasticsearch.org/guide/reference/api/search/facets/terms-stats-facet/
    /// </summary>
    public class TermsStatsFacet<T> : FacetBase<TermsStatsFacet<T>, T>
    {
        /// <summary>
        /// The field to group statistics against.
        /// </summary>
        public TermsStatsFacet<T> KeyField(string keyFieldName)
        {
            RegisterJsonPart("'key_field': {0}", keyFieldName.Quotate());            
            return this;
        }

        /// <summary>
        /// The field to group statistics against.
        /// </summary>
        public TermsStatsFacet<T> KeyField(Expression<Func<T, object>> keyField)
        {
            return KeyField(keyField.GetPropertyPath());
        }

        /// <summary>
        /// The field to group statistics against.
        /// </summary>
        public TermsStatsFacet<T> KeyFieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> keyField)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fieldName = collectionProperty + "." + keyField.GetPropertyPath();

            return KeyField(fieldName);
        }


        /// <summary>
        /// The field to compute statistics.
        /// </summary>
        public TermsStatsFacet<T> ValueField(string valueFieldName)
        {
            RegisterJsonPart("'value_field': {0}", valueFieldName.Quotate());
            return this;
        }

        /// <summary>
        /// The field to compute statistics.
        /// </summary>
        public TermsStatsFacet<T> ValueField(Expression<Func<T, object>> valueField)
        {
            return ValueField(valueField.GetPropertyPath());
        }

        /// <summary>
        /// The field to compute statistics.
        /// </summary>
        public TermsStatsFacet<T> ValueFieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> valueField)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fieldName = collectionProperty + "." + valueField.GetPropertyPath();

            return ValueField(fieldName);
        }




        /// <summary>
        /// Allows to control the ordering of the terms_stats facets. The default is count.
        /// </summary>
        public TermsStatsFacet<T> Order(TermsStatsFacetOrder order = TermsStatsFacetOrder.count)
        {
            RegisterJsonPart("'order': {0}", order.AsString().Quotate());
            return this;
        }

        /// <summary>
        /// The number of facet entries to return.
        /// Default is 10.
        /// Setting it to 0 will return all terms matching the hits (be careful not to return too many results).
        /// </summary>
        public TermsStatsFacet<T> Size(int size)
        {
            RegisterJsonPart("'size': {0}", size.AsString());

            return this;
        }

        /// <summary>
        /// Allow to get all the terms in facet. 
        /// Equals to size = 0.
        /// </summary>
        public TermsStatsFacet<T> AllTerms(bool allTerms = true)
        {
            RegisterJsonPart("'all_terms': {0}", allTerms.AsString());

            return this;
        }

     

        /// <summary>
        /// Allow to define a script for terms_stats facet to compute value.
        /// </summary>
        public TermsStatsFacet<T> Script(string script)
        {
            RegisterJsonPart("'script': {0}", script.Quotate());
            return this;
        }

        /// <summary>
        /// Allow to define a script for terms_stats facet to compute value.
        /// </summary>
        public TermsStatsFacet<T> ValueScript(string script)
        {
            RegisterJsonPart("'value_script': {0}", script.Quotate());
            return this;
        }


        /// <summary>
        /// Allow to define a script for terms_stats facet to compute value.
        /// </summary>
        public TermsStatsFacet<T> ScriptField(string scriptField)
        {
            RegisterJsonPart("'script_field': {0}", scriptField.Quotate());
            return this;
        }


        /// <summary>
        /// Sets a scripting language used for scripts.
        /// By default used mvel language.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
        public TermsStatsFacet<T> Lang(string lang)
        {
            RegisterJsonPart("'lang': {0}", lang.Quotate());
            return this;
        }

        /// <summary>
        /// Sets a scripting language used for scripts.
        /// By default used mvel language.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
        public TermsStatsFacet<T> Lang(ScriptLangs lang)
        {
            return Lang(lang.AsString());
        }

        /// <summary>
        /// Sets parameters used for scripts.
        /// </summary>
        public TermsStatsFacet<T> Params(string paramsBody)
        {
            RegisterJsonPart("'params': {0}", paramsBody);
            return this;
        }


        protected override string ApplyFacetBodyJsonTemplate(string body)
        {
            return "'terms_stats': {{ {0} }}".AltQuoteF(body);
        }

    }
}