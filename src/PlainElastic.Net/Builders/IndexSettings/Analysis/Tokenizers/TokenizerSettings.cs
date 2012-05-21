using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// Allows to configure tokenizers to be used in custom analyzers.
    /// </summary>
    public class TokenizerSettings : SettingsBase<TokenizerSettings>
    {

        #region EdgeNGram

        /// <summary>
        /// A tokenizer of type edgeNGram.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/edgengram-tokenizer.html
        /// </summary>
        public TokenizerSettings EdgeNGram(string name, Func<EdgeNGramTokenizer, EdgeNGramTokenizer> edgeNGram = null)
        {
            RegisterJsonPartExpression(edgeNGram.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A tokenizer of type edgeNGram.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/edgengram-tokenizer.html
        /// </summary>
        public TokenizerSettings EdgeNGram(Func<EdgeNGramTokenizer, EdgeNGramTokenizer> edgeNGram)
        {
            return EdgeNGram(DefaultTokenizers.edgeNGram.AsString(), edgeNGram);
        }

        #endregion


        #region Keyword

        /// <summary>
        /// A tokenizer of type keyword that emits the entire input as a single input.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/keyword-tokenizer.html
        /// </summary>
        public TokenizerSettings Keyword(string name, Func<KeywordTokenizer, KeywordTokenizer> keyword = null)
        {
            RegisterJsonPartExpression(keyword.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A tokenizer of type keyword that emits the entire input as a single input.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/keyword-tokenizer.html
        /// </summary>
        public TokenizerSettings Keyword(Func<KeywordTokenizer, KeywordTokenizer> keyword)
        {
            return Keyword(DefaultTokenizers.keyword.AsString(), keyword);
        }

        #endregion


        #region Letter

        /// <summary>
        /// A tokenizer of type letter that divides text at non-letters. That's to say, it defines tokens as maximal strings of adjacent letters.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/letter-tokenizer.html
        /// </summary>
        public TokenizerSettings Letter(string name, Func<LetterTokenizer, LetterTokenizer> letter = null)
        {
            RegisterJsonPartExpression(letter.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A tokenizer of type letter that divides text at non-letters. That's to say, it defines tokens as maximal strings of adjacent letters.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/letter-tokenizer.html
        /// </summary>
        public TokenizerSettings Letter(Func<LetterTokenizer, LetterTokenizer> letter)
        {
            return Letter(DefaultTokenizers.letter.AsString(), letter);
        }

        #endregion


        #region Lowercase

        /// <summary>
        /// A tokenizer of type lowercase that performs the function of Letter Tokenizer and Lower Case Token Filter together.
        /// It divides text at non-letters and converts them to lower case.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/lowercase-tokenizer.html
        /// </summary>
        public TokenizerSettings Lowercase(string name, Func<LowercaseTokenizer, LowercaseTokenizer> lowercase = null)
        {
            RegisterJsonPartExpression(lowercase.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A tokenizer of type lowercase that performs the function of Letter Tokenizer and Lower Case Token Filter together.
        /// It divides text at non-letters and converts them to lower case.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/lowercase-tokenizer.html
        /// </summary>
        public TokenizerSettings Lowercase(Func<LowercaseTokenizer, LowercaseTokenizer> lowercase)
        {
            return Lowercase(DefaultTokenizers.lowercase.AsString(), lowercase);
        }

        #endregion


        #region NGram

        /// <summary>
        /// A tokenizer of type nGram that builds N-characters substrings from text.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/ngram-tokenizer.html
        /// </summary>
        public TokenizerSettings NGram(string name, Func<NGramTokenizer, NGramTokenizer> nGram = null)
        {
            RegisterJsonPartExpression(nGram.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A tokenizer of type nGram that builds N-characters substrings from text.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/ngram-tokenizer.html
        /// </summary>
        public TokenizerSettings NGram(Func<NGramTokenizer, NGramTokenizer> nGram)
        {
            return NGram(DefaultTokenizers.nGram.AsString(), nGram);
        }

        #endregion


        #region Standard

        /// <summary>
        /// A tokenizer of type standard providing grammar based tokenizer that is a good tokenizer for most European language documents.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/standard-tokenizer.html
        /// </summary>
        public TokenizerSettings Standard(string name, Func<StandardTokenizer, StandardTokenizer> standard = null)
        {
            RegisterJsonPartExpression(standard.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A tokenizer of type standard providing grammar based tokenizer that is a good tokenizer for most European language documents.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/standard-tokenizer.html
        /// </summary>
        public TokenizerSettings Standard(Func<StandardTokenizer, StandardTokenizer> standard)
        {
            return Standard(DefaultTokenizers.standard.AsString(), standard);
        }

        #endregion


        #region Whitespace

        /// <summary>
        /// A tokenizer of type whitespace that divides text at whitespace.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/whitespace-tokenizer.html
        /// </summary>
        public TokenizerSettings Whitespace(string name, Func<WhitespaceTokenizer, WhitespaceTokenizer> whitespace = null)
        {
            RegisterJsonPartExpression(whitespace.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A tokenizer of type whitespace that divides text at whitespace.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/whitespace-tokenizer.html
        /// </summary>
        public TokenizerSettings Whitespace(Func<WhitespaceTokenizer, WhitespaceTokenizer> whitespace)
        {
            return Whitespace(DefaultTokenizers.whitespace.AsString(), whitespace);
        }

        #endregion


        #region Pattern

        /// <summary>
        /// A tokenizer of type pattern that can flexibly separate text into terms via a regular expression. 
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/pattern-tokenizer.html
        /// </summary>
        public TokenizerSettings Pattern(string name, Func<PatternTokenizer, PatternTokenizer> pattern = null)
        {
            RegisterJsonPartExpression(pattern.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A tokenizer of type pattern that can flexibly separate text into terms via a regular expression. 
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/pattern-tokenizer.html
        /// </summary>
        public TokenizerSettings Pattern(Func<PatternTokenizer, PatternTokenizer> pattern)
        {
            return Pattern(DefaultTokenizers.pattern.AsString(), pattern);
        }

        #endregion


        #region UaxUrlEmail

        /// <summary>
        /// A tokenizer of type uax_url_email which works exactly like the standard tokenizer, but tokenizes emails and urls as single tokens.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/uaxurlemail-tokenizer.html
        /// </summary>
        public TokenizerSettings UaxUrlEmail(string name, Func<UaxUrlEmailTokenizer, StandardTokenizer> uaxUrlEmail = null)
        {
            RegisterJsonPartExpression(uaxUrlEmail.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A tokenizer of type uax_url_email which works exactly like the standard tokenizer, but tokenizes emails and urls as single tokens.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/uaxurlemail-tokenizer.html
        /// </summary>
        public TokenizerSettings UaxUrlEmail(Func<UaxUrlEmailTokenizer, StandardTokenizer> uaxUrlEmail)
        {
            return UaxUrlEmail(DefaultTokenizers.uax_url_email.AsString(), uaxUrlEmail);
        }

        #endregion


        #region PathHierarchy

        /// <summary>
        /// The path_hierarchy tokenizer takes something like "/something/something/else"
        /// and produces tokens "/something", "/something/something", "/something/something/else".
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/pathhierarchy-tokenizer.html
        /// </summary>
        public TokenizerSettings PathHierarchy(string name, Func<PathHierarchyTokenizer, PathHierarchyTokenizer> pathHierarchy = null)
        {
            RegisterJsonPartExpression(pathHierarchy.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// The path_hierarchy tokenizer takes something like "/something/something/else"
        /// and produces tokens "/something", "/something/something", "/something/something/else".
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/pathhierarchy-tokenizer.html
        /// </summary>
        public TokenizerSettings PathHierarchy(Func<PathHierarchyTokenizer, PathHierarchyTokenizer> pathHierarchy)
        {
            return PathHierarchy(DefaultTokenizers.path_hierarchy.AsString(), pathHierarchy);
        }

        #endregion


        protected override string ApplyJsonTemplate(string body)
        {
            return "'tokenizer': {{ {0} }}".AltQuoteF(body);
        }
    }
}