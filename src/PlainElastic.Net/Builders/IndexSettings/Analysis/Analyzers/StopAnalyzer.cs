using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// An analyzer of type stop that is built using a Lower Case Tokenizer, with Stop Token Filter.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/stop-analyzer.html
    /// </summary>
    public class StopAnalyzer : StopwordsAnalyzerBase<StopAnalyzer>
    {
        protected override string GetComponentType()
        {
            return DefaultAnalyzers.stop.AsString();
        }
    }
}