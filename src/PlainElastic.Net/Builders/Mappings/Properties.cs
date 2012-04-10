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
            RegisterMapAsJson(SpecifyPropertyName(stringProperty, fieldName));
            return this;
        }



        /// <summary>
        /// Represents numeric fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public Properties<T> Number<TField>(Expression<Func<T, TField>> field, Func<NumberMap<T>, NumberMap<T>> numberProperty = null)
        {
            var fieldName = field.GetPropertyPath();
            RegisterMapAsJson(SpecifyPropertyName(numberProperty, fieldName, typeof(TField)));
            return this;
        }

        /// <summary>
        /// Represents numeric fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public Properties<T> Number(string fieldName, Func<NumberMap<T>, NumberMap<T>> numberProperty = null)
        {
            RegisterMapAsJson(SpecifyPropertyName(numberProperty, fieldName));
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
            RegisterMapAsJson(SpecifyPropertyName(dateProperty, fieldName));
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
            RegisterMapAsJson(SpecifyPropertyName(booleanProperty, fieldName));
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
            RegisterMapAsJson(SpecifyPropertyName(binaryProperty, fieldName));
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
            Func<Object<TField>, Object<TField>> namedObjectProperty;
            if(objectProperty == null)
                namedObjectProperty = obj => obj.Field(fieldName);
            else 
                namedObjectProperty = obj => objectProperty(obj.Field(fieldName));

            RegisterMapAsJson(namedObjectProperty);
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
            Func<NestedObject<TField>, NestedObject<TField>> namedObjectProperty = obj => nestedObjectProperty(obj).Field(fieldName);
            RegisterMapAsJson(namedObjectProperty);
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
            RegisterMapAsJson(SpecifyPropertyName(customProperty, fieldName, typeof(TField)));
            return this;
        }

        /// <summary>
        /// Represents custom property mapping mapping.
        /// </summary>
        public Properties<T> CustomProperty(string fieldName, Func<CustomPropertyMap<T>, CustomPropertyMap<T>> customProperty = null)
        {
            RegisterMapAsJson(SpecifyPropertyName(customProperty, fieldName));
            return this;
        }



        private static Func<TPropMapping, TPropMapping> SpecifyPropertyName<TPropMapping>(Func<TPropMapping, TPropMapping> property, string fieldName, Type fieldType = null) where TPropMapping : PropertyBase<T, TPropMapping>
        {
            if (property == null)
                return obj => obj.Field(fieldName, fieldType);

            return obj => property(obj.Field(fieldName, fieldType));
        }
        

        protected override string ApplyMappingTemplate(string mappingBody)
        {
            return "'properties': {{ {0} }}".AltQuoteF(mappingBody);
        }
    }
}