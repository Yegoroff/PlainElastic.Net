using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// Allows to configure standard/custom analyzers to be used in mapping API.
    /// </summary>
    public class Analyzer : AnalysisBase<Analyzer>
    {
#region Standard

        /// <summary>
        /// An analyzer of type standard that is built of using
        /// Standard Tokenizer, with Standard Token Filter, Lower Case Token Filter, and Stop Token Filter.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/standard-analyzer.html
        /// </summary>
        public Analyzer Standard(string name, Func<StandardAnalyzer, StandardAnalyzer> standard = null)
        {
            RegisterJsonPartExpression(SpecifyComponentName(standard, name));
            return this;
        }

        /// <summary>
        /// An analyzer of type standard that is built of using
        /// Standard Tokenizer, with Standard Token Filter, Lower Case Token Filter, and Stop Token Filter.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/standard-analyzer.html
        /// </summary>
        public Analyzer Standard(AnalyzersDefaultAliases name, Func<StandardAnalyzer, StandardAnalyzer> standard = null)
        {
            return Standard(name.ToString(), standard);
        }

        /// <summary>
        /// An analyzer of type standard that is built of using
        /// Standard Tokenizer, with Standard Token Filter, Lower Case Token Filter, and Stop Token Filter.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/standard-analyzer.html
        /// </summary>
        public Analyzer Standard(Func<StandardAnalyzer, StandardAnalyzer> standard = null)
        {
            return Standard(DefaultAnalyzers.standard.ToString(), standard);
        }

#endregion


#region Simple

        /// <summary>
        /// An analyzer of type simple that is built using a Lower Case Tokenizer.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/simple-analyzer.html
        /// </summary>
        public Analyzer Simple(string name, Func<SimpleAnalyzer, SimpleAnalyzer> simple = null)
        {
            RegisterJsonPartExpression(SpecifyComponentName(simple, name));
            return this;
        }

        /// <summary>
        /// An analyzer of type simple that is built using a Lower Case Tokenizer.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/simple-analyzer.html
        /// </summary>
        public Analyzer Simple(AnalyzersDefaultAliases name, Func<SimpleAnalyzer, SimpleAnalyzer> simple = null)
        {
            return Simple(name.ToString(), simple);
        }

        /// <summary>
        /// An analyzer of type simple that is built using a Lower Case Tokenizer.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/simple-analyzer.html
        /// </summary>
        public Analyzer Simple(Func<SimpleAnalyzer, SimpleAnalyzer> simple = null)
        {
            return Simple(DefaultAnalyzers.simple.ToString(), simple);
        }

#endregion


#region Whitespace

        /// <summary>
        /// An analyzer of type whitespace that is built using a Whitespace Tokenizer.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/whitespace-analyzer.html
        /// </summary>
        public Analyzer Whitespace(string name, Func<WhitespaceAnalyzer, WhitespaceAnalyzer> whitespace = null)
        {
            RegisterJsonPartExpression(SpecifyComponentName(whitespace, name));
            return this;
        }

        /// <summary>
        /// An analyzer of type whitespace that is built using a Whitespace Tokenizer.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/whitespace-analyzer.html
        /// </summary>
        public Analyzer Whitespace(AnalyzersDefaultAliases name, Func<WhitespaceAnalyzer, WhitespaceAnalyzer> whitespace = null)
        {
            return Whitespace(name.ToString(), whitespace);
        }

        /// <summary>
        /// An analyzer of type whitespace that is built using a Whitespace Tokenizer.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/whitespace-analyzer.html
        /// </summary>
        public Analyzer Whitespace(Func<WhitespaceAnalyzer, WhitespaceAnalyzer> whitespace = null)
        {
            return Whitespace(DefaultAnalyzers.whitespace.ToString(), whitespace);
        }

#endregion


#region Stop

        /// <summary>
        /// An analyzer of type stop that is built using a Lower Case Tokenizer, with Stop Token Filter.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/stop-analyzer.html
        /// </summary>
        public Analyzer Stop(string name, Func<StopAnalyzer, StopAnalyzer> stop = null)
        {
            RegisterJsonPartExpression(SpecifyComponentName(stop, name));
            return this;
        }

        /// <summary>
        /// An analyzer of type stop that is built using a Lower Case Tokenizer, with Stop Token Filter.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/stop-analyzer.html
        /// </summary>
        public Analyzer Stop(AnalyzersDefaultAliases name, Func<StopAnalyzer, StopAnalyzer> stop = null)
        {
            return Stop(name.ToString(), stop);
        }

        /// <summary>
        /// An analyzer of type stop that is built using a Lower Case Tokenizer, with Stop Token Filter.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/stop-analyzer.html
        /// </summary>
        public Analyzer Stop(Func<StopAnalyzer, StopAnalyzer> stop = null)
        {
            return Stop(DefaultAnalyzers.stop.ToString(), stop);
        }

#endregion


        protected override string ApplyJsonTemplate(string body)
        {
            return "'analyzer': {{ {0} }}".AltQuoteF(body);
        }
    }
}