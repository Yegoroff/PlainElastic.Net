using System;
using PlainElastic.Net.Builders;


namespace PlainElastic.Net.Queries
{
    public class QueryBuilder<T> : AbstractCompositeQuery<T>
    {

        protected override string QueryTemplate
        {
            get { return "{{ {0} }}"; }
        }


        public QueryBuilder<T> Query(Func<Query<T>, Query<T>> query)
        {
            RegisterQueryAsJson(query);
            return this;
        }

        public QueryBuilder<T> Filter(Func<Filter<T>, Filter<T>> filter)
        {
            RegisterQueryAsJson(filter);
            return this;
        }

        public QueryBuilder<T> From (int from)
        {
            var fromQuery = " 'from': {0}".SmartQuoteF(from);
            Queries.Add(fromQuery);

            return this;
        }

        public QueryBuilder<T> Size(int size)
        {
            var sizeQuery = " 'size': {0}".SmartQuoteF(size);
            Queries.Add(sizeQuery);

            return this;
        }

        public QueryBuilder<T> Sort(Func<Sort<T>, Sort<T>> sort)
        {
            RegisterQueryAsJson(sort);
            return this;
        }

        // track_scores : true


        public string Build()
        {
            return (this as IJsonConvertible).ToJson();
        }

        public string BuildBeautified()
        {
            return Build().ButifyJson();
        }


        public override string ToString()
        {
            return BuildBeautified();
        }
    }
}