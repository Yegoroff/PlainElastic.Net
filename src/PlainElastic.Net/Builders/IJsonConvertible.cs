namespace PlainElastic.Net.Builders
{
    public interface IJsonConvertible
    {
        string ToJson();
    }
}


namespace PlainElastic.Net {

    using PlainElastic.Net.Utils;

    public static class JsonConvertibleExtensions
    {
        /// <summary>
        /// Builds JSON query.
        /// </summary>
        public static string Build(this Builders.IJsonConvertible jsonBuilder)
        {
            return jsonBuilder.ToJson();
        }

        /// <summary>
        /// Builds beatified JSON query.
        /// </summary>
        public static string BuildBeautified(this Builders.IJsonConvertible jsonBuilder)
        {
            return jsonBuilder.Build().BeautifyJson();
        }

    }
}