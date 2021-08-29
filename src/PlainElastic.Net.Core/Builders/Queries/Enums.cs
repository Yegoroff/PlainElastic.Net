using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{

    public enum ScoreMode { avg, total, max, none }

    public enum FunctionScoreMode { first, min, max, sum, avg, multiply }

    public enum CustomFiltersScoreMode { first, min, max, total, avg, multiply }

    public enum FunctionBoostMode { multiply, replace, sum, avg, min, max }

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

    public static class RewriteExtensions
    {
        public static string GetRewriteValue(this Rewrite rewrite, int n)
        {
            switch (rewrite)
            {
                case Rewrite.top_terms_boost_n:
                    return "top_terms_boost_" + n;

                case Rewrite.top_terms_n:
                    return "top_terms_" + n;
            }
            return rewrite.AsString();
        }
    }


    public enum TermsFilterExecution { plain, @bool, @and }

    public enum TermsFacetOrder { count, term, reverse_count, reverse_term }

    public enum TermsStatsFacetOrder { count, term, reverse_count, reverse_term, total, reverse_total, min, reverse_min, max, reverse_max, mean, reverse_mean }

    public enum ScriptLangs { mvel, js, groovy, python, native }

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
        /// Calculates distance as points in a globe.
        /// Use arc for better precision.
        /// </summary>
        arc,

        /// <summary>
        /// Calculates distance as points in a globe.
        /// Use sloppy_arc for faster calculation.
        /// </summary>
        sloppy_arc,

        /// <summary>
        /// Calculates distance as points on a plane. Faster, but less accurate than arc
        /// Use plane for performance.
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
        @in,
        inch,
        yd,
        yards,
        km,
        kilometers,
        mm,
        millimeters,
        cm,
        centimeters,
        m,
        meters
    }

    public enum ZeroTermsQuery { NONE, ALL }


    public enum HighlightTagsSchema { styled, @default }

    public enum HighlightOrder { score, @default }

    public enum HighlightEncoder { html, @default }

    public enum HighlighterType { plain, fvh }

    public enum HighlightFragmenter { simple, span }

    public enum HasParentScoreType { none, score }

    public enum HasChildScoreType { max, sum, avg, score }

    public enum DecayFunctionType { linear, exp, gauss }

    public enum OrderDirection { asc, desc }

    public enum CollectMode { depth_first, breadth_first }

    public enum TermsValueType { @string, @float, @integer, @long, @short, @byte }


}