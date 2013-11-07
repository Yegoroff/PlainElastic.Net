using System;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Builders.IndexSettings.Settings;
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

        public IndexSettingsBuilder Settings(Func<Setting, Setting> settings)
        {
            RegisterJsonPartExpression(settings);
            return this;
        }

        /// <summary>
        /// Defines the number of shards 
        /// </summary>
        public IndexSettingsBuilder NumberOfShards(int number)
        {
            RegisterJsonPart("'number_of_shards': {0}", number.AsString());
            return this;
        }

        /// <summary>
        /// Defines the number of replicas each shard has
        /// </summary>
        public IndexSettingsBuilder NumberOfReplicas(int number)
        {
            RegisterJsonPart("'number_of_replicas': {0}", number.AsString());
            return this;
        }

        public string Build()
        {
            return ((IJsonConvertible)this).ToJson();
        }

        public string BuildBeautified()
        {
            return Build().BeautifyJson();
        }

        public override string ToString()
        {
            return BuildBeautified();
        }

        protected override string ApplyJsonTemplate(string body)
        {
            if (body.IsNullOrEmpty())
                return "";

            return "{{ 'index': {{ {0} }} }}".AltQuoteF(body);
        }
    }
}