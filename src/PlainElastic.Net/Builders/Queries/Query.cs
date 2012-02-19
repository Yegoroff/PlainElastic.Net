using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// The query element within the search request body allows to define a query using the Query DSL.
    /// see http://www.elasticsearch.org/guide/reference/api/search/query.html
    /// </summary>
    public class Query<T> : CompositeQueryBase
    {
        protected override string QueryTemplate
        {
            get { return " 'query': {0} "; }
        }


        /// <summary>
        /// A query that matches documents matching boolean combinations of other queries. 
        /// The bool query maps to Lucene BooleanQuery. It is built using one or more boolean clauses, 
        /// each clause with a typed occurrence
        /// see: http://www.elasticsearch.org/guide/reference/query-dsl/bool-query.html
        /// </summary>  
        public Query<T> Bool(Func<BoolQuery<T>, BoolQuery<T>> boolQuery)
        {
            RegisterQueryExpression(boolQuery);
            return this;
        }

        /// <summary>
        /// A query that generates the union of documents produced by its subqueries, 
        /// and that scores each document with the maximum score for that document as produced by any subquery, 
        /// plus a tie breaking increment for any additional matching subqueries.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/dis-max-query.html
        /// </summary>   
        public Query<T> DisMax(Func<DisMaxQuery<T>, DisMaxQuery<T>> disMaxQuery)
        {
            RegisterQueryExpression(disMaxQuery);
            return this;
        }

        /// <summary>
        /// A query that allows to query nested objects / docs.
        /// The query is executed against the nested objects / docs as if they were indexed 
        /// as separate docs (they are, internally) and resulting in the root parent doc (or parent nested mapping)
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/nested-query.html
        /// </summary>   
        public Query<T> Nested(Func<NestedQuery<T>, NestedQuery<T>> nestedQuery)
        {
            RegisterQueryExpression(nestedQuery);
            return this;
        }

        /// <summary>
        /// A query that uses a query parser in order to parse its content
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/query-string-query.html
        /// </summary>    
        public Query<T> QueryString(Func<QueryString<T>, QueryString<T>> queryString)
        {
            RegisterQueryExpression(queryString);
            return this;
        }

        /// <summary>
        /// Matches documents that have fields that contain a term (not analyzed). The term query maps to Lucene TermQuery
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/term-query.html
        /// </summary>
        public Query<T> Term(Func<Term<T>, Term<T>> termQuery)
        {
            RegisterQueryExpression(termQuery);
            return this;
        }

        /// <summary>
        /// A query that match on any (configurable) of the provided terms.
        /// This is a simpler syntax query for using a bool query with several term queries in the should clauses
        /// see: http://www.elasticsearch.org/guide/reference/query-dsl/terms-query.html
        /// </summary>
        public Query<T> Terms(Func<Terms<T>, Terms<T>> termsQuery)
        {
            RegisterQueryExpression(termsQuery);
            return this;
        }


        /// <summary>
        /// Adds a custom query.
        /// You can use ' instead of " to simplify queryFormat creation.
        /// Name of passed field param will be the first format argument.
        /// </summary>
        public Query<T> Custom(string queryFormat, Expression<Func<T, object>> field, params string[] args)
        {
            var formatArgs = new List<string>(args);
            formatArgs.Insert(0, field.GetPropertyPath());

            return Custom(queryFormat, formatArgs.ToArray());
        }

        /// <summary>
        /// Adds a custom query.
        /// You can use ' instead of " to simplify queryFormat creation.
        /// </summary>
        public Query<T> Custom(string queryFormat, params string[] args)
        {
            var query = queryFormat.SmartQuoteF(args);
            RegisterJsonQuery(query);
            return this;
        }

    }
}