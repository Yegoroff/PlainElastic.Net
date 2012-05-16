using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A tokenizer of type uax_url_email which works exactly like the standard tokenizer, but tokenizes emails and urls as single tokens.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/uaxurlemail-tokenizer.html
    /// </summary>
    public class UaxUrlEmailTokenizer : StandardTokenizer
    {
        protected override string GetComponentType()
        {
            return DefaultTokenizers.uax_url_email.AsString();
        }
    }
}