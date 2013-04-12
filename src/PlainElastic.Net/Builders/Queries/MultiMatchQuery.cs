using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// The multi_match query builds further on top of the match query by allowing multiple fields to be specified.
    /// The idea here is to allow to more easily build a concise match type query 
    /// over multiple fields instead of using a relatively more expressive query
    /// by using multiple match queries within a bool query.
    /// http://www.elasticsearch.org/guide/reference/query-dsl/multi-match-query/
    /// </summary>
    public class MultiMatchQuery<T> : MatchQueryBase<T, MultiMatchQuery<T>>
    {

        private readonly List<string> queryFields = new List<string>();


        /// <summary>
        /// A list of the fields to run the query against.
        /// Defaults to the _all field.
        /// </summary>
        public MultiMatchQuery<T> Fields(params string[] fields)
        {
            queryFields.AddRange(fields);
            return this;
        }

        /// <summary>
        /// A list of the fields to run the query against.
        /// Defaults to the _all field.
        /// </summary>
        public MultiMatchQuery<T> Fields(params Expression<Func<T, object>>[] fields)
        {
            foreach (var field in fields)
                queryFields.Add(field.GetPropertyPath());

            return this;
        }

        /// <summary>
        /// A list of the fields to run the query against.
        /// </summary>
        public MultiMatchQuery<T> FieldsOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, params Expression<Func<TProp, object>>[] fields)
        {
            var collectionProperty = collectionField.GetPropertyPath();

            foreach (var field in fields)
            {
                var fieldName = collectionProperty + "." + field.GetPropertyPath();
                queryFields.Add(fieldName);
            }
            return this;
        }


        /// <summary>
        /// Should the queries be combined using dis_max (set it to true), or a bool query (set it to false).
        /// Defaults to true.
        /// </summary>
        public MultiMatchQuery<T> UseDisMax(bool useDisMax)
        {
            RegisterJsonPart("'use_dis_max': {0}", useDisMax.AsString());
            return this;
        }

        /// <summary>
        /// Multiplier value to balance the scores between lower and higher scoring fields.
        /// Only applicable when use_dis_max is set to true.
        /// Defaults to 0.
        /// </summary>
        public MultiMatchQuery<T> TieBreaker(double tieBreaker = 0)
        {
            RegisterJsonPart("'tie_breaker': {0}", tieBreaker.AsString());
            return this;
        }

            


        protected override string ApplyJsonTemplate(string body)
        {
            if (!RegisteredField.IsNullOrEmpty())
                queryFields.Add(RawFieldName);

            if (queryFields.Count > 0)
            {
                string fields = JsonHelper.BuildJsonStringsProperty("fields", queryFields);
                body = new[] { fields, body }.JoinWithComma();
            }

            return "{{ 'multi_match': {{ {0} }} }}".AltQuoteF(body);
        }
        
    }
}