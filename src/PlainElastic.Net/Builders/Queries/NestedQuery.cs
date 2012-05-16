using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A query that allows to query nested objects / docs.
    /// The query is executed against the nested objects / docs as if they were indexed 
    /// as separate docs (they are, internally) and resulting in the root parent doc (or parent nested mapping)
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/nested-query.html
    /// </summary>   
    public class NestedQuery<T> : NestedBase<NestedQuery<T>, T>
    {

        /// <summary>
        /// Allows to set how inner children matching affects scoring of parent.
        /// </summary>
        public NestedQuery<T> ScoreMode(ScoreMode scoreMode = Net.Queries.ScoreMode.avg)
        {
            RegisterJsonPart("'score_mode': {0}", scoreMode.AsString().Quotate());

            return this;
        }

        /// <summary>
        /// Allows to define scope associated with query.
        /// </summary>
        public NestedQuery<T> Scope(string scope)
        {
            RegisterJsonPart("'_scope': {0}", scope.Quotate());

            return this;
        }
    }
}