using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// Base class for edgeNGram Tokenizers and Filters.
    /// </summary>
    public abstract class EdgeNGramComponentBase<TPart> : NGramComponentBase<TPart> where TPart : EdgeNGramComponentBase<TPart>
    {
        /// <summary>
        /// Sets the text side from which N-grams are built.
        /// </summary>
        public TPart Side(EdgeNGramSide side)
        {
            RegisterJsonPart("'side': {0}", side.AsString().Quotate());
            return (TPart)this;
        }
    }
}