using System;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A query that generates the union of documents produced by its subqueries, 
    /// and that scores each document with the maximum score for that document as produced by any subquery, 
    /// plus a tie breaking increment for any additional matching subqueries.
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/dis-max-query.html
    /// </summary>   
    public class DisMaxQuery<T> : CompositeQueryBase
    {

        protected override string QueryTemplate
        {
            get { return "{{ 'dis_max': {{ {0} }} }}"; }
        }


        public DisMaxQuery<T> Queries(Func<DisMaxQueries<T>, Query<T>> queries)
        {
            RegisterQueryExpression(queries);

            return this;
        }


        /// <summary>
        /// The tie breaker capability allows results that include the same term in multiple 
        /// fields to be judged better than results that include this term in only the best of 
        /// those multiple fields, without confusing this with the better case of two different terms in the multiple fields.
        /// </summary>
        public DisMaxQuery<T> TieBreaker(double tieBreaker)
        {
            var param = " 'tie_breaker': {0}".AltQuoteF(tieBreaker.AsString());
            base.RegisterJsonParam(param);

            return this;
        }

        public DisMaxQuery<T> Boost(double boost)
        {
            var param = " 'boost': {0}".AltQuoteF(boost.AsString());
            base.RegisterJsonParam(param);

            return this;
        }

        /// <summary>
        /// Adds a custom query.
        /// You can use ' instead of " to simplify queryFormat creation.
        /// </summary>
        public DisMaxQuery<T> Custom(string queryFormat, params string[] args)
        {
            var query = queryFormat.AltQuoteF(args);
            RegisterJsonQuery(query);
            return this;
        }


    }
}