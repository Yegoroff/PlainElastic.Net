using System;
using System.Collections.Generic;
using System.Linq;
using PlainElastic.Net.Builders;

namespace PlainElastic.Net.Queries
{
    public abstract class AbstractCompositeQuery<T> : IJsonConvertible
    {

        protected abstract string QueryTemplate { get; }


        protected AbstractCompositeQuery()
        {
            Queries = new List<string>();
        }


        public List<string> Queries { get; private set; }



        protected TResultQuery RegisterQueryAsJson<TQuery, TResultQuery>(Func<TQuery, TResultQuery> query)
            where TQuery : new()
            where TResultQuery : IJsonConvertible
        {
            var instance = new TQuery();
            var resultQuery = query.Invoke(instance);
           
            var jsonQuery = resultQuery.ToJson();

            if (!jsonQuery.IsNullOrEmpty())
                Queries.Add(jsonQuery);

            return resultQuery;
        }


        string IJsonConvertible.ToJson()
        {
            // Return empty string if no queries registered to eliminate empty query body in final JSON.
            if (!Queries.Any())
                return "";

            var body = Queries.JoinWithSeparator(", ");
            return QueryTemplate.SmartQuoteF(body);
        }

    }
}