namespace PlainElastic.Net.Queries
{

    public enum ScoreMode { avg, total, max, none }

    public enum CustomFiltersScoreMode { first, min, max, total, avg, multiply }

    public enum TopChildrenScoreMode { max, sum, avg }

    public enum IndicesNoMatchMode
    {
        /// <summary>
        /// Match all documents
        /// </summary>
        all,

        /// <summary>
        /// match no documents
        /// </summary>
        none
    }


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
        /// so it�s almost always better to use constant_score_default. 
        /// This rewrite method will hit too many clauses failure if it exceeds the boolean query limit (defaults to 1024).
        /// </summary>
        scoring_boolean, 

        /// <summary>
        ///  Similar to scoring_boolean except scores are not computed. 
        /// Instead, each matching document receives a constant score equal to the query�s boost. 
        /// This rewrite method will hit too many clauses failure if it exceeds the boolean query limit (defaults to 1024).
        /// </summary>
        constant_score_boolean, 

        /// <summary>
        ///  A rewrite method that first creates a private Filter by visiting each term in sequence and marking all docs for that term.
        ///  Matching documents are assigned a constant score equal to the query�s boost.
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

    public enum ScriptLangs {  mvel, js, groovy, python, native }

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

    /// <summary>
    /// How to compute the distance. Can either be arc (better precision) or plane (faster). Defaults to arc.
    /// </summary>
    public enum DistanceType
    {
        /// <summary>
        /// Use arc for better precision.
        /// </summary>
        arc,

        /// <summary>
        /// Use place for performace.
        /// </summary>
        plane 
    }

    /// <summary>
    /// Will an optimization of using first a bounding box check will be used. Defaults to memory which will do in memory checks.
    /// Can also have value of indexed to use indexed value check (make sure the geo_point type index lat lon in this case), or
    /// none which disables bounding box optimization.
    /// </summary>
    public enum OptimizeBoundingBox
    {
        /// <summary>
        /// Perform in memory check.
        /// </summary>
        memory,

        /// <summary>
        /// Perform index value check.
        /// </summary>
        indexed,

        /// <summary>
        /// Disables bounding box optimization.
        /// </summary>
        none
    }

    public enum DistanceUnit
    {
        mi,
        miles,
        km
    }
}