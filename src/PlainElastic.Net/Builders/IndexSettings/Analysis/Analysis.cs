using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// The index analysis module acts as a configurable registry of Analyzers
    /// that can be used in order to both break indexed (analyzed) fields when a document is indexed and process query strings.
    /// It maps to the Lucene Analyzer.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/
    /// </summary>
    public class Analysis : SettingsBase<Analysis>
    {
        /// <summary>
        /// Allows to configure standard/custom analyzers to be used in mapping API.
        /// </summary>
        public Analysis Analyzer(Func<AnalyzerSettings, AnalyzerSettings> analyzer)
        {
            RegisterJsonPartExpression(analyzer);
            return this;
        }

        /// <summary>
        /// Allows to configure tokenizers to be used in custom analyzers.
        /// </summary>
        public Analysis Tokenizer(Func<TokenizerSettings, TokenizerSettings> tokenizer)
        {
            RegisterJsonPartExpression(tokenizer);
            return this;
        }

        /// <summary>
        /// Allows to configure token filters to be used in custom analyzers.
        /// </summary>
        public Analysis Filter(Func<TokenFilterSettings, TokenFilterSettings> filter)
        {
            RegisterJsonPartExpression(filter);
            return this;
        }

        /// <summary>
        /// Allows to configure char filters to be used in custom analyzers.
        /// </summary>
        public Analysis CharFilter(Func<CharFilterSettings, CharFilterSettings> charFilter)
        {
            RegisterJsonPartExpression(charFilter);
            return this;
        }


        protected override string ApplyJsonTemplate(string body)
        {
            return "'analysis': {{ {0} }}".AltQuoteF(body);
        }
    }
}