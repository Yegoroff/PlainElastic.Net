using System;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{

    /// <summary>
    /// Allows to build index level settings.
    /// see: http://www.elasticsearch.org/guide/reference/api/admin-indices-update-settings.html
    /// </summary>
    public class IndexSettingsBuilder : SettingsBase<IndexSettingsBuilder>
    {

        /// <summary>
        /// The index analysis module acts as a configurable registry of Analyzers
        /// that can be used in order to both break indexed (analyzed) fields when a document is indexed and process query strings.
        /// It maps to the Lucene Analyzer.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public IndexSettingsBuilder Analysis(Func<Analysis, Analysis> analysis)
        {
            RegisterJsonPartExpression(analysis);
            return this;
        }


        protected override string ApplyJsonTemplate(string body)
        {
            if (body.IsNullOrEmpty())
                return "";

            return "{{ 'index': {{ {0} }} }}".AltQuoteF(body);
        }



        public string Build()
        {
            return ((IJsonConvertible) this).ToJson();
        }

        public string BuildBeautified()
        {
            return Build().BeautifyJson();
        }


        public override string ToString()
        {
            return BuildBeautified();
        }
    }
}