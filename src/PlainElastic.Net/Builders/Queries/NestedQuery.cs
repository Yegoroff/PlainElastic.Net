using System;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A query that allows to query nested objects / docs.
    /// The query is executed against the nested objects / docs as if they were indexed 
    /// as separate docs (they are, internally) and resulting in the root parent doc (or parent nested mapping)
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/nested-query.html
    /// </summary>   
    public class NestedQuery<T> : CompositeQueryBase
    {

        protected override string QueryTemplate
        {
            get { return "{{ 'nested': {{ {0} }} }}"; }
        }


        public NestedQuery<T> Query(Func<Query<T>, Query<T>> queries)
        {
            RegisterQueryExpression(queries);

            return this;
        }


        /// <summary>
        /// Points to the nested object path, and the query includes 
        /// the query that will run on the nested docs matching the direct path, 
        /// and joining with the root parent docs.
        /// </summary>
        public NestedQuery<T> Path(Expression<Func<T, object>> field)
        {
            var fieldPath = field.GetPropertyPath();
            return Path(fieldPath);
        }

        /// <summary>
        /// Points to the nested object path, and the query includes 
        /// the query that will run on the nested docs matching the direct path, 
        /// and joining with the root parent docs.
        /// </summary>
        public NestedQuery<T> Path(string path)
        {
            var param = " 'path': {0}".SmartQuoteF(path.Quotate());
            RegisterJsonParam(param);

            return this;
        }


        /// <summary>
        /// Allows to set how inner children matching affects scoring of parent.
        /// </summary>
        public NestedQuery<T> ScoreMode(ScoreMode scoreMode = Net.Queries.ScoreMode.avg)
        {
            var scoreParam = " 'score_mode': {0}".SmartQuoteF(scoreMode.ToString().Quotate());
            RegisterJsonParam(scoreParam);

            return this;
        }


        //TODO: Move to common part.

        /// <summary>
        /// Adds a custom query.
        /// You can use ' instead of " to simplify queryFormat creation.
        /// </summary>
        public NestedQuery<T> Custom(string queryFormat, params string[] args)
        {
            var query = queryFormat.SmartQuoteF(args);
            RegisterJsonQuery(query);
            return this;
        }

    }
}