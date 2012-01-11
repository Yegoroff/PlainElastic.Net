namespace PlainElastic.Net.Serialization
{
    public static class SerializationExtensions
    {
        public static string ToJson(this IJsonSerializer serializer, object value)
        {
            return serializer.Serialize(value);
        }


        public static T ToGetResult<T>(this IJsonSerializer serializer, OperationResult operationResult)
        {
            return (T) serializer.Deserialize(operationResult.Result, typeof (T));
        }


    }
}
