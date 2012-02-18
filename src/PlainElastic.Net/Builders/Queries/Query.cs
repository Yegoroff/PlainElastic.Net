using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    public class Query<T> : AbstractCompositeQuery<T>
    {
        protected override string QueryTemplate
        {
            get { return " 'query': {0} "; }
        }


        public Query<T> Bool(Func<BoolQuery<T>, BoolQuery<T>> boolQuery)
        {
            RegisterQueryAsJson(boolQuery);
            return this;
        }

        public Query<T> QueryString(Func<QueryString<T>, QueryString<T>> queryString)
        {
            RegisterQueryAsJson(queryString);
            return this;
        }

        public Query<T> Term(Func<Term<T>, Term<T>> termQuery)
        {
            RegisterQueryAsJson(termQuery);
            return this;
        }

        public Query<T> Terms(Func<Terms<T>, Terms<T>> termsQuery)
        {
            RegisterQueryAsJson(termsQuery);
            return this;
        }


        /// <summary>
        /// Adds a custom mapping to Object Map.
        /// You can use ' instead of " to simplify queryFormat creation.
        /// Name of passed field param will be the first format argument.
        /// </summary>
        public Query<T> Custom(string queryFormat, Expression<Func<T, object>> field, params string[] args)
        {
            var formatArgs = new List<string>(args);
            formatArgs.Insert(0, field.GetPropertyName());

            return Custom(queryFormat, formatArgs.ToArray());
        }

        /// <summary>
        /// Adds a custom mapping to Object Map.
        /// You can use ' instead of " to simplify queryFormat creation.
        /// </summary>
        public Query<T> Custom(string queryFormat, params string[] args)
        {
            var query = queryFormat.SmartQuoteF(args);
            Queries.Add(query);
            return this;
        }



    }
}