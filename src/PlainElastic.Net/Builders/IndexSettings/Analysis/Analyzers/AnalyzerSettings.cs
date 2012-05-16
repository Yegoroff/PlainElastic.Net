using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// Allows to configure standard/custom analyzers to be used in mapping API.
    /// </summary>
    public class AnalyzerSettings : SettingsBase<AnalyzerSettings>
    {

        #region Standard

        /// <summary>
        /// An analyzer of type standard that is built of using
        /// Standard Tokenizer, with Standard Token Filter, Lower Case Token Filter, and Stop Token Filter.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/standard-analyzer.html
        /// </summary>
        public AnalyzerSettings Standard(string name, Func<StandardAnalyzer, StandardAnalyzer> standard = null)
        {
            RegisterJsonPartExpression(standard.Bind(analyzer => analyzer.Name(name)));
            return this;
        }

        /// <summary>
        /// An analyzer of type standard that is built of using
        /// Standard Tokenizer, with Standard Token Filter, Lower Case Token Filter, and Stop Token Filter.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/standard-analyzer.html
        /// </summary>
        public AnalyzerSettings Standard(AnalyzersDefaultAliases name, Func<StandardAnalyzer, StandardAnalyzer> standard = null)
        {
            return Standard(name.AsString(), standard);
        }

        /// <summary>
        /// An analyzer of type standard that is built of using
        /// Standard Tokenizer, with Standard Token Filter, Lower Case Token Filter, and Stop Token Filter.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/standard-analyzer.html
        /// </summary>
        public AnalyzerSettings Standard(Func<StandardAnalyzer, StandardAnalyzer> standard)
        {
            return Standard(DefaultAnalyzers.standard.AsString(), standard);
        }

        #endregion


        #region Simple

        /// <summary>
        /// An analyzer of type simple that is built using a Lower Case Tokenizer.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/simple-analyzer.html
        /// </summary>
        public AnalyzerSettings Simple(string name, Func<SimpleAnalyzer, SimpleAnalyzer> simple = null)
        {
            RegisterJsonPartExpression(simple.Bind(analyzer => analyzer.Name(name)));
            return this;
        }

        /// <summary>
        /// An analyzer of type simple that is built using a Lower Case Tokenizer.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/simple-analyzer.html
        /// </summary>
        public AnalyzerSettings Simple(AnalyzersDefaultAliases name, Func<SimpleAnalyzer, SimpleAnalyzer> simple = null)
        {
            return Simple(name.AsString(), simple);
        }

        /// <summary>
        /// An analyzer of type simple that is built using a Lower Case Tokenizer.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/simple-analyzer.html
        /// </summary>
        public AnalyzerSettings Simple(Func<SimpleAnalyzer, SimpleAnalyzer> simple)
        {
            return Simple(DefaultAnalyzers.simple.AsString(), simple);
        }

        #endregion


        #region Whitespace

        /// <summary>
        /// An analyzer of type whitespace that is built using a Whitespace Tokenizer.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/whitespace-analyzer.html
        /// </summary>
        public AnalyzerSettings Whitespace(string name, Func<WhitespaceAnalyzer, WhitespaceAnalyzer> whitespace = null)
        {
            RegisterJsonPartExpression(whitespace.Bind(analyzer => analyzer.Name(name)));
            return this;
        }

        /// <summary>
        /// An analyzer of type whitespace that is built using a Whitespace Tokenizer.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/whitespace-analyzer.html
        /// </summary>
        public AnalyzerSettings Whitespace(AnalyzersDefaultAliases name, Func<WhitespaceAnalyzer, WhitespaceAnalyzer> whitespace = null)
        {
            return Whitespace(name.AsString(), whitespace);
        }

        /// <summary>
        /// An analyzer of type whitespace that is built using a Whitespace Tokenizer.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/whitespace-analyzer.html
        /// </summary>
        public AnalyzerSettings Whitespace(Func<WhitespaceAnalyzer, WhitespaceAnalyzer> whitespace)
        {
            return Whitespace(DefaultAnalyzers.whitespace.AsString(), whitespace);
        }

        #endregion


        #region Stop

        /// <summary>
        /// An analyzer of type stop that is built using a Lower Case Tokenizer, with Stop Token Filter.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/stop-analyzer.html
        /// </summary>
        public AnalyzerSettings Stop(string name, Func<StopAnalyzer, StopAnalyzer> stop = null)
        {
            RegisterJsonPartExpression(stop.Bind(analyzer => analyzer.Name(name)));
            return this;
        }

        /// <summary>
        /// An analyzer of type stop that is built using a Lower Case Tokenizer, with Stop Token Filter.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/stop-analyzer.html
        /// </summary>
        public AnalyzerSettings Stop(AnalyzersDefaultAliases name, Func<StopAnalyzer, StopAnalyzer> stop = null)
        {
            return Stop(name.AsString(), stop);
        }

        /// <summary>
        /// An analyzer of type stop that is built using a Lower Case Tokenizer, with Stop Token Filter.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/stop-analyzer.html
        /// </summary>
        public AnalyzerSettings Stop(Func<StopAnalyzer, StopAnalyzer> stop)
        {
            return Stop(DefaultAnalyzers.stop.AsString(), stop);
        }

        #endregion


        #region Keyword

        /// <summary>
        /// An analyzer of type keyword that “tokenizes” an entire stream as a single token.
        /// This is useful for data like zip codes, ids and so on.
        /// Note, when using mapping definitions, it make more sense to simply mark the field as not_analyzed.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/keyword-analyzer.html
        /// </summary>
        public AnalyzerSettings Keyword(string name, Func<KeywordAnalyzer, KeywordAnalyzer> keyword = null)
        {
            RegisterJsonPartExpression(keyword.Bind(analyzer => analyzer.Name(name)));
            return this;
        }

        /// <summary>
        /// An analyzer of type keyword that “tokenizes” an entire stream as a single token.
        /// This is useful for data like zip codes, ids and so on.
        /// Note, when using mapping definitions, it make more sense to simply mark the field as not_analyzed.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/keyword-analyzer.html
        /// </summary>
        public AnalyzerSettings Keyword(AnalyzersDefaultAliases name, Func<KeywordAnalyzer, KeywordAnalyzer> keyword = null)
        {
            return Keyword(name.AsString(), keyword);
        }

        /// <summary>
        /// An analyzer of type keyword that “tokenizes” an entire stream as a single token.
        /// This is useful for data like zip codes, ids and so on.
        /// Note, when using mapping definitions, it make more sense to simply mark the field as not_analyzed.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/keyword-analyzer.html
        /// </summary>
        public AnalyzerSettings Keyword(Func<KeywordAnalyzer, KeywordAnalyzer> keyword)
        {
            return Keyword(DefaultAnalyzers.keyword.AsString(), keyword);
        }

        #endregion


        #region Pattern

        /// <summary>
        /// An analyzer of type pattern that can flexibly separate text into terms via a regular expression.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/pattern-analyzer.html
        /// </summary>
        public AnalyzerSettings Pattern(string name, Func<PatternAnalyzer, PatternAnalyzer> pattern = null)
        {
            RegisterJsonPartExpression(pattern.Bind(analyzer => analyzer.Name(name)));
            return this;
        }

        /// <summary>
        /// An analyzer of type pattern that can flexibly separate text into terms via a regular expression.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/pattern-analyzer.html
        /// </summary>
        public AnalyzerSettings Pattern(AnalyzersDefaultAliases name, Func<PatternAnalyzer, PatternAnalyzer> pattern = null)
        {
            return Pattern(name.AsString(), pattern);
        }

        /// <summary>
        /// An analyzer of type pattern that can flexibly separate text into terms via a regular expression.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/pattern-analyzer.html
        /// </summary>
        public AnalyzerSettings Pattern(Func<PatternAnalyzer, PatternAnalyzer> pattern)
        {
            return Pattern(DefaultAnalyzers.pattern.AsString(), pattern);
        }

        #endregion


        #region Language

        /// <summary>
        /// A set of analyzers aimed at analyzing specific language text.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/lang-analyzer.html
        /// </summary>
        public AnalyzerSettings Language(string name, Func<LanguageAnalyzer, LanguageAnalyzer> language)
        {
            RegisterJsonPartExpression(language.Bind(analyzer => analyzer.Name(name)));
            return this;
        }

        /// <summary>
        /// A set of analyzers aimed at analyzing specific language text.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/lang-analyzer.html
        /// </summary>
        public AnalyzerSettings Language(AnalyzersDefaultAliases name, Func<LanguageAnalyzer, LanguageAnalyzer> language)
        {
            return Language(name.AsString(), language);
        }

        /// <summary>
        /// A set of analyzers aimed at analyzing specific language text.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/lang-analyzer.html
        /// </summary>
        public AnalyzerSettings Language(Func<LanguageAnalyzer, LanguageAnalyzer> language)
        {

            RegisterJsonPartExpression(language);
            return this;
        }

        #endregion


        #region Snowball

        /// <summary>
        /// An analyzer of type snowball that uses the standard tokenizer, with standard filter, lowercase filter, stop filter, and snowball filter.
        /// The Snowball Analyzer is a stemming analyzer from Lucene that is originally based on the snowball project from snowball.tartarus.org.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/snowball-analyzer.html
        /// </summary>
        public AnalyzerSettings Snowball(string name, Func<SnowballAnalyzer, SnowballAnalyzer> snowball = null)
        {
            RegisterJsonPartExpression(snowball.Bind(analyzer => analyzer.Name(name)));
            return this;
        }

        /// <summary>
        /// An analyzer of type snowball that uses the standard tokenizer, with standard filter, lowercase filter, stop filter, and snowball filter.
        /// The Snowball Analyzer is a stemming analyzer from Lucene that is originally based on the snowball project from snowball.tartarus.org.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/snowball-analyzer.html
        /// </summary>
        public AnalyzerSettings Snowball(AnalyzersDefaultAliases name, Func<SnowballAnalyzer, SnowballAnalyzer> snowball = null)
        {
            return Snowball(name.AsString(), snowball);
        }

        /// <summary>
        /// An analyzer of type snowball that uses the standard tokenizer, with standard filter, lowercase filter, stop filter, and snowball filter.
        /// The Snowball Analyzer is a stemming analyzer from Lucene that is originally based on the snowball project from snowball.tartarus.org.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/snowball-analyzer.html
        /// </summary>
        public AnalyzerSettings Snowball(Func<SnowballAnalyzer, SnowballAnalyzer> snowball)
        {
            return Snowball(DefaultAnalyzers.snowball.AsString(), snowball);
        }

        #endregion


        #region Custom

        /// <summary>
        /// An analyzer of type custom that allows to combine a Tokenizer with zero or more Token Filters, and zero or more Char Filters.
        /// The custom analyzer accepts a logical/registered name of the tokenizer to use, and a list of logical/registered names of token filters.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/custom-analyzer.html
        /// </summary>
        public AnalyzerSettings Custom(string name, Func<CustomAnalyzer, CustomAnalyzer> custom)
        {
            RegisterJsonPartExpression(custom.Bind(analyzer => analyzer.Name(name)));
            return this;
        }

        /// <summary>
        /// An analyzer of type custom that allows to combine a Tokenizer with zero or more Token Filters, and zero or more Char Filters.
        /// The custom analyzer accepts a logical/registered name of the tokenizer to use, and a list of logical/registered names of token filters.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/custom-analyzer.html
        /// </summary>
        public AnalyzerSettings Custom(AnalyzersDefaultAliases name, Func<CustomAnalyzer, CustomAnalyzer> custom)
        {
            return Custom(name.AsString(), custom);
        }

        #endregion


        protected override string ApplyJsonTemplate(string body)
        {
            return "'analyzer': {{ {0} }}".AltQuoteF(body);
        }
    }
}