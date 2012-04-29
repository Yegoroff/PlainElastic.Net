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
    public enum DefaultAnalizers
    {
        standard,
        simple,
        whitespace,
        stop,
        keyword,
        pattern,
        language,
        snowball
    }

    /// <summary>
    /// Used to define which analyzers will be used by default when none can be derived.
    /// </summary>
    public enum AnalyzersDefaultAliases
    {
        /// <summary>
        /// Allows one to configure an analyzer that will be used both for indexing and for searching APIs.
        /// </summary>
        @default,

        /// <summary>
        /// Can be used to configure a default analyzer that will be used just when indexing.
        /// </summary>
        default_index,

        /// <summary>
        /// Can be used to configure a default analyzer that will be used just when searching.
        /// </summary>
        default_search
    }
}