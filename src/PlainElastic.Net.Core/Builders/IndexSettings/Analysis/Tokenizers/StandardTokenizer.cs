using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A tokenizer of type standard providing grammar based tokenizer that is a good tokenizer for most European language documents.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/standard-tokenizer.html
    /// </summary>
    public class StandardTokenizer : NamedComponentBase<StandardTokenizer>
    {

        /// <summary>
        /// Sets the maximum token length. If a token is seen that exceeds this length then it is discarded.
        /// Defaults to 255.
        /// </summary>
        public StandardTokenizer MaxTokenLength(int maxTokenLength = 255)
        {
            RegisterJsonPart("'max_token_length': {0}", maxTokenLength.AsString());
            return this;
        }


        protected override string GetComponentType()
        {
            return DefaultTokenizers.standard.AsString();
        }
    }
}