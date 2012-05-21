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


        #region DictionaryDecompounder

        /// <summary>
        /// A token filter of type dictionary_decompounder that allows to decompose compound words.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/compound-word-tokenfilter.html
        /// </summary>
        public TokenFilterSettings DictionaryDecompounder(string name, Func<DictionaryDecompounderTokenFilter, DictionaryDecompounderTokenFilter> dictionaryDecompounder = null)
        {
            RegisterJsonPartExpression(dictionaryDecompounder.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A token filter of type dictionary_decompounder that allows to decompose compound words.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/compound-word-tokenfilter.html
        /// </summary>
        public TokenFilterSettings DictionaryDecompounder(Func<DictionaryDecompounderTokenFilter, DictionaryDecompounderTokenFilter> dictionaryDecompounder)
        {
            return DictionaryDecompounder(DefaultTokenFilters.dictionary_decompounder.AsString(), dictionaryDecompounder);
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


        #region Elision

        /// <summary>
        /// A token filter which removes elisions. For example, "l'avion" (the plane) will be tokenized as "avion" (plane).
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/elision-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Elision(string name, Func<ElisionTokenFilter, ElisionTokenFilter> elision = null)
        {
            RegisterJsonPartExpression(elision.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A token filter which removes elisions. For example, "l'avion" (the plane) will be tokenized as "avion" (plane).
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/elision-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Elision(Func<ElisionTokenFilter, ElisionTokenFilter> elision)
        {
            return Elision(DefaultTokenFilters.elision.AsString(), elision);
        }

        #endregion


        #region HyphenationDecompounder

        /// <summary>
        /// A token filter of type hyphenation_decompounder that allows to decompose compound words.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/compound-word-tokenfilter.html
        /// </summary>
        public TokenFilterSettings HyphenationDecompounder(string name, Func<HyphenationDecompounderTokenFilter, DictionaryDecompounderTokenFilter> hyphenationDecompounder = null)
        {
            RegisterJsonPartExpression(hyphenationDecompounder.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A token filter of type hyphenation_decompounder that allows to decompose compound words.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/compound-word-tokenfilter.html
        /// </summary>
        public TokenFilterSettings HyphenationDecompounder(Func<HyphenationDecompounderTokenFilter, DictionaryDecompounderTokenFilter> hyphenationDecompounder)
        {
            return HyphenationDecompounder(DefaultTokenFilters.hyphenation_decompounder.AsString(), hyphenationDecompounder);
        }

        #endregion


        #region Kstem

        /// <summary>
        /// The kstem token filter is a high performance filter for english.
        /// All terms must already be lowercased (use lowercase filter) for this filter to work correctly.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/kstem-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Kstem(string name, Func<KstemTokenFilter, KstemTokenFilter> kstem = null)
        {
            RegisterJsonPartExpression(kstem.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// The kstem token filter is a high performance filter for english.
        /// All terms must already be lowercased (use lowercase filter) for this filter to work correctly.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/kstem-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Kstem(Func<KstemTokenFilter, KstemTokenFilter> kstem)
        {
            return Kstem(DefaultTokenFilters.kstem.AsString(), kstem);
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


        #region PatternReplace

        /// <summary>
        /// The pattern_replace token filter allows to easily handle string replacements based on a regular expression.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/pattern_replace-tokenfilter.html
        /// </summary>
        public TokenFilterSettings PatternReplace(string name, Func<PatternReplaceTokenFilter, PatternReplaceTokenFilter> patternReplace = null)
        {
            RegisterJsonPartExpression(patternReplace.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// The pattern_replace token filter allows to easily handle string replacements based on a regular expression.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/pattern_replace-tokenfilter.html
        /// </summary>
        public TokenFilterSettings PatternReplace(Func<PatternReplaceTokenFilter, PatternReplaceTokenFilter> patternReplace)
        {
            return PatternReplace(DefaultTokenFilters.pattern_replace.AsString(), patternReplace);
        }

        #endregion


        #region Phonetic

        /// <summary>
        /// A phonetic analysis token filter plugin.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/phonetic-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Phonetic(string name, Func<PhoneticTokenFilter, PhoneticTokenFilter> phonetic = null)
        {
            RegisterJsonPartExpression(phonetic.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A phonetic analysis token filter plugin.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/phonetic-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Phonetic(Func<PhoneticTokenFilter, PhoneticTokenFilter> phonetic)
        {
            return Phonetic(DefaultTokenFilters.phonetic.AsString(), phonetic);
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


        #region Reverse

        /// <summary>
        /// A token filter of type reverse that simply reverses the tokens.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/reverse-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Reverse(string name, Func<ReverseTokenFilter, ReverseTokenFilter> reverse = null)
        {
            RegisterJsonPartExpression(reverse.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A token filter of type reverse that simply reverses the tokens.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/reverse-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Reverse(Func<ReverseTokenFilter, ReverseTokenFilter> reverse)
        {
            return Reverse(DefaultTokenFilters.reverse.AsString(), reverse);
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


        #region Snowball

        /// <summary>
        /// A token filter that stems words using a Snowball-generated stemmer.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/snowball-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Snowball(string name, Func<SnowballTokenFilter, SnowballTokenFilter> snowball = null)
        {
            RegisterJsonPartExpression(snowball.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A token filter that stems words using a Snowball-generated stemmer.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/snowball-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Snowball(Func<SnowballTokenFilter, SnowballTokenFilter> snowball)
        {
            return Snowball(DefaultTokenFilters.snowball.AsString(), snowball);
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


        #region Stemmer

        /// <summary>
        /// A token filter that stems words (similar to snowball, but with more options).
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/stemmer-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Stemmer(string name, Func<StemmerTokenFilter, StemmerTokenFilter> stemmer = null)
        {
            RegisterJsonPartExpression(stemmer.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A token filter that stems words (similar to snowball, but with more options).
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/stemmer-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Stemmer(Func<StemmerTokenFilter, StemmerTokenFilter> stemmer)
        {
            return Stemmer(DefaultTokenFilters.stemmer.AsString(), stemmer);
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


        #region Synonym

        /// <summary>
        /// The synonym token filter allows to easily handle synonyms during the analysis process.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/synonym-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Synonym(string name, Func<SynonymTokenFilter, SynonymTokenFilter> synonym = null)
        {
            RegisterJsonPartExpression(synonym.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// The synonym token filter allows to easily handle synonyms during the analysis process.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/synonym-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Synonym(Func<SynonymTokenFilter, SynonymTokenFilter> synonym)
        {
            return Synonym(DefaultTokenFilters.synonym.AsString(), synonym);
        }

        #endregion


        #region Trim

        /// <summary>
        /// The trim token filter trims surrounding whitespaces around a token.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/trim-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Trim(string name, Func<TrimTokenFilter, TrimTokenFilter> trim = null)
        {
            RegisterJsonPartExpression(trim.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// The trim token filter trims surrounding whitespaces around a token.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/trim-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Trim(Func<TrimTokenFilter, TrimTokenFilter> trim)
        {
            return Trim(DefaultTokenFilters.trim.AsString(), trim);
        }

        #endregion


        #region Truncate

        /// <summary>
        /// The truncate token filter can be used to truncate tokens into a specific length.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/truncate-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Truncate(string name, Func<TruncateTokenFilter, TruncateTokenFilter> truncate = null)
        {
            RegisterJsonPartExpression(truncate.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// The truncate token filter can be used to truncate tokens into a specific length.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/truncate-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Truncate(Func<TruncateTokenFilter, TruncateTokenFilter> truncate)
        {
            return Truncate(DefaultTokenFilters.truncate.AsString(), truncate);
        }

        #endregion


        #region Unique

        /// <summary>
        /// The unique token filter can be used to only index unique tokens during analysis.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/unique-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Unique(string name, Func<UniqueTokenFilter, UniqueTokenFilter> unique = null)
        {
            RegisterJsonPartExpression(unique.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// The unique token filter can be used to only index unique tokens during analysis.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/unique-tokenfilter.html
        /// </summary>
        public TokenFilterSettings Unique(Func<UniqueTokenFilter, UniqueTokenFilter> unique)
        {
            return Unique(DefaultTokenFilters.unique.AsString(), unique);
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
            return "'filter': {{ {0} }}".AltQuoteF(body);
        }
    }
}