using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// Base class for nGram Tokenizers and Filters.
    /// </summary>
    public abstract class NGramComponentBase<TPart> : NamedComponentBase<TPart> where TPart : NGramComponentBase<TPart>
    {
        /// <summary>
        /// Sets the minimal number of characters in N-grams built.
        /// Defaults to 1.
        /// </summary>
        public TPart MinGram(int minGram = 1)
        {
            RegisterJsonPart("'min_gram': {0}", minGram.AsString());
            return (TPart)this;
        }

        /// <summary>
        /// Sets the maximal number of characters in N-grams built.
        /// Defaults to 2.
        /// </summary>
        public TPart MaxGram(int maxGram = 2)
        {
            RegisterJsonPart("'max_gram': {0}", maxGram.AsString());
            return (TPart)this;
        }
    }
}