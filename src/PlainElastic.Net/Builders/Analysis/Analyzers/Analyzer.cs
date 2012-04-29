using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// Allows to configure standard/custom analyzers to be used in mapping API.
    /// </summary>
    public class Analyzer : AnalysisBase<Analyzer>
    {
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


        protected override string ApplyJsonTemplate(string body)
        {
            return "'analyzer': {{ {0} }}".AltQuoteF(body);
        }
    }
}