using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A token filter of type shingle that constructs shingles (token n-grams) from a token stream.
    /// In other words, it creates combinations of tokens as a single token.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/shingle-tokenfilter.html
    /// </summary>
    public class ShingleTokenFilter : NamedComponentBase<ShingleTokenFilter>
    {

        /// <summary>
        /// Sets the maximal shingle size.
        /// Defaults to 2.
        /// </summary>
        public ShingleTokenFilter MaxShingleSize(int maxShingleSize = 2)
        {
            RegisterJsonPart("'max_shingle_size': {0}", maxShingleSize.AsString());
            return this;
        }

        /// <summary>
        /// Sets flag indicating whether unigrams should be sent to output.
        /// Defaults to true.
        /// </summary>
        public ShingleTokenFilter OutputUnigrams(bool outputUnigrams = true)
        {
            RegisterJsonPart("'output_unigrams': {0}", outputUnigrams.AsString());
            return this;
        }


        protected override string GetComponentType()
        {
            return DefaultTokenFilters.shingle.AsString();
        }
    }
}