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

        public BoolQuery<T> Must(Func<MustQuery<T>, Query<T>> mustQuery)
        {
            var result = RegisterJsonPartExpression(mustQuery);
            hasRequiredParts = hasRequiredParts || !result.GetIsEmpty();
            return this;
        }

        public BoolQuery<T> MustNot(Func<MustNotQuery<T>, Query<T>> mustNotQuery)
        {
            var result = RegisterJsonPartExpression(mustNotQuery);
            hasRequiredParts = hasRequiredParts || !result.GetIsEmpty();
            return this;
        }

        public BoolQuery<T> Should(Func<ShouldQuery<T>, Query<T>> shouldQuery)
        {
            var shouldResult = RegisterJsonPartExpression(shouldQuery);
            hasRequiredParts = hasRequiredParts || !shouldResult.GetIsEmpty();

            shouldPartsCount = shouldResult.JsonParts.Count();

            return this;
        }

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

        public BoolQuery<T> Boost(double boost)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());

            return this;
        }

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