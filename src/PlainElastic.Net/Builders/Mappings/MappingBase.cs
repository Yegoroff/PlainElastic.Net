using System;
using System.Collections.Generic;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Mappings
{
    public abstract class MappingBase<TMapping> : IJsonConvertible where TMapping : MappingBase<TMapping>
    {

        protected MappingBase()
        {
            Mappings = new List<string>();
        }


        public List<string> Mappings { get; private set; }



        /// <summary>
        /// Adds a custom mapping to Map.
        /// You can use ' instead of " to simplify mapFormat creation.
        /// </summary>
        public TMapping Custom(string mapFormat, params string[] args)
        {
            RegisterCustomJsonMap(mapFormat, args);
            return (TMapping)this;
        }



        /// <summary>
        /// Adds a custom JSON mapping to Object Map.
        /// You can use ' instead of " to simplify mapFormat creation.
        /// </summary>
        protected void RegisterCustomJsonMap(string mapFormat, params string[] args)
        {
            if (mapFormat.IsNullOrEmpty())
                return;

            var map = mapFormat.AltQuoteF(args);
            Mappings.Add(map);
        }


        /// <summary>
        /// Registers the passed map function as JSON got as result of its execution.
        /// </summary>
        protected TResultMap RegisterMapAsJson<TMap, TResultMap>(Func<TMap, TResultMap> map)
            where TMap : new()
            where TResultMap : IJsonConvertible
        {
            var instance = new TMap();
            var resultMap = map.Invoke(instance);

            var jsonMap = resultMap.ToJson();

            if (!jsonMap.IsNullOrEmpty())
                Mappings.Add(jsonMap);

            return resultMap;
        }


        protected abstract string ApplyMappingTemplate(string mappingBody);


        string IJsonConvertible.ToJson()
        {
            var body = Mappings.JoinWithComma();
            return ApplyMappingTemplate(body);
        }


        public override string ToString()
        {
            return ((IJsonConvertible) this).ToJson();
        }
    }
}