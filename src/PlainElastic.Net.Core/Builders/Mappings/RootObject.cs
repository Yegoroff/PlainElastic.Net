using System;

using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Mappings
{
    /// <summary>
    /// Builds a mapping that allows to map root JSON object. 
    /// http://www.elasticsearch.org/guide/reference/mapping/root-object-type.html
    /// </summary>
    public class RootObject<T> : ObjectBase<T, RootObject<T>>
    {
        
        public RootObject(string mappingTypeName)
        {
            Name = mappingTypeName;
        }

        public RootObject() {}


        /// <summary>
        /// The type mapping level analyzer used to analyze the text contents when analyzed during indexing.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/ 
        /// </summary>       
        public RootObject<T> IndexAnalyzer(string analyzer)
        {
            RegisterCustomJsonMap("'index_analyzer': {0}", analyzer.Quotate());
            return this;
        }

        /// <summary>
        /// The type mapping level analyzer used to analyze the text contents when analyzed during indexing.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/ 
        /// </summary>       
        public RootObject<T> IndexAnalyzer(DefaultAnalyzers analyzer)
        {
            return IndexAnalyzer(analyzer.AsString());
        }

        /// <summary>
        /// The type mapping level analyzer used to analyze the field when part of a query string.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public RootObject<T> SearchAnalyzer(string analyzer)
        {
            RegisterCustomJsonMap("'search_analyzer': {0}", analyzer.Quotate());
            return this;
        }

        /// <summary>
        /// The type mapping level analyzer used to analyze the field when part of a query string.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public RootObject<T> SearchAnalyzer(DefaultAnalyzers analyzer)
        {
            return SearchAnalyzer(analyzer.AsString());
        }

        /// <summary>
        /// Allows to set one or more date formats that will be used to detect date fields.
        /// Note: dynamic_date_formats are used only for dynamically added date fields, not for date fields that you specify in your mapping.
        /// see: http://www.elasticsearch.org/guide/reference/mapping/date-format.html
        /// </summary>
        public RootObject<T> DynamicDateFormats(string[] dynamicDateFormats)
        {
            RegisterCustomJsonMap("'dynamic_date_formats': [ {0} ]", dynamicDateFormats.Quotate().JoinWithComma());
            return this;
        }

        /// <summary>
        /// Allows to disable automatic date type detection (a new field introduced and matches the provided format)
        /// </summary>
        public RootObject<T> DateDetection(bool dateDetection = true)
        {
            RegisterCustomJsonMap("'date_detection': {0}", dateDetection.AsString());
            return this;
        }

        /// <summary>
        /// Allows to automatically detect numeric values from string.
        /// </summary>
        public RootObject<T> NumericDetection(bool numericDetection = false)
        {
            RegisterCustomJsonMap("'numeric_detection': {0}", numericDetection.AsString());
            return this;
        }

        /// <summary>
        /// Dynamic templates allow to define mapping templates that will be applied when dynamic introduction of fields / objects happens.
        /// </summary>
        public RootObject<T> DynamicTemplates(params string[] dynamicTemplates)
        {
            RegisterCustomJsonMap("'dynamic_templates': [ {0} ]", dynamicTemplates.JoinWithComma());
            return this;
        }

        /// <summary>
        /// Simple storage for custom metadata associated with type mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/meta.html
        /// </summary>
        public RootObject<T> Meta(string metaJson)
        {
            RegisterCustomJsonMap("'_meta': {0}", metaJson);
            return this;
        }

        /// <summary>
        /// Allows to map _all field
        /// see http://www.elasticsearch.org/guide/reference/mapping/all-field.html
        /// </summary>
        public RootObject<T> All(Func<AllField<T>, AllField<T>> allMap )
        {
            RegisterMapAsJson(allMap);
            return this;
        }

        /// <summary>
        /// Allows to control _id field behavior 
        /// see http://www.elasticsearch.org/guide/reference/mapping/id-field.html
        /// </summary>
        public RootObject<T> Id(Func<IdField<T>, IdField<T>> idMap)
        {
            RegisterMapAsJson(idMap);
            return this;
        }

        /// <summary>
        /// Allows to control _parent field behavior 
        /// see http://www.elasticsearch.org/guide/reference/mapping/parent-field.html
        /// </summary>
        public RootObject<T> Parent(Func<ParentField<T>, ParentField<T>> parentMap)
        {
            RegisterMapAsJson(parentMap);
            return this;
        }

        protected override string ApplyMappingTemplate(string mappingBody)
        {
            if (mappingBody.IsNullOrEmpty())
                return "{0}: {{ }}".AltQuoteF(Name.Quotate());

            return "{0}: {{ {1} }}".AltQuoteF(Name.Quotate(), mappingBody);
        }
        
        /*
        public Type<T> Type;
        public Source<T> Source;
        public Analyzer<T> Analyzer;
        public Boost<T> Boost;        
        public Routing<T> Routing;
        public Index<T> Index;
        public Size<T> Size;
        public Timestamp<T> Timestamp;
        public TTL<T> TTL;
        */
    }
}