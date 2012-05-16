using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// An analyzer of type simple that is built using a Lower Case Tokenizer.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/simple-analyzer.html
    /// </summary>
    public class SimpleAnalyzer : AnalyzerBase<SimpleAnalyzer>
    {
        protected override string GetComponentType()
        {
            return DefaultAnalyzers.simple.AsString();
        }
    }
}