using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// An analyzer of type keyword that “tokenizes” an entire stream as a single token.
    /// This is useful for data like zip codes, ids and so on.
    /// Note, when using mapping definitions, it make more sense to simply mark the field as not_analyzed.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/keyword-analyzer.html
    /// </summary>
    public class KeywordAnalyzer : AnalyzerBase<KeywordAnalyzer>
    {
        protected override string GetComponentType()
        {
            return DefaultAnalyzers.keyword.AsString();
        }
    }
}