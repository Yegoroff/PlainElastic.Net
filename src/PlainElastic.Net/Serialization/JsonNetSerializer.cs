using System;
using Newtonsoft.Json;

namespace PlainElastic.Net.Serialization
{
    public class JsonNetSerializer: IJsonSerializer
    {
        public JsonSerializerSettings Settings { get; set; }


        public JsonNetSerializer()
        {
            Settings = new JsonSerializerSettings();
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
