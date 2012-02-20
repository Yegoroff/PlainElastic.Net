using System;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    public abstract class NestedBase<TQuery, T> : CompositeQueryBase where TQuery : NestedBase<TQuery, T>
    {

        protected override string QueryTemplate
        {
            get { return "{{ 'nested': {{ {0} }} }}"; }
        }


        /// <summary>
        /// The query element within the search request body allows to define a query using the Query DSL.
        /// see http://www.elasticsearch.org/guide/reference/api/search/query.html
        /// </summary>
        public TQuery Query(Func<Query<T>, Query<T>> queries)
        {
            RegisterQueryExpression(queries);

            return (TQuery)this;
        }


        /// <summary>
        /// Points to the nested object path, and the query includes 
        /// the query that will run on the nested docs matching the direct path, 
        /// and joining with the root parent docs.
        /// </summary>
        public TQuery Path(Expression<Func<T, object>> field)
        {
            var fieldPath = field.GetPropertyPath();
            return Path(fieldPath);
        }

        /// <summary>
        /// Points to the nested object path, and the query includes 
        /// the query that will run on the nested docs matching the direct path, 
        /// and joining with the root parent docs.
        /// </summary>
        public TQuery Path(string path)
        {
            var param = " 'path': {0}".SmartQuoteF(path.Quotate());
            RegisterJsonParam(param);

            return (TQuery)this;
        }

        //TODO: Move to common part.

        /// <summary>
        /// Adds a custom query.
        /// You can use ' instead of " to simplify queryFormat creation.
        /// </summary>
        public TQuery Custom(string queryFormat, params string[] args)
        {
            var query = queryFormat.SmartQuoteF(args);
            RegisterJsonQuery(query);
            return (TQuery)this;
        }

    }
}