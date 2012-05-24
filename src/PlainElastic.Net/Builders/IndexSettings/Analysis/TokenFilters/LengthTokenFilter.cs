using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A token filter of type length that removes words that are too long or too short for the stream.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/length-tokenfilter.html
    /// </summary>
    public class LengthTokenFilter : NamedComponentBase<LengthTokenFilter>
    {

        /// <summary>
        /// Sets the minimum length.
        /// Defaults to 0.
        /// </summary>
        public LengthTokenFilter Min(int min = 0)
        {
            RegisterJsonPart("'min': {0}", min.AsString());
            return this;
        }

        /// <summary>
        /// Sets the maximum length.
        /// Defaults to int.MaxValue.
        /// </summary>
        public LengthTokenFilter Max(int max = int.MaxValue)
        {
            RegisterJsonPart("'max': {0}", max.AsString());
            return this;
        }


        protected override string GetComponentType()
        {
            return DefaultTokenFilters.length.AsString();
        }
    }
}