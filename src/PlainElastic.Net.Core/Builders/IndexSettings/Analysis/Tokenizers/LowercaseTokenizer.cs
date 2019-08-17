using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A tokenizer of type lowercase that performs the function of Letter Tokenizer and Lower Case Token Filter together.
    /// It divides text at non-letters and converts them to lower case.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/lowercase-tokenizer.html
    /// </summary>
    public class LowercaseTokenizer : NamedComponentBase<LowercaseTokenizer>
    {
        protected override string GetComponentType()
        {
            return DefaultTokenizers.lowercase.AsString();
        }
    }
}