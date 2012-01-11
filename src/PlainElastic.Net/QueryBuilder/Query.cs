using System;

namespace PlainElastic.Net.QueryBuilder
{
    public class Query<T> : AbstractQuery<T>
    {

        #region Query Templates

        private const string queryTemplate = @"
    ""query"": {{
{0}
    }}";

        #endregion


        public override string QueryTemplate
        {
            get { return queryTemplate; }
        }


        public Query<T> Bool(Func<BoolQuery<T>, BoolQuery<T>> boolQuery)
        {
            ExecuteAndRegisterQuery(boolQuery);
            return this;
        }

        public Query<T> QueryString(Func<QueryString<T>, QueryString<T>> queryString)
        {
            ExecuteAndRegisterQuery(queryString);
            return this;
        }

        public Query<T> Term(Func<Term<T>, Term<T>> termQuery)
        {
            ExecuteAndRegisterQuery(termQuery);
            return this;
        }

        public Query<T> Terms(Func<Terms<T>, Terms<T>> termsQuery)
        {
            ExecuteAndRegisterQuery(termsQuery);
            return this;
        }

    }
}