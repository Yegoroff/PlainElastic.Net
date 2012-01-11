using System;

namespace PlainElastic.Net.Serialization
{
    public interface IJsonSerializer
    {
        string Serialize(object o);

        object Deserialize(string value, Type type);
    }
}
