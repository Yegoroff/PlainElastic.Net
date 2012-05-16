using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A tokenizer of type edgeNGram that builds N-characters substrings from text. Substrings are built from one side of a text.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/edgengram-tokenizer.html
    /// </summary>
    public class EdgeNGramTokenizer : EdgeNGramComponentBase<EdgeNGramTokenizer>
    {
        protected override string GetComponentType()
        {
            return DefaultTokenizers.edgeNGram.AsString();
        }
    }
}