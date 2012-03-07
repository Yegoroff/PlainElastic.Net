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
    public class DisMaxQuery<T> : QueryBase<DisMaxQuery<T>>
    {

        public DisMaxQuery<T> Queries(Func<DisMaxQueries<T>, Query<T>> queries)
        {
            RegisterJsonPartExpression(queries);

            return this;
        }


        /// <summary>
        /// The tie breaker capability allows results that include the same term in multiple 
        /// fields to be judged better than results that include this term in only the best of 
        /// those multiple fields, without confusing this with the better case of two different terms in the multiple fields.
        /// </summary>
        public DisMaxQuery<T> TieBreaker(double tieBreaker)
        {
            RegisterJsonPart("'tie_breaker': {0}", tieBreaker.AsString());

            return this;
        }

        public DisMaxQuery<T> Boost(double boost)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());

            return this;
        }


        protected override bool HasRequiredParts()
        {
            return true;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ 'dis_max': {{ {0} }} }}".AltQuoteF(body);
        }
    }
}