using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A tokenizer of type whitespace that divides text at whitespace.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/whitespace-tokenizer.html
    /// </summary>
    public class WhitespaceTokenizer : NamedComponentBase<WhitespaceTokenizer>
    {
        protected override string GetComponentType()
        {
            return DefaultTokenizers.whitespace.AsString();
        }
    }
}