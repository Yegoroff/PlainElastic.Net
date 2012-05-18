using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// Allows to configure token filters to be used in custom analyzers.
    /// </summary>
    public class TokenFilterSettings : SettingsBase<TokenFilterSettings>
    {

        #region Asciifolding

        /// <summary>
        /// A token filter of type asciifolding that converts alphabetic, numeric, and symbolic Unicode characters
        /// which are not in the first 127 ASCII characters (the "Basic Latin" Unicode block) into their ASCII equivalents, if one exists.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/asciifolding-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Asciifolding(string name, Func<AsciifoldingTokenFilter, AsciifoldingTokenFilter> asciifolding = null)
        {
            RegisterJsonPartExpression(asciifolding.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A token filter of type asciifolding that converts alphabetic, numeric, and symbolic Unicode characters
        /// which are not in the first 127 ASCII characters (the "Basic Latin" Unicode block) into their ASCII equivalents, if one exists.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/asciifolding-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Asciifolding(Func<AsciifoldingTokenFilter, AsciifoldingTokenFilter> asciifolding)
        {
            return Asciifolding(DefaultTokenFilters.asciifolding.AsString(), asciifolding);
        }

        #endregion


        #region Length

        /// <summary>
        /// A token filter of type length that removes words that are too long or too short for the stream.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/length-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Length(string name, Func<LengthTokenFilter, LengthTokenFilter> length = null)
        {
            RegisterJsonPartExpression(length.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A token filter of type length that removes words that are too long or too short for the stream.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/length-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Length(Func<LengthTokenFilter, LengthTokenFilter> length)
        {
            return Length(DefaultTokenFilters.length.AsString(), length);
        }

        #endregion


        #region Lowercase

        /// <summary>
        /// A token filter of type lowercase that normalizes token text to lower case.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/lowercase-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Lowercase(string name, Func<LowercaseTokenFilter, LowercaseTokenFilter> lowercase = null)
        {
            RegisterJsonPartExpression(lowercase.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A token filter of type lowercase that normalizes token text to lower case.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/lowercase-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Lowercase(Func<LowercaseTokenFilter, LowercaseTokenFilter> lowercase)
        {
            return Lowercase(DefaultTokenFilters.lowercase.AsString(), lowercase);
        }

        #endregion


        #region NGram

        /// <summary>
        /// A token filter of type nGram that builds N-characters substrings from text.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/ngram-tokenfilter.html
        /// </summary>
        public TokenFilterSettings NGram(string name, Func<NGramTokenFilter, NGramTokenFilter> nGram = null)
        {
            RegisterJsonPartExpression(nGram.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A token filter of type nGram that builds N-characters substrings from text.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/ngram-tokenfilter.html
        /// </summary>
        public TokenFilterSettings NGram(Func<NGramTokenFilter, NGramTokenFilter> nGram)
        {
            return NGram(DefaultTokenFilters.nGram.AsString(), nGram);
        }

        #endregion


        #region Standard

        /// <summary>
        /// A token filter of type standard that normalizes tokens extracted with the Standard Tokenizer.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/standard-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Standard(string name, Func<StandardTokenFilter, StandardTokenFilter> standard = null)
        {
            RegisterJsonPartExpression(standard.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A token filter of type standard that normalizes tokens extracted with the Standard Tokenizer.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/standard-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Standard(Func<StandardTokenFilter, StandardTokenFilter> standard)
        {
            return Standard(DefaultTokenFilters.standard.AsString(), standard);
        }

        #endregion


        protected override string ApplyJsonTemplate(string body)
        {
            return "'token_filter': {{ {0} }}".AltQuoteF(body);
        }
    }
}