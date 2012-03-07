namespace PlainElastic.Net.Queries
{

    public enum ScoreMode { avg, total, max, none }

    public enum Rewrite { constant_score_default, scoring_boolean, constant_score_boolean, constant_score_filter, top_terms_boost_n, top_terms_n }

    public enum TermsFilterExecution { plain, @bool, @and }

    public enum TermsFacetOrder { count, term, reverse_count, reverse_term }

    public enum RegexFlags
    {
        /// <summary>
        /// Enables canonical equivalence.
        /// </summary>
        CANON_EQ,

        /// <summary>
        /// Enables case-insensitive matching.
        /// </summary>
        CASE_INSENSITIVE,

        /// <summary>
        /// Permits whitespace and comments in pattern.
        /// </summary>
        COMMENTS,

        /// <summary>
        /// Enables dotall mode.
        /// </summary>       
        DOTALL,

        /// <summary>
        ///Enables literal parsing of the pattern.        
        /// </summary>
        LITERAL,

        /// <summary>
        /// Enables multiline mode.
        /// </summary>
        MULTILINE,

        /// <summary>
        /// Enables Unicode-aware case folding.
        /// </summary> 
        UNICODE_CASE,

        /// <summary>
        /// Enables Unix lines mode.
        /// </summary>
        UNIX_LINES
    }
}