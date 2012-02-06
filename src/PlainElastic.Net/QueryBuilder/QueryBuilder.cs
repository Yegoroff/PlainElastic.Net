using System;


namespace PlainElastic.Net.QueryBuilder
{
    public class QueryBuilder<T> : AbstractQuery<T>
    {
        #region Query Templates

        private const string mainQueryTemplate =@"{{ {0} }}";
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
            ExecuteAndRegisterQuery(query);
            return this;
        }

        public QueryBuilder<T> Filter(Func<Filter<T>, Filter<T>> filter)
        {
            ExecuteAndRegisterQuery(filter);
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

        public QueryBuilder<T> Sort(string sortField)
        {
            if (sortField.IsNullOrEmpty())
                return this;

            sortField = sortField.Quotate();
            var sortQuery = sortTemplate.F(sortField);
            Queries.Add(sortQuery);

            return this;
        }


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