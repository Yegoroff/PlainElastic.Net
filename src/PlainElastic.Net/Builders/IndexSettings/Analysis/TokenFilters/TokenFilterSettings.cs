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


        #region EdgeNGram

        /// <summary>
        /// A token filter of type edgeNGram that builds N-characters substrings from text. Substrings are built from one side of a text.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/edgengram-tokenfilter.html
        /// </summary>
        public TokenFilterSettings EdgeNGram(string name, Func<EdgeNGramTokenFilter, EdgeNGramTokenFilter> edgeNGram = null)
        {
            RegisterJsonPartExpression(edgeNGram.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A token filter of type edgeNGram that builds N-characters substrings from text. Substrings are built from one side of a text.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/edgengram-tokenfilter.html
        /// </summary>
        public TokenFilterSettings EdgeNGram(Func<EdgeNGramTokenFilter, EdgeNGramTokenFilter> edgeNGram)
        {
            return EdgeNGram(DefaultTokenFilters.edgeNGram.AsString(), edgeNGram);
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


        #region PorterStem

        /// <summary>
        /// A token filter of type porterStem that transforms the token stream as per the Porter stemming algorithm.
        /// Note, the input to the stemming filter must already be in lower case, so you will need to use Lower Case Token Filter
        /// or Lower Case Tokenizer farther down the Tokenizer chain in order for this to work properly!
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/porterstem-tokenfilter.html
        /// </summary>
        public TokenFilterSettings PorterStem(string name, Func<PorterStemTokenFilter, PorterStemTokenFilter> porterStem = null)
        {
            RegisterJsonPartExpression(porterStem.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A token filter of type porterStem that transforms the token stream as per the Porter stemming algorithm.
        /// Note, the input to the stemming filter must already be in lower case, so you will need to use Lower Case Token Filter
        /// or Lower Case Tokenizer farther down the Tokenizer chain in order for this to work properly!
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/porterstem-tokenfilter.html
        /// </summary>
        public TokenFilterSettings PorterStem(Func<PorterStemTokenFilter, PorterStemTokenFilter> porterStem)
        {
            return PorterStem(DefaultTokenFilters.porterStem.AsString(), porterStem);
        }

        #endregion


        #region Shingle

        /// <summary>
        /// A token filter of type shingle that constructs shingles (token n-grams) from a token stream.
        /// In other words, it creates combinations of tokens as a single token.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/shingle-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Shingle(string name, Func<ShingleTokenFilter, ShingleTokenFilter> shingle = null)
        {
            RegisterJsonPartExpression(shingle.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A token filter of type shingle that constructs shingles (token n-grams) from a token stream.
        /// In other words, it creates combinations of tokens as a single token.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/shingle-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Shingle(Func<ShingleTokenFilter, ShingleTokenFilter> shingle)
        {
            return Shingle(DefaultTokenFilters.shingle.AsString(), shingle);
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


        #region Stop

        /// <summary>
        /// A token filter of type stop that removes stop words from token streams.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/stop-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Stop(string name, Func<StopTokenFilter, StopTokenFilter> stop = null)
        {
            RegisterJsonPartExpression(stop.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A token filter of type stop that removes stop words from token streams.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/stop-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Stop(Func<StopTokenFilter, StopTokenFilter> stop)
        {
            return Stop(DefaultTokenFilters.stop.AsString(), stop);
        }

        #endregion


        #region WordDelimiter

        /// <summary>
        /// Named word_delimiter, it splits words into subwords and performs optional transformations on subword groups.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/word-delimiter-tokenfilter.html
        /// </summary>
        public TokenFilterSettings WordDelimiter(string name, Func<WordDelimiterTokenFilter, WordDelimiterTokenFilter> wordDelimiter = null)
        {
            RegisterJsonPartExpression(wordDelimiter.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// Named word_delimiter, it splits words into subwords and performs optional transformations on subword groups.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/word-delimiter-tokenfilter.html
        /// </summary>
        public TokenFilterSettings WordDelimiter(Func<WordDelimiterTokenFilter, WordDelimiterTokenFilter> wordDelimiter)
        {
            return WordDelimiter(DefaultTokenFilters.word_delimiter.AsString(), wordDelimiter);
        }

        #endregion


        protected override string ApplyJsonTemplate(string body)
        {
            return "'token_filter': {{ {0} }}".AltQuoteF(body);
        }
    }
}