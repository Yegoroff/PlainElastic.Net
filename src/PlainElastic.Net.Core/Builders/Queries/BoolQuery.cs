using System;
using System.Linq;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{

    /// <summary>
    /// A query that matches documents matching boolean combinations of other queries. 
    /// The bool query maps to Lucene BooleanQuery. It is built using one or more boolean clauses, 
    /// each clause with a typed occurrence
    /// see: http://www.elasticsearch.org/guide/reference/query-dsl/bool-query.html
    /// </summary>    
    public class BoolQuery<T> : QueryBase<BoolQuery<T>>
    {
        private int shouldPartsCount;
        private bool hasRequiredParts;

        /// <summary>
        /// The clause (query) must appear in matching documents.
        /// </summary>
        public BoolQuery<T> Must(Func<MustQuery<T>, Query<T>> mustQuery)
        {
            var result = RegisterJsonPartExpression(mustQuery);
            hasRequiredParts = hasRequiredParts || !result.GetIsEmpty();
            return this;
        }

        /// <summary>
        /// The clause (query) must not appear in the matching documents.
        /// Note that it is not possible to search on documents that only consists of a must_not clauses.
        /// </summary>
        public BoolQuery<T> MustNot(Func<MustNotQuery<T>, Query<T>> mustNotQuery)
        {
            var result = RegisterJsonPartExpression(mustNotQuery);
            hasRequiredParts = hasRequiredParts || !result.GetIsEmpty();
            return this;
        }

        /// <summary>
        /// The clause (query) should appear in the matching document. 
        /// A boolean query with no must clauses, one or more should clauses must match a document. 
        /// The minimum number of should clauses to match can be set using MinimumNumberShouldMatch parameter.
        /// </summary>
        public BoolQuery<T> Should(Func<ShouldQuery<T>, Query<T>> shouldQuery)
        {
            var shouldResult = RegisterJsonPartExpression(shouldQuery);
            hasRequiredParts = hasRequiredParts || !shouldResult.GetIsEmpty();

            shouldPartsCount = shouldResult.JsonParts.Count();

            return this;
        }


        /// <summary>
        /// The minimum number of should clauses to match.
        /// </summary>
        public BoolQuery<T> MinimumNumberShouldMatch(int number, bool useActualShouldCount = false)
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
        /// Sets the boost value of the query. Defaults to 1.0.
        /// </summary>
        public BoolQuery<T> Boost(double boost = 1)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());

            return this;
        }

        /// <summary>
        /// Disables Coord score factor in scoring.
        /// For example, this score factor does not make sense for most automatically generated queries, like WildcardQuery and FuzzyQuery.
        /// see http://lucene.apache.org/core/old_versioned_docs/versions/3_0_1/api/all/org/apache/lucene/search/Similarity.html#coord(int,+int)
        /// </summary>
        public BoolQuery<T> DisableCoord(bool disableCoord)
        {
            RegisterJsonPart("'disable_coord': {0}", disableCoord.AsString());

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