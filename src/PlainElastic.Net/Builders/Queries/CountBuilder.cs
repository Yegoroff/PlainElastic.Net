using System;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    public class CountBuilder<T> : QueryBase<CountBuilder<T>>
    {
        /// <summary>
        /// The query element within the search request body allows to define a query using the Query DSL. 
        /// QueryDsl does return content of expression without wrapping it into 'query' element. This is
        /// necessary for some commands e.g. Count.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/
        /// </summary>
        public CountBuilder<T> Query(Func<QueryDsl<T>, Query<T>> query)
        {
            RegisterJsonPartExpression(query);
            return this;
        }

        /// <summary>
        /// Builds JSON query.
        /// </summary>
        public string Build()
        {
            return (this as IJsonConvertible).ToJson();
        }


        /// <summary>
        /// Builds beatified JSON query.
        /// </summary>
        public string BuildBeautified()
        {
            return Build().BeautifyJson();
        }


        /// <summary>
        /// Returns a <see cref="System.String"/> that represents beautified JSON query.
        /// </summary>
        public override string ToString()
        {
            return BuildBeautified();
        }

        protected override bool HasRequiredParts()
        {
            return true;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "{0}".AltQuoteF(body);
        }
    }
}