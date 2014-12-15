using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Mappings
{
    /// <summary>
    /// Allows to control _all field behavior 
    /// see http://www.elasticsearch.org/guide/reference/mapping/all-field.html
    /// </summary>
    public class AllField<T> : MappingBase<AllField<T>>
    {

        /// <summary>
        /// Allows to disable _all field.
        /// When disabling the _all field, it is a good practice to set index.query.default_field to a different value 
        /// </summary>
        public AllField<T> Enabled(bool enabled)
        {
            RegisterCustomJsonMap("'enabled': {0}", enabled.AsString());
            return this;
        }

        public AllField<T> Store(bool store)
        {
            RegisterCustomJsonMap("'store': {0}", store.AsString());
            return this;
        }

        public AllField<T> TermVector(TermVector termVector)
        {
            RegisterCustomJsonMap("'term_vector': {0}", termVector.AsString().Quotate());
            return this;
        }

       
        /// <summary>
        /// The analyzer used to analyze the text contents when analyzed during indexing and when searching using a query string. Defaults to the globally configured analyzer.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public AllField<T> Analyzer(string analyzer)
        {
            RegisterCustomJsonMap("'analyzer': {0}", analyzer.Quotate());
            return this;
        }

        /// <summary>
        /// The analyzer used to analyze the text contents when analyzed during indexing and when searching using a query string. Defaults to the globally configured analyzer.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public AllField<T> Analyzer(DefaultAnalyzers analyzer)
        {
            return Analyzer(analyzer.AsString());
        }        

        /// <summary>
        /// The analyzer used to analyze the text contents when analyzed during indexing.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/ 
        /// </summary>       
        public AllField<T> IndexAnalyzer(string analyzer)
        {
            RegisterCustomJsonMap("'index_analyzer': {0}", analyzer.Quotate());
            return this;
        }

        /// <summary>
        /// The analyzer used to analyze the text contents when analyzed during indexing.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/ 
        /// </summary>       
        public AllField<T> IndexAnalyzer(DefaultAnalyzers analyzer)
        {
            return IndexAnalyzer(analyzer.AsString());
        }

        /// <summary>
        /// The analyzer used to analyze the field when part of a query string.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public AllField<T> SearchAnalyzer(string analyzer)
        {
            RegisterCustomJsonMap("'search_analyzer': {0}", analyzer.Quotate());
            return this;
        }

        /// <summary>
        /// The analyzer used to analyze the field when part of a query string.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public AllField<T> SearchAnalyzer(DefaultAnalyzers analyzer)
        {
            return SearchAnalyzer(analyzer.AsString());
        }



        protected override string ApplyMappingTemplate(string mappingBody)
        {
            return "'_all': {{ {0} }}".AltQuoteF(mappingBody);
        }
        
    }
}