using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Mappings
{
    /// <summary>
    /// Represents text fields mapping.
    /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
    /// </summary>
    public class StringMap<T> : PropertyBase<T, StringMap<T>>
    {
   
        public StringMap<T> TermVector(TermVector termVector)
        {
            RegisterCustomJsonMap("'term_vector': {0}", termVector.AsString().Quotate());
            return this;
        }


        /// <summary>
        /// Defines if norms should be omitted or not. 
        /// </summary>
        public StringMap<T> OmitNorms(bool omitNorms = false)
        {
            RegisterCustomJsonMap("'omit_norms': {0}", omitNorms.AsString());
            return this;
        }

        /// <summary>
        /// Defines if term freq and positions should be omitted.
        /// </summary>
        public StringMap<T> OmitTermFreqAndPositions(bool omitTermFreqAndPositions = false)
        {
            RegisterCustomJsonMap("'omit_term_freq_and_positions': {0}", omitTermFreqAndPositions.AsString());
            return this;
        }
        
        /// <summary>
        /// The analyzer used to analyze the text contents when analyzed during indexing and when searching using a query string. Defaults to the globally configured analyzer.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public StringMap<T> Analyzer(string analyzer)
        {
            RegisterCustomJsonMap("'analyzer': {0}", analyzer.Quotate());
            return this;
        }

        /// <summary>
        /// The analyzer used to analyze the text contents when analyzed during indexing and when searching using a query string. Defaults to the globally configured analyzer.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public StringMap<T> Analyzer(DefaultAnalyzers analyzer)
        {
            return Analyzer(analyzer.AsString());
        }        

        /// <summary>
        /// The analyzer used to analyze the text contents when analyzed during indexing.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/ 
        /// </summary>       
        public StringMap<T> IndexAnalyzer(string analyzer)
        {
            RegisterCustomJsonMap("'index_analyzer': {0}", analyzer.Quotate());
            return this;
        }

        /// <summary>
        /// The analyzer used to analyze the text contents when analyzed during indexing.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/ 
        /// </summary>       
        public StringMap<T> IndexAnalyzer(DefaultAnalyzers analyzer)
        {
            return IndexAnalyzer(analyzer.AsString());
        }

        /// <summary>
        /// The analyzer used to analyze the field when part of a query string.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public StringMap<T> SearchAnalyzer(string analyzer)
        {
            RegisterCustomJsonMap("'search_analyzer': {0}", analyzer.Quotate());
            return this;
        }

        /// <summary>
        /// The analyzer used to analyze the field when part of a query string.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public StringMap<T> SearchAnalyzer(DefaultAnalyzers analyzer)
        {
            return SearchAnalyzer(analyzer.AsString());
        }
        
        protected override string GetElasticFieldType(Type fieldType)
        {
            return "string";
        }

        /// <summary>
        /// The fields options allows to map several core types fields into a single json source field
        /// </summary>
        public virtual StringMap<T> Fields(Func<CoreFields<StringMap<T>>, CoreFields<StringMap<T>>> fields)
        {
            RegisterMapAsJson(fields);
            return this;
        }
    }
}