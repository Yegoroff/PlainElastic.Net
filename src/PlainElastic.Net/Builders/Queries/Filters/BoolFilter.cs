using System;
using System.Linq;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A filter that matches documents matching boolean combinations of other queries.
    /// Similar in concept to Boolean query, except that the clauses are other filters. 
    /// Can be placed within queries that accept a filter.
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/bool-filter.html
    /// </summary>
    public class BoolFilter<T> : QueryBase<BoolFilter<T>>
    {
        private int shouldPartsCount;
        private bool hasRequiredParts;

        /// <summary>
        /// The clause must appear in matching documents.
        /// </summary>
        public BoolFilter<T> Must(Func<MustFilter<T>, Filter<T>> mustFilter)
        {
            var result = RegisterJsonPartExpression(mustFilter);
            hasRequiredParts = hasRequiredParts || !result.GetIsEmpty();
            return this;
        }

        /// <summary>
        /// The clause must not appear in the matching documents.
        /// </summary>
        public BoolFilter<T> MustNot(Func<MustNotFilter<T>, Filter<T>> mustNotFilter)
        {
            var result = RegisterJsonPartExpression(mustNotFilter);
            hasRequiredParts = hasRequiredParts || !result.GetIsEmpty();
            return this;
        }

        /// <summary>
        /// The clause should appear in the matching document. 
        /// A boolean filter with no must clauses, one or more should clauses must match a document. 
        /// The minimum number of should clauses to match can be set using MinimumNumberShouldMatch parameter.
        /// </summary>
        public BoolFilter<T> Should(Func<ShouldFilter<T>, Filter<T>> shouldFilter)
        {
            var shouldResult = RegisterJsonPartExpression(shouldFilter);
            hasRequiredParts = hasRequiredParts || !shouldResult.GetIsEmpty();

            shouldPartsCount = shouldResult.JsonParts.Count();

            return this;
        }


        /// <summary>
        /// The minimum number of should clauses to match.
        /// </summary>
        public BoolFilter<T> MinimumNumberShouldMatch(int number, bool useActualShouldCount = false)
        {
            // This settings has no sense without Should clause.
            if (shouldPartsCount > 0)
            {
                // Limit to the actual Should clause parts count.
                if (useActualShouldCount && number > shouldPartsCount)
                    number = shouldPartsCount;

                RegisterJsonPart("'minimum_number_should_match': {0}", number.AsString());
            }

            return this;
        }

        /// <summary>
        /// Controls whether the filter will be cached.
        /// </summary>
        public BoolFilter<T> Cache(bool cache)
        {
            RegisterJsonPart("'_cache': {0}", cache.AsString());
            return this;
        }


        protected override bool HasRequiredParts()
        {
            return hasRequiredParts;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ 'bool': {{ {0} }} }}".AltQuoteF(body);
        }

    }
}