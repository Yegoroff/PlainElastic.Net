namespace PlainElastic.Net
{
    public enum Operator
    {
        /// <summary>
        /// When OR operator used, the query 'capital of Hungary' is translated to 'capital OR of OR Hungary'
        /// </summary>
        OR,

        /// <summary>
        /// When AND operator used, the query 'capital of Hungary' is translated to 'capital AND of AND Hungary'
        /// </summary>
        AND
    }

    /// <summary>
    /// Analyzers that can be used in order to both break indexed (analyzed) fields when a document is indexed and process query strings.
    /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
    /// </summary>
    public enum DefaultAnalyzers
    {
        standard,
        simple,
        whitespace,
        stop,
        keyword,
        pattern,
        snowball
    }
}