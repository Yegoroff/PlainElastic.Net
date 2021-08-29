using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Mappings
{
    /// <summary>
    /// Represents custom field mapping.
    /// This type of mapping useful when you need to provide runtime property mapping.
    /// </summary>
    public class CustomPropertyMap<T> : PropertyBase<T, CustomPropertyMap<T>>
    {
        private string mappingType;


        public CustomPropertyMap() {}

        public CustomPropertyMap(string name, Type fieldType)
        {
            Field(name, fieldType);

        }

        public CustomPropertyMap(string name, string mappingType)
        {
            this.mappingType = mappingType;

            Field(name);
        }

        /// <summary>
        /// Allows explicitly specify ES type of the mapping.
        /// </summary>
        public CustomPropertyMap<T> Type(string mappingType)
        {
            this.mappingType = mappingType;
            FieldType = mappingType;

            return this;
        }


        /// <summary>
        /// Allows to build a condition dependent mapping. 
        /// Mapping will be applied only when condition true.
        /// </summary>
        public CustomPropertyMap<T> When(bool condition, Func<CustomPropertyMap<T>, CustomPropertyMap<T>> mapping)
        {
            if (condition)
                mapping(this);

            return this;
        }


        /// <summary>
        /// Allows to specify the date format.
        /// All dates are UTC.
        /// see  http://www.elasticsearch.org/guide/reference/mapping/date-format.html
        /// </summary>
        public CustomPropertyMap<T> Format(string dateFormat)
        {
            RegisterCustomJsonMap("'format': {0}", dateFormat.Quotate());
            return this;
        }

        /// <summary>
        ///  The precision step (number of terms generated for each number value). Defaults to 4.       
        /// </summary>
        public CustomPropertyMap<T> PrecisionStep(int precisionStep = 4)
        {
            RegisterCustomJsonMap("'precision_step': {0}", precisionStep.AsString());
            return this;
        }

        public CustomPropertyMap<T> TermVector(TermVector termVector)
        {
            RegisterCustomJsonMap("'term_vector': {0}", termVector.AsString().Quotate());
            return this;
        }

        /// <summary>
        /// Defines if norms should be omitted or not. 
        /// </summary>
        public CustomPropertyMap<T> OmitNorms(bool omitNorms = false)
        {
            RegisterCustomJsonMap("'omit_norms': {0}", omitNorms.AsString());
            return this;
        }

        /// <summary>
        /// Defines if term freq and positions should be omitted.
        /// </summary>
        public CustomPropertyMap<T> OmitTermFreqAndPositions(bool omitTermFreqAndPositions = false)
        {
            RegisterCustomJsonMap("'omit_term_freq_and_positions': {0}", omitTermFreqAndPositions.AsString());
            return this;
        }

        /// <summary>
        /// The analyzer used to analyze the text contents when analyzed during indexing and when searching using a query string. Defaults to the globally configured analyzer.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public CustomPropertyMap<T> Analyzer(string analyzer)
        {
            RegisterCustomJsonMap("'analyzer': {0}", analyzer.Quotate());
            return this;
        }

        /// <summary>
        /// The analyzer used to analyze the text contents when analyzed during indexing and when searching using a query string. Defaults to the globally configured analyzer.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public CustomPropertyMap<T> Analyzer(DefaultAnalyzers analyzer)
        {
            return Analyzer(analyzer.AsString());
        }

        /// <summary>
        /// The analyzer used to analyze the text contents when analyzed during indexing.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/ 
        /// </summary>       
        public CustomPropertyMap<T> IndexAnalyzer(string analyzer)
        {
            RegisterCustomJsonMap("'index_analyzer': {0}", analyzer.Quotate());
            return this;
        }

        /// <summary>
        /// The analyzer used to analyze the text contents when analyzed during indexing.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/ 
        /// </summary>       
        public CustomPropertyMap<T> IndexAnalyzer(DefaultAnalyzers analyzer)
        {
            return IndexAnalyzer(analyzer.AsString());
        }

        /// <summary>
        /// The analyzer used to analyze the field when part of a query string.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public CustomPropertyMap<T> SearchAnalyzer(string analyzer)
        {
            RegisterCustomJsonMap("'search_analyzer': {0}", analyzer.Quotate());
            return this;
        }

        /// <summary>
        /// The analyzer used to analyze the field when part of a query string.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public CustomPropertyMap<T> SearchAnalyzer(DefaultAnalyzers analyzer)
        {
            return SearchAnalyzer(analyzer.AsString());
        }



        protected override string GetElasticFieldType(Type fieldType)
        {
            if (mappingType != null)
                return mappingType;

            return ElasticCoreTypeMapper.GetElasticType(fieldType);
        }
    }
}