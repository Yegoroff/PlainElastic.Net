using System;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Mappings
{
    public abstract class PropertyBase<T, TMapping> : MappingBase<TMapping> where TMapping : PropertyBase<T, TMapping>
    {

        public string FieldName { get; set; }

        public string FieldType { get; set; }



        public TMapping Field(string fieldName, Type fieldType = null)
        {
            FieldName = fieldName;
            FieldType = GetElasticFieldType(fieldType ?? typeof(object));

            return (TMapping)this;
        }


        public TMapping Field<TField>(Expression<Func<T, TField>> field)
        {
            return Field(field.GetPropertyPath(), typeof (TField));
        }



        /// <summary>
        /// The name of the field that will be stored in the index. Defaults to the property/field name.
        /// </summary>
        public TMapping IndexName(string indexName)
        {
            RegisterCustomJsonMap("'index_name': {0}", indexName.Quotate());
            return (TMapping) this;
        }

        /// <summary>
        /// Set to true the store actual field in the index, false to not store it.
        /// </summary>
        public TMapping Store(bool store = false)
        {
            RegisterCustomJsonMap("'store': {0}", store.AsString());
            return (TMapping) this;            
        }

        /// <summary>
        /// Allows to control whether field searchable and analyzed.
        /// </summary>
        public TMapping Index(IndexState index)
        {
            RegisterCustomJsonMap("'index': {0}", index.AsString().Quotate());
            return (TMapping) this;            
        }

        /// <summary>
        /// Sets the boost value of the property. Defaults to 1.0.
        /// </summary>
        public TMapping Boost(double boost)
        {
            RegisterCustomJsonMap("'boost': {0}", boost.AsString());
            return (TMapping) this;            
        }

        /// <summary>
        /// When there is a (JSON) null value for the field, use the null_value as the field value. Defaults to not adding the field at all.
        /// </summary>
        public TMapping NullValue(string nullValue)
        {
            RegisterCustomJsonMap("'null_value': {0}", nullValue.Quotate());
            return (TMapping) this;            
        }

        /// <summary>
        /// Defines should the field be included in the _all field.
        /// </summary>
        public TMapping IncludeInAll(bool includeInAll)
        {
            RegisterCustomJsonMap("'include_in_all': {0}", includeInAll.AsString());
            return (TMapping) this;            
        }


        protected override string ApplyMappingTemplate(string mappingBody)
        {
            if (mappingBody.IsNullOrEmpty())
                return "{0}: {{ 'type': {1} }}".AltQuoteF(FieldName.Quotate(), FieldType.Quotate());

            return "{0}: {{ 'type': {1},{2} }}".AltQuoteF(FieldName.Quotate(), FieldType.Quotate(), mappingBody);
        }

        protected abstract string GetElasticFieldType(Type fieldType);
    }
}