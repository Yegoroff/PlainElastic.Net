using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A tokenizer of type letter that divides text at non-letters. That's to say, it defines tokens as maximal strings of adjacent letters.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/letter-tokenizer.html
    /// </summary>
    public class LetterTokenizer : NamedComponentBase<LetterTokenizer>
    {
        protected override string GetComponentType()
        {
            return DefaultTokenizers.letter.AsString();
        }
    }
}