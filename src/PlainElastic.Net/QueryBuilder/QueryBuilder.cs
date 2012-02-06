using System;


namespace PlainElastic.Net.QueryBuilder
{
    public class QueryBuilder<T> : AbstractCompositeQuery<T>
    {
        #region Query Templates

        private const string mainQueryTemplate ="{{ {0} }}";
        private const string fromTemplate = "  \"from\": {0}";
        private const string sizeTemplate = "  \"size\": {0}";
        private const string sortTemplate = "  \"sort\": [{0}]";

        #endregion


        protected override string QueryTemplate
        {
            get { return mainQueryTemplate; }
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
            var fromQuery = fromTemplate.F(from);
            Queries.Add(fromQuery);

            return this;
        }

        public QueryBuilder<T> Size(int size)
        {
            var sizeQuery = sizeTemplate.F(size);
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
    }
}