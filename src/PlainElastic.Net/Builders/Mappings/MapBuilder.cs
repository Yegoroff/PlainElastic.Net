using System;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Mappings
{
    public class MapBuilder<T> 
    {
        private string rootObjectMap;

        public MapBuilder<T> RootObject(string typeName, Func<RootObject<T>, RootObject<T>> map)
        {
            var rootInstance = new RootObject<T>(typeName);
            RootObject<T> resultMap = map.Invoke(rootInstance);

            rootObjectMap = ((IJsonConvertible)resultMap).ToJson();

            return this;
        }


        public string Build()
        {
            if (rootObjectMap.IsNullOrEmpty())
                return "";

            return "{{ {0} }}".F(rootObjectMap);
        }

        public string BuildBeautified()
        {
            return Build().BeautifyJson();
        }


        public override string ToString()
        {
            return BuildBeautified();
        }
    }
}