using System.Collections.Generic;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// The synonym token filter allows to easily handle synonyms during the analysis process.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/synonym-tokenfilter.html
    /// </summary>
    public class SynonymTokenFilter : NamedComponentBase<SynonymTokenFilter>
    {

        /// <summary>
        /// Sets the synonyms configuration in the specified format.
        /// </summary>
        public SynonymTokenFilter Synonyms(IEnumerable<string> synonyms)
        {
            string propertyJson = JsonHelper.BuildJsonStringsProperty("synonyms", synonyms);
            RegisterJsonPart(propertyJson);
            return this;
        }

        /// <summary>
        /// Sets the synonyms configuration in the specified format.
        /// </summary>
        public SynonymTokenFilter Synonyms(params string[] synonyms)
        {
            return Synonyms((IEnumerable<string>)synonyms);
        }

        /// <summary>
        /// Sets a path (either relative to config location, or absolute) to a synonyms file configuration.
        /// </summary>
        public SynonymTokenFilter SynonymsPath(string synonymsPath)
        {
            RegisterJsonPart("'synonyms_path': {0}", synonymsPath.Quotate());
            return this;
        }

        /// <summary>
        /// Sets the synonyms configuration format.
        /// Defaults to Solr.
        /// </summary>
        public SynonymTokenFilter Format(SynonymTokenFilterFormats format = SynonymTokenFilterFormats.Solr)
        {
            RegisterJsonPart("'format': {0}", format.AsString().Quotate());
            return this;
        }

        /// <summary>
        /// Sets flag indicating that tokens case should be ignored.
        /// Defaults to false.
        /// </summary>
        public SynonymTokenFilter IgnoreCase(bool ignoreCase = false)
        {
            RegisterJsonPart("'ignore_case': {0}", ignoreCase.AsString());
            return this;
        }

        /// <summary>
        /// Sets flag which enables synonyms further tokenization.
        /// Defaults to true.
        /// </summary>
        public SynonymTokenFilter Expand(bool expand = true)
        {
            RegisterJsonPart("'expand': {0}", expand.AsString());
            return this;
        }

        /// <summary>
        /// Sets the logical / registered name of the tokenizer to use for synonyms tokenization.
        /// Defaults to "whitespace".
        /// </summary>
        public SynonymTokenFilter Tokenizer(string tokenizer = "whitespace")
        {
            RegisterJsonPart("'tokenizer': {0}", tokenizer.Quotate());
            return this;
        }

        /// <summary>
        /// Sets the logical / registered name of the tokenizer to use for synonyms tokenization.
        /// Defaults to whitespace.
        /// </summary>
        public SynonymTokenFilter Tokenizer(DefaultTokenizers tokenizer = DefaultTokenizers.whitespace)
        {
            Tokenizer(tokenizer.AsString());
            return this;
        }


        protected override string GetComponentType()
        {
            return DefaultTokenFilters.synonym.AsString();
        }
    }
}