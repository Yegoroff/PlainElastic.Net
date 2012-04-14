namespace PlainElastic.Net.Queries
{

    public enum ScoreMode { avg, total, max, none }

    public enum Rewrite
    {
        /// <summary>
        /// Defaults to automatically choosing either constant_score_boolean or constant_score_filter based on query characteristics.
        /// </summary>
        constant_score_default, 

        /// <summary>
        /// A rewrite method that first translates each term into a should clause in a boolean query, 
        /// and keeps the scores as computed by the query. 
        /// Note that typically such scores are meaningless to the user, and require non-trivial CPU to compute, 
        /// so it’s almost always better to use constant_score_default. 
        /// This rewrite method will hit too many clauses failure if it exceeds the boolean query limit (defaults to 1024).
        /// </summary>
        scoring_boolean, 

        /// <summary>
        ///  Similar to scoring_boolean except scores are not computed. 
        /// Instead, each matching document receives a constant score equal to the query’s boost. 
        /// This rewrite method will hit too many clauses failure if it exceeds the boolean query limit (defaults to 1024).
        /// </summary>
        constant_score_boolean, 

        /// <summary>
        ///  A rewrite method that first creates a private Filter by visiting each term in sequence and marking all docs for that term.
        ///  Matching documents are assigned a constant score equal to the query’s boost.
        /// </summary>
        constant_score_filter, 

        /// <summary>
        /// A rewrite method that first translates each term into should clause in boolean query, and keeps the scores as computed by the query.
        /// This rewrite method only uses the top scoring terms so it will not overflow boolean max clause count.
        /// The N controls the size of the top scoring terms to use.
        /// </summary>
        top_terms_boost_n, 

        /// <summary>
        /// A rewrite method that first translates each term into should clause in boolean query, but the scores are only computed as the boost.
        /// This rewrite method only uses the top scoring terms so it will not overflow the boolean max clause count.
        /// The N controls the size of the top scoring terms to use.
        /// </summary>
        top_terms_n
    }

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

    public enum TextQueryType
    {
        /// <summary>
        /// The text provided is analyzed and the analysis process constructs a boolean query from the provided text.
        /// </summary>
        boolean,

        /// <summary>
        /// Analyzes the text and creates a phrase query out of the analyzed text.
        /// </summary>
        phrase,

        /// <summary>
        /// Analyzes the text and creates a phrase query out of the analyzed text. Allows for prefix matches on the last term in the text.
        /// </summary>
        phrase_prefix
    }
}