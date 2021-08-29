using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PlainElastic.Net.Serialization
{
    public class JsonNetSerializer: IJsonSerializer
    {
        public JsonSerializerSettings Settings { get; set; }


        public JsonNetSerializer()
        {
            Settings = new JsonSerializerSettings();
            Settings.Converters.Add(new IsoDateTimeConverter());
            Settings.Converters.Add(new FacetCreationConverter());
            Settings.NullValueHandling = NullValueHandling.Ignore;
        }


        public string Serialize(object o)
        {
            return JsonConvert.SerializeObject(o, Formatting.None, Settings);
        }

        public object Deserialize(string value, Type type)
        {
            return JsonConvert.DeserializeObject(value, type, Settings);
        }
    }
}
