using System.Collections.Generic;
using PlainElastic.Net.Utils;

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


        public static GetResult<T> ToGetResult<T>(this IJsonSerializer serializer, string operationResult)
        {           
            return serializer.Deserialize<GetResult<T>>(operationResult);
        }

        public static IndexResult ToIndexResult(this IJsonSerializer serializer, string operationResult)
        {
            return serializer.Deserialize<IndexResult>(operationResult);
        }

        public static DeleteResult ToDeleteResult(this IJsonSerializer serializer, string operationResult)
        {
            return serializer.Deserialize<DeleteResult>(operationResult);
        }

        public static CountResult ToCountResult(this IJsonSerializer serializer, string operationResult)
        {
            return serializer.Deserialize<CountResult>(operationResult);
        }


        public static SearchResult<T> ToSearchResult<T>(this IJsonSerializer serializer, string operationResult)
        {
            return serializer.Deserialize<SearchResult<T>>(operationResult);
        }

        public static CommandResult ToCommandResult(this IJsonSerializer serializer, string operationResult)
        {
            return serializer.Deserialize<CommandResult>(operationResult);
        }

        public static BulkResult ToBulkResult(this IJsonSerializer serializer, string operationResult)
        {
            return serializer.Deserialize<BulkResult>(operationResult);
        }

        public static StatusResult ToStatusResult(this IJsonSerializer serializer, string operationResult)
        {
            return serializer.Deserialize<StatusResult>(operationResult);
        }

        public static Dictionary<string, IndexAliasesResult> ToIndexAliasesResult(this IJsonSerializer serializer, string result)
        {
            return serializer.Deserialize<Dictionary<string, IndexAliasesResult>>(result);
        }

    }

}
