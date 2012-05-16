using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// An analyzer of type whitespace that is built using a Whitespace Tokenizer.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/whitespace-analyzer.html
    /// </summary>
    public class WhitespaceAnalyzer : AnalyzerBase<WhitespaceAnalyzer>
    {
        protected override string GetComponentType()
        {
            return DefaultAnalyzers.whitespace.AsString();
        }
    }
}