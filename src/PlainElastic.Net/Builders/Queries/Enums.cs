namespace PlainElastic.Net.Queries
{

    public enum ScoreMode { avg, total, max, none }

    public enum Rewrite { constant_score_default, scoring_boolean, constant_score_boolean, constant_score_filter, top_terms_boost_n, top_terms_n }

    public enum TermsFilterExecution { plain, @bool, @and}
}