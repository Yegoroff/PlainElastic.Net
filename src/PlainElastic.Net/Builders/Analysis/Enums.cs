namespace PlainElastic.Net.IndexSettings
{
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

    /// <summary>
    /// Tokenizers act as the first stage of the analysis process.
    /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
    /// </summary>
    public enum DefaultTokenizers
    {
        edgeNGram,
        keyword,
        letter,
        lowercase,
        nGram,
        standard,
        whitespace,
        pattern,
        uax_url_email,
        path_hierarchy
    }

    /// <summary>
    /// Token filters act as additional stages of the analysis process.
    /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
    /// </summary>
    public enum DefaultTokenFilters
    {
        standard,
        asciifolding,
        length,
        lowercase,
        nGram,
        edgeNGram,
        porterStem,
        shingle,
        stop,
        word_delimiter,
        stemmer,
        kstem,
        snowball,
        phonetic,
        synonym,
        dictionary_decompounder,
        hyphenation_decompounder,
        reverse,
        elision,
        truncate,
        unique,
        pattern_replace,
        trim
    }

    /// <summary>
    /// Char filters allow one to filter out the stream of text before it gets tokenized.
    /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
    /// </summary>
    public enum DefaultCharFilters
    {
        mapping,
        html_strip
    }
}