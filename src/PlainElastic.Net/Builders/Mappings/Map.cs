using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PlainElastic.Net.Mappings
{
    public class Map<T>
    {
        #region Elastic Search Mapping Templates
        private const string RootObjectMap = @"
{{   
   ""{0}"" : {{
      ""dynamic"" : true,
      ""_all"" : {{""enabled"" : true}},

      ""properties"" : {{
{1}
      }}
   }}
}}
";


        private const string ObjectMap = @"
    ""{0}"" : {{
      ""properties"" : {{
{1}
      }}
   }}";
        private const string IndexPropertyMap = @"         ""{0}"" : {{ ""type"" : ""{1}"", ""boost"": {2} }}";
        private const string IgnorePropertyMap = @"         ""{0}"" : {{ ""type"" : ""{1}"", ""index"": ""no"" }}";

        #endregion


        private Map()
        {
            PropertyMapping = new List<string>();
        }


        public List<string> PropertyMapping { get; private set; }


        public static string Root(string rootType, Func<Map<T>, Map<T>> propertyMapping)
        {
            string body = GetPropertyMapping(propertyMapping);
            return RootObjectMap.F(rootType, body);
        }

        public Map<T> Index<TProp>(Expression<Func<T, TProp>> property, int boost = 1)
        {
            string fieldName = GetPropertyName(property);
            string type = GetPropertyType(property);

            PropertyMapping.Add(IndexPropertyMap.F(fieldName, type, boost));

            return this;
        }

        public Map<T> Ignore<TProp>(Expression<Func<T, TProp>> property)
        {
            string fieldName = GetPropertyName(property);
            string type = GetPropertyType(property);

            PropertyMapping.Add(IgnorePropertyMap.F(fieldName, type));
            return this;
        }

        public Map<T> CustomProperty<TProp>(string format, Expression<Func<T, TProp>> property, int boost = 1, bool typed = true)
        {
            string fieldName = GetPropertyName(property);
            string type = GetPropertyType(property);
            
            if (typed)
                PropertyMapping.Add(format.F(fieldName, type ,boost));
            else
                PropertyMapping.Add(format.F(fieldName, boost));

            return this;
        }


        public Map<T> Objects<TProp>(Expression<Func<T, IEnumerable<TProp>>> property, Func<Map<TProp>, Map<TProp>> propertyMapping)
        {
            string propertyName = GetPropertyName(property);
            string body = GetPropertyMapping(propertyMapping);

            PropertyMapping.Add(ObjectMap.F(propertyName, body));

            return this;
        }

        public Map<T> Object<TProp>(Expression<Func<T, TProp>> property, Func<Map<TProp>, Map<TProp>> propertyMapping)
        {
            string propertyName = GetPropertyName(property);
            string body = GetPropertyMapping(propertyMapping);

            PropertyMapping.Add(ObjectMap.F(propertyName, body));

            return this;
        }


        public string GenerateJsonMap()
        {
            return PropertyMapping.JoinWithComma();
        }

        public string GenerateBeautifiedJsonMap()
        {
            return GenerateJsonMap().ButifyJson();
        }


        private static string GetPropertyMapping<TProp>(Func<Map<TProp>, Map<TProp>> propertyMapping)
        {
            return propertyMapping.Invoke(new Map<TProp>()).GenerateJsonMap();
        }

        private static string GetPropertyType<TProp>(Expression<Func<T, TProp>> property)
        {
            var propertyType = typeof (TProp);

            // Elastic Search interprets all arrays/enumerations as strings.            
            if( typeof(IEnumerable).IsAssignableFrom(propertyType) )
                return "string";
            
            // Elastic Search stores enums as long.
            if (propertyType.IsEnum)
                return "long";

            if (propertyType == typeof (DateTime))
                return "date";

            var propertyTypeName = Reflect<T>.LowerCasedPropertyType(property);
            return propertyTypeName;
        }

        private static string GetPropertyName<TProp>(Expression<Func<T, TProp>> property)
        {
            return Reflect<T>.ShortPropertyName(property);
        }

    }

}
