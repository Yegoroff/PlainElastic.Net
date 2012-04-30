using System;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    public class IndexSettingsBuilder
    {
        private string analysisJson;


        /// <summary>
        /// The index analysis module acts as a configurable registry of Analyzers
        /// that can be used in order to both break indexed (analyzed) fields when a document is indexed and process query strings.
        /// It maps to the Lucene Analyzer.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public IndexSettingsBuilder Analysis(Func<Analysis, Analysis> analysis)
        {
            var analysisPart = analysis(new Analysis());

            analysisJson = ((IJsonConvertible)analysisPart).ToJson();

            return this;
        }


        public string Build()
        {
            if (analysisJson.IsNullOrEmpty())
                return "";

            return "{{ 'index': {{ {0} }} }}".AltQuoteF(analysisJson);
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