using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Mappings
{
    public class Properties<T> : MappingBase<Properties<T>>
    {
        /// <summary>
        /// Represents text fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public Properties<T> String<TField>(Expression<Func<T, TField>> field, Func<StringMap<T>, StringMap<T>> stringProperty = null)
        {
            var fieldName = field.GetPropertyPath();

            return String(fieldName, stringProperty);
        }

        /// <summary>
        /// Represents text fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public Properties<T> String(string fieldName, Func<StringMap<T>, StringMap<T>> stringProperty = null)
        {
            RegisterMapAsJson(stringProperty.Bind(map => map.Field(fieldName)));
            return this;
        }



        /// <summary>
        /// Represents numeric fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public Properties<T> Number<TField>(Expression<Func<T, TField>> field, Func<NumberMap<T>, NumberMap<T>> numberProperty = null)
        {
            var fieldName = field.GetPropertyPath();
            RegisterMapAsJson(numberProperty.Bind(map => map.Field(fieldName, typeof(TField))));
            return this;
        }

        /// <summary>
        /// Represents numeric fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public Properties<T> Number(string fieldName, Func<NumberMap<T>, NumberMap<T>> numberProperty = null)
        {
            RegisterMapAsJson(numberProperty.Bind(map => map.Field(fieldName, null)));
            return this;
        }



        /// <summary>
        /// Represents Date fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public Properties<T> Date<TField>(Expression<Func<T, TField>> field, Func<DateMap<T>, DateMap<T>> dateProperty = null)
        {
            var fieldName = field.GetPropertyPath();

            return Date(fieldName, dateProperty);
        }

        /// <summary>
        /// Represents Date fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public Properties<T> Date(string fieldName, Func<DateMap<T>, DateMap<T>> dateProperty = null)
        {
            RegisterMapAsJson(dateProperty.Bind(map => map.Field(fieldName, null)));
            return this;
        }



        /// <summary>
        /// Represents boolean fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public Properties<T> Boolean<TField>(Expression<Func<T, TField>> field, Func<BooleanMap<T>, BooleanMap<T>> booleanProperty = null)
        {
            var fieldName = field.GetPropertyPath();

            return Boolean(fieldName, booleanProperty);
        }

        /// <summary>
        /// Represents boolean fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public Properties<T> Boolean(string fieldName, Func<BooleanMap<T>, BooleanMap<T>> booleanProperty = null)
        {
            RegisterMapAsJson(booleanProperty.Bind(map => map.Field(fieldName, null)));
            return this;
        }



        /// <summary>
        /// Represents binary data fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public Properties<T> Binary<TField>(Expression<Func<T, TField>> field, Func<BinaryMap<T>, BinaryMap<T>> binaryProperty = null)
        {
            var fieldName = field.GetPropertyPath();

            return Binary(fieldName, binaryProperty);
        }

        /// <summary>
        /// Represents binary data fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public Properties<T> Binary(string fieldName, Func<BinaryMap<T>, BinaryMap<T>> binaryProperty = null)
        {
            RegisterMapAsJson(binaryProperty.Bind(map => map.Field(fieldName, null)));
            return this;
        }



        /// <summary>
        /// Builds a mapping that allows to map inner JSON object. 
        /// http://www.elasticsearch.org/guide/reference/mapping/object-type.html
        /// </summary>
        public Properties<T> Object<TField>(Expression<Func<T, TField>> field, Func<Object<TField>, Object<TField>> objectProperty = null)
        {
            var fieldName = field.GetPropertyPath();
           
            return Object(fieldName, objectProperty);
        }

        /// <summary>
        /// Builds a mapping that allows to map inner JSON object. 
        /// http://www.elasticsearch.org/guide/reference/mapping/object-type.html
        /// </summary>
        public Properties<T> Object<TField>(Expression<Func<T, IEnumerable<TField>>> field, Func<Object<TField>, Object<TField>> objectProperty = null)
        {
            var fieldName = field.GetPropertyPath();

            return Object(fieldName, objectProperty);
        }

        /// <summary>
        /// Builds a mapping that allows to map inner JSON object. 
        /// http://www.elasticsearch.org/guide/reference/mapping/object-type.html
        /// </summary>
        public Properties<T> Object<TField>(string fieldName, Func<Object<TField>, Object<TField>> objectProperty = null)
        {
            RegisterMapAsJson(objectProperty.Bind(property => property.Field(fieldName)));
            return this;
        }



        /// <summary>
        /// Builds a mapping that allows to map certain sections in the document indexed as nested allowing to query them as if they are separate docs joining with the parent owning doc.
        /// http://www.elasticsearch.org/guide/reference/mapping/nested-type.html
        /// </summary>
        public Properties<T> NestedObject<TField>(Expression<Func<T, TField>> field, Func<NestedObject<TField>, NestedObject<TField>> nestedObjectProperty = null)
        {
            var fieldName = field.GetPropertyPath();

            return NestedObject(fieldName, nestedObjectProperty);
        }

        /// <summary>
        /// Builds a mapping that allows to map certain sections in the document indexed as nested allowing to query them as if they are separate docs joining with the parent owning doc.
        /// http://www.elasticsearch.org/guide/reference/mapping/nested-type.html
        /// </summary>
        public Properties<T> NestedObject<TField>(Expression<Func<T, IEnumerable<TField>>> field, Func<NestedObject<TField>, NestedObject<TField>> nestedObjectProperty = null)
        {
            var fieldName = field.GetPropertyPath();

            return NestedObject(fieldName, nestedObjectProperty);
        }

        /// <summary>
        /// Builds a mapping that allows to map certain sections in the document indexed as nested allowing to query them as if they are separate docs joining with the parent owning doc.
        /// http://www.elasticsearch.org/guide/reference/mapping/nested-type.html
        /// </summary>
        public Properties<T> NestedObject<TField>(string fieldName, Func<NestedObject<TField>, NestedObject<TField>> nestedObjectProperty = null)
        {
            RegisterMapAsJson(nestedObjectProperty.Bind(property => property.Field(fieldName)));
            return this;
        }


        /// <summary>
        /// Allows to register collection of custom property mappings.
        /// </summary>
        public Properties<T> CustomProperties(IEnumerable<CustomPropertyMap<T>> customProperties )
        {
            string propertiesJson = customProperties.Select(prop => prop.ToString()).JoinWithComma();
            RegisterCustomJsonMap(propertiesJson);
            return this;
        }

        /// <summary>
        /// Represents custom property mapping mapping.
        /// </summary>
        public Properties<T> CustomProperty<TField>(Expression<Func<T, TField>> field, Func<CustomPropertyMap<T>, CustomPropertyMap<T>> customProperty = null)
        {
            var fieldName = field.GetPropertyPath();
            RegisterMapAsJson(customProperty.Bind(map => map.Field(fieldName, typeof(TField))));
            return this;
        }

        /// <summary>
        /// Represents custom property mapping mapping.
        /// </summary>
        public Properties<T> CustomProperty(string fieldName, Func<CustomPropertyMap<T>, CustomPropertyMap<T>> customProperty = null)
        {
            RegisterMapAsJson(customProperty.Bind(map => map.Field(fieldName, null)));
            return this;
        }



        /// <summary>
        /// The attachment type allows to index different “attachment” type field (encoded as base64),
        /// for example, microsoft office formats, open document formats, ePub, HTML, and so on.
        /// see http://www.elasticsearch.org/guide/reference/mapping/attachment-type.html
        /// </summary>
        public Properties<T> Attachment<TField>(Expression<Func<T, TField>> field, Func<Attachment<T>, Attachment<T>> attachmentProperty = null)
        {
            var fieldName = field.GetPropertyPath();

            return Attachment(fieldName, attachmentProperty);
        }

        /// <summary>
        /// The attachment type allows to index different “attachment” type field (encoded as base64),
        /// for example, microsoft office formats, open document formats, ePub, HTML, and so on.
        /// see http://www.elasticsearch.org/guide/reference/mapping/attachment-type.html
        /// </summary>
        public Properties<T> Attachment(string fieldName, Func<Attachment<T>, Attachment<T>> attachmentProperty = null)
        {
            Func<Attachment<T>, Attachment<T>> namedAttachmentProperty;
            if (attachmentProperty == null)
                namedAttachmentProperty = obj => obj.Field(fieldName);
            else
                namedAttachmentProperty = obj => attachmentProperty(obj.Field(fieldName));

            RegisterMapAsJson(namedAttachmentProperty);
            return this;
        }


        /// <summary>
        /// The multi_field type allows to map several core types of the same value. 
        /// This can come very handy, for example, when wanting to map a string type, 
        /// once when its analyzed and once when its not_analyzed.
        /// see http://www.elasticsearch.org/guide/reference/mapping/multi-field-type.html
        /// </summary>
        public Properties<T> MultiField<TField>(Expression<Func<T, TField>> field, Func<MultiField<T>, MultiField<T>> multiFieldProperty = null)
        {
            var fieldName = field.GetPropertyPath();

            return MultiField(fieldName, multiFieldProperty);
        }

        /// <summary>
        /// The multi_field type allows to map several core types of the same value. 
        /// This can come very handy, for example, when wanting to map a string type, 
        /// once when its analyzed and once when its not_analyzed.
        /// see http://www.elasticsearch.org/guide/reference/mapping/multi-field-type.html
        /// </summary>
        public Properties<T> MultiField(string fieldName, Func<MultiField<T>, MultiField<T>> multiFieldProperty = null)
        {
            Func<MultiField<T>, MultiField<T>> namedMultiFieldProperty;
            if (multiFieldProperty == null)
                namedMultiFieldProperty = obj => obj.Field(fieldName);
            else
                namedMultiFieldProperty = obj => multiFieldProperty(obj.Field(fieldName));

            RegisterMapAsJson(namedMultiFieldProperty);
            return this;
        }

        /// <summary>
        /// Represents geo_point fields mapping.
        /// see http://www.elasticsearch.org/guide/en/elasticsearch/reference/0.90/mapping-geo-point-type.html
        /// </summary>
        public Properties<T> GeoPoint<TField>(Expression<Func<T, TField>> field, Func<GeoPointMap<T>, GeoPointMap<T>> geoPointProperty = null)
        {
            var fieldName = field.GetPropertyPath();

            return GeoPoint(fieldName, geoPointProperty);
        }

        /// <summary>
        /// Represents geo_point fields mapping.
        /// see http://www.elasticsearch.org/guide/en/elasticsearch/reference/0.90/mapping-geo-point-type.html
        /// </summary>
        public Properties<T> GeoPoint(string fieldName, Func<GeoPointMap<T>, GeoPointMap<T>> geoPointProperty = null)
        {
            RegisterMapAsJson(geoPointProperty.Bind(map => map.Field(fieldName)));
            return this;
        }

        protected override string ApplyMappingTemplate(string mappingBody)
        {
            return "'properties': {{ {0} }}".AltQuoteF(mappingBody);
        }
    }
}