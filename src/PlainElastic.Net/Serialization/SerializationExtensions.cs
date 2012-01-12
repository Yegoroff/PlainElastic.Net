namespace PlainElastic.Net.Serialization
{
    public static class SerializationExtensions
    {
        public static string ToJson(this IJsonSerializer serializer, object value)
        {
            return serializer.Serialize(value);
        }

        public static T Deserialize<T>(this IJsonSerializer serializer, string value)
        {
            if (value.IsNullOrEmpty())
                return default(T);

            return (T) serializer.Deserialize(value, typeof (T));
        }



        public static T ToGetResult<T>(this IJsonSerializer serializer, OperationResult operationResult)
        {           
            var getResult = serializer.Deserialize<GetResult<T>>(operationResult);

            return getResult._source;
        }

        public static IndexResult ToIndexResult(this IJsonSerializer serializer, OperationResult operationResult)
        {
            return serializer.Deserialize<IndexResult>(operationResult);            
        }
    }
}
