using System;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Mappings
{
    public class CoreFields<T> : MappingBase<CoreFields<T>>
    {
        /// <summary>
        /// Represents text fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public CoreFields<T> String<TField>(Expression<Func<T, TField>> field, Func<StringMap<T>, StringMap<T>> stringProperty = null)
        {
            var fieldName = field.GetPropertyPath();

            return String(fieldName, stringProperty);
        }

        /// <summary>
        /// Represents text fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public CoreFields<T> String(string fieldName, Func<StringMap<T>, StringMap<T>> stringProperty = null)
        {
            RegisterMapAsJson(SpecifyPropertyName(stringProperty, fieldName));
            return this;
        }



        /// <summary>
        /// Represents numeric fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public CoreFields<T> Number<TField>(Expression<Func<T, TField>> field, Func<NumberMap<T>, NumberMap<T>> numberProperty = null)
        {
            var fieldName = field.GetPropertyPath();
            RegisterMapAsJson(SpecifyPropertyName(numberProperty, fieldName, typeof(TField)));
            return this;
        }

        /// <summary>
        /// Represents numeric fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public CoreFields<T> Number(string fieldName, Func<NumberMap<T>, NumberMap<T>> numberProperty = null)
        {
            RegisterMapAsJson(SpecifyPropertyName(numberProperty, fieldName));
            return this;
        }



        /// <summary>
        /// Represents Date fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public CoreFields<T> Date<TField>(Expression<Func<T, TField>> field, Func<DateMap<T>, DateMap<T>> dateProperty = null)
        {
            var fieldName = field.GetPropertyPath();

            return Date(fieldName, dateProperty);
        }

        /// <summary>
        /// Represents Date fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public CoreFields<T> Date(string fieldName, Func<DateMap<T>, DateMap<T>> dateProperty = null)
        {
            RegisterMapAsJson(SpecifyPropertyName(dateProperty, fieldName));
            return this;
        }



        /// <summary>
        /// Represents boolean fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public CoreFields<T> Boolean<TField>(Expression<Func<T, TField>> field, Func<BooleanMap<T>, BooleanMap<T>> booleanProperty = null)
        {
            var fieldName = field.GetPropertyPath();

            return Boolean(fieldName, booleanProperty);
        }

        /// <summary>
        /// Represents boolean fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public CoreFields<T> Boolean(string fieldName, Func<BooleanMap<T>, BooleanMap<T>> booleanProperty = null)
        {
            RegisterMapAsJson(SpecifyPropertyName(booleanProperty, fieldName));
            return this;
        }



        /// <summary>
        /// Represents binary data fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public CoreFields<T> Binary<TField>(Expression<Func<T, TField>> field, Func<BinaryMap<T>, BinaryMap<T>> binaryProperty = null)
        {
            var fieldName = field.GetPropertyPath();

            return Binary(fieldName, binaryProperty);
        }

        /// <summary>
        /// Represents binary data fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public CoreFields<T> Binary(string fieldName, Func<BinaryMap<T>, BinaryMap<T>> binaryProperty = null)
        {
            RegisterMapAsJson(SpecifyPropertyName(binaryProperty, fieldName));
            return this;
        }


        private static Func<TPropMapping, TPropMapping> SpecifyPropertyName<TPropMapping>(Func<TPropMapping, TPropMapping> property, 
                                                           string fieldName, Type fieldType = null) where TPropMapping : PropertyBase<T, TPropMapping>
        {
            if (property == null)
                return obj => obj.Field(fieldName, fieldType);

            return obj => property(obj.Field(fieldName, fieldType));
        }
        

        protected override string ApplyMappingTemplate(string mappingBody)
        {
            return "'fields': {{ {0} }}".AltQuoteF(mappingBody);
        }
    }
}