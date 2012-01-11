using System;
using System.Collections.Generic;
using System.Linq;

namespace PlainElastic.Net.QueryBuilder
{
    public abstract class AbstractQuery<T> : IJsonConvertible
    {

        public abstract string QueryTemplate { get; }


        protected AbstractQuery()
        {
            Queries = new List<string>();
        }


        public List<string> Queries { get; private set; }


        protected TQuery2 ExecuteAndRegisterQuery<TQuery, TQuery2>(Func<TQuery, TQuery2> query)
            where TQuery : new()
            where TQuery2: IJsonConvertible
        {
            var instance = new TQuery();
            var returnQuery = query.Invoke(instance);

            IJsonConvertible resultQuery = returnQuery;
            var jsonQuery = resultQuery.ToJson();

            if (!jsonQuery.IsNullOrEmpty())
                Queries.Add(jsonQuery);

            return returnQuery;
        }


        string IJsonConvertible.ToJson()
        {
            // Return empty string if no queries registered to eliminate empty query body in final JSON.
            if (!Queries.Any())
                return "";

            var body = Queries.JoinWithSeparator(",\r\n");
            return QueryTemplate.F(body);
        }
    }
}