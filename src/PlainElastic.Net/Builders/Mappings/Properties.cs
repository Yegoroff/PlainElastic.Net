using System;

namespace PlainElastic.Net.Mappings
{
    public class Properties<T> : MappingBase
    {
        /// <summary>
        /// Represents text fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public Properties<T> String(Func<StringMap<T>, StringMap<T>> stringProperty)
        {
            RegisterMapAsJson(stringProperty);
            return this;
        }

        /// <summary>
        /// Represents numeric fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public Properties<T> Number(Func<NumberMap<T>, NumberMap<T>> numberProperty)
        {
            RegisterMapAsJson(numberProperty);
            return this;
        }

        /// <summary>
        /// Represents Date fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public Properties<T> Date(Func<DateMap<T>, DateMap<T>> dateProperty)
        {
            RegisterMapAsJson(dateProperty);
            return this;
        }

        /// <summary>
        /// Represents boolean fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public Properties<T> Boolean(Func<BooleanMap<T>, BooleanMap<T>> booleanProperty)
        {
            RegisterMapAsJson(booleanProperty);
            return this;
        }

        /// <summary>
        /// Represents binary data fields mapping.
        /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
        /// </summary>
        public Properties<T> Binary(Func<BinaryMap<T>, BinaryMap<T>> binaryProperty)
        {
            RegisterMapAsJson(binaryProperty);
            return this;

        }

        /// <summary>
        /// Builds a mapping that allows to map inner JSON object. 
        /// http://www.elasticsearch.org/guide/reference/mapping/object-type.html
        /// </summary>
        public Properties<T> Object<TField>(Func<Object<T>, Object<TField>> objectProperty)
        {
            RegisterMapAsJson(objectProperty);
            return this;
        }

        /// <summary>
        /// Builds a mapping that allows to map certain sections in the document indexed as nested allowing to query them as if they are separate docs joining with the parent owning doc.
        /// http://www.elasticsearch.org/guide/reference/mapping/nested-type.html
        /// </summary>
        public Properties<T> NestedObject<TField>(Func<NestedObject<T>, NestedObject<TField>> nestedObjectProperty)
        {
            RegisterMapAsJson(nestedObjectProperty);
            return this;
        }

        /// <summary>
        /// Adds a custom mapping to properties Map.
        /// You can use ' instead of " to simplify mapFormat creation.
        /// </summary>
        public Properties<T> Custom(string mapFormat, params string[] args)
        {
            RegisterCustomJsonMap(mapFormat, args);

            return this;
        }



        protected override string ApplyMappingTemplate(string mappingBody)
        {
            return " 'properties': {{ {0} }}".SmartQuoteF(mappingBody);
        }
    }
}