using System;

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

    /// <summary>
    /// Pattern analyzer regular expression flags.
    /// see http://docs.oracle.com/javase/6/docs/api/java/util/regex/Pattern.html#field_summary
    /// </summary>
    [Flags]
    public enum RegexFlags
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

    [Flags]
    public enum RegExpSyntaxFlags
    {
        NONE = 0,
        ANYSTRING = 1,
        AUTOMATON = 2,
        COMPLEMENT = 4,
        EMPTY = 8,
        INTERSECTION = 0x10,
        INTERVAL = 0x20,
        ALL = 0x40
    }
}