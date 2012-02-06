using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.QueryBuilder
{
    public class Query<T> : AbstractCompositeQuery<T>
    {
        private const string queryTemplate = " \"query\": {0} ";


        protected override string QueryTemplate
        {
            get { return queryTemplate; }
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

        public Query<T> Custom(string queryFormat, Expression<Func<T, object>> field, params string[] args)
        {
            var formatArgs = new List<string>(args);
            formatArgs.Insert(0, field.GetPropertyName());

            return Custom(queryFormat, formatArgs.ToArray());
        }


        public Query<T> Custom(string queryFormat, params string[] args)
        {
            queryFormat = queryFormat.Replace('\'', '\"');

            var query = queryFormat.F(args);
            Queries.Add(query);
            return this;
        }



    }
}