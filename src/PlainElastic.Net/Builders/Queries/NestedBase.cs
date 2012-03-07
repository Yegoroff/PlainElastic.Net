using System;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    public abstract class NestedBase<TQuery, T> : QueryBase<TQuery> where TQuery : NestedBase<TQuery, T>
    {
        private bool hasRequiredPart;


        /// <summary>
        /// The query element within the search request body allows to define a query using the Query DSL.
        /// see http://www.elasticsearch.org/guide/reference/api/search/query.html
        /// </summary>
        public TQuery Query(Func<Query<T>, Query<T>> queries)
        {
            var result =RegisterJsonPartExpression(queries);
            hasRequiredPart = !result.GetIsEmpty();

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
            RegisterJsonPart("'path': {0}", path.Quotate());

            return (TQuery)this;
        }


        protected override bool HasRequiredParts()
        {
            return hasRequiredPart;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ 'nested': {{ {0} }} }}".AltQuoteF(body);
        }

    }
}