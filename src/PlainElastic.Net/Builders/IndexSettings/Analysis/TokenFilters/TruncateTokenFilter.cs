using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// The truncate token filter can be used to truncate tokens into a specific length.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/truncate-tokenfilter.html
    /// </summary>
    public class TruncateTokenFilter : NamedComponentBase<TruncateTokenFilter>
    {

        /// <summary>
        /// Sets the number of characters to truncate to.
        /// Defaults to 10.
        /// </summary>
        public TruncateTokenFilter Length(int length = 10)
        {
            RegisterJsonPart("'length': {0}", length.AsString());
            return this;
        }


        protected override string GetComponentType()
        {
            return DefaultTokenFilters.truncate.AsString();
        }
    }
}