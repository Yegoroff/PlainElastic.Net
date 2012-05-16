using System;

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

    /// <summary>
    /// Pattern analyzer regular expression flags.
    /// see http://docs.oracle.com/javase/6/docs/api/java/util/regex/Pattern.html#field_summary
    /// </summary>
    [Flags]
    public enum PatternFlags
    {
        /// <summary>
        /// Enables canonical equivalence.
        /// </summary>
        CANON_EQ = 1,

        /// <summary>
        /// Enables case-insensitive matching.
        /// </summary>
        CASE_INSENSITIVE = 2,

        /// <summary>
        /// Permits whitespace and comments in pattern.
        /// </summary>
        COMMENTS = 4,

        /// <summary>
        /// Enables dotall mode.
        /// </summary>
        DOTALL = 8,

        /// <summary>
        /// Enables literal parsing of the pattern.
        /// </summary>
        LITERAL = 0x10,

        /// <summary>
        /// Enables multiline mode.
        /// </summary>
        MULTILINE = 0x20,

        /// <summary>
        /// Enables Unicode-aware case folding.
        /// </summary>
        UNICODE_CASE = 0x40,

        /// <summary>
        /// Enables Unix lines mode.
        /// </summary>
        UNIX_LINES = 0x80
    }

    /// <summary>
    /// Supported language analyzer types.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/lang-analyzer.html
    /// </summary>
    public enum LanguageAnalyzerTypes
    {
        arabic,
        armenian,
        basque,
        brazilian,
        bulgarian,
        catalan,
        chinese,
        cjk,
        czech,
        danish,
        dutch,
        english,
        finnish,
        french,
        galician,
        german,
        greek,
        hindi,
        hungarian,
        indonesian,
        italian,
        norwegian,
        persian,
        portuguese,
        romanian,
        russian,
        spanish,
        swedish,
        turkish,
        thai
    }

    /// <summary>
    /// Languages supported by a Snowball-generated stemmer.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/snowball-tokenfilter.html
    /// </summary>
    public enum SnowballLanguages
    {
        Armenian,
        Basque,
        Catalan,
        Danish,
        Dutch,
        English,
        Finnish,
        French,
        German,
        German2,
        Hungarian,
        Italian,
        Kp,
        Lovins,
        Norwegian,
        Porter,
        Portuguese,
        Romanian,
        Russian,
        Spanish,
        Swedish,
        Turkish
    }

	public enum EdgeNGramSide
	{
		front,
		back
	}
}