using System;
using System.Collections.Generic;
using PlainElastic.Net.Builders;

namespace PlainElastic.Net.Queries
{
    public abstract class CompositeQueryBase: IJsonConvertible
    {

        protected abstract string QueryTemplate { get; }


        private int paramsCount;

        protected CompositeQueryBase()
        {
            QueryParts = new List<string>();
        }

        
        public List<string> QueryParts { get; private set; }


        protected void RegisterJsonParam(string param)
        {
            if (param.IsNullOrEmpty())
                return;

            QueryParts.Add(param);
            paramsCount++;

        }

        protected TResultParam RegisterParamExpression<TParam, TResultParam>(Func<TParam, TResultParam> param)
            where TParam : new()
            where TResultParam : IJsonConvertible
        {
            var instance = new TParam();
            var resultParam = param.Invoke(instance);

            var jsonParam = resultParam.ToJson();

            RegisterJsonParam(jsonParam);

            return resultParam;
        }


        protected void RegisterJsonQuery(string jsonQuery)
        {
            if (!jsonQuery.IsNullOrEmpty())
                QueryParts.Add(jsonQuery);
        }

        protected TResultQuery RegisterQueryExpression<TQuery, TResultQuery>(Func<TQuery, TResultQuery> query)
            where TQuery : new()
            where TResultQuery : IJsonConvertible
        {
            var instance = new TQuery();
            var resultQuery = query.Invoke(instance);
           
            var jsonQuery = resultQuery.ToJson();

            RegisterJsonQuery(jsonQuery);

            return resultQuery;
        }


        string IJsonConvertible.ToJson()
        {
            // Return empty string if no inner Queries registered (e.g. empty or only params) to eliminate empty query body in final JSON.
            if (QueryParts.Count == 0 || QueryParts.Count == paramsCount)
                return "";

            var body =  QueryParts.JoinWithComma();

            return QueryTemplate.SmartQuoteF(body);
        }

    }
}