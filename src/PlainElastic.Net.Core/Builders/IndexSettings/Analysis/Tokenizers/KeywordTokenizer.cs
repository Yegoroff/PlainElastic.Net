using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A tokenizer of type keyword that emits the entire input as a single input.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/keyword-tokenizer.html
    /// </summary>
    public class KeywordTokenizer : NamedComponentBase<KeywordTokenizer>
    {

        /// <summary>
        /// Sets the term buffer size.
        /// Defaults to 256.
        /// </summary>
        public KeywordTokenizer BufferSize(int bufferSize = 256)
        {
            RegisterJsonPart("'buffer_size': {0}", bufferSize.AsString());
            return this;
        }


        protected override string GetComponentType()
        {
            return DefaultTokenizers.keyword.AsString();
        }
    }
}