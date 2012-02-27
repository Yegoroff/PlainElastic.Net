using System;
using System.Linq;


namespace PlainElastic.Net.Queries
{

    /// <summary>
    /// A query that matches documents matching boolean combinations of other queries. 
    /// The bool query maps to Lucene BooleanQuery. It is built using one or more boolean clauses, 
    /// each clause with a typed occurrence
    /// see: http://www.elasticsearch.org/guide/reference/query-dsl/bool-query.html
    /// </summary>    
    public class BoolQuery<T> : CompositeQueryBase
    {
        private int shouldPartsCount;


        protected override string QueryTemplate
        {
            get { return "{{ 'bool': {{ {0} }} }}"; }
        }


        public BoolQuery<T> Must(Func<MustQuery<T>, Query<T>> mustQuery)
        {
            RegisterQueryExpression(mustQuery);

            return this;
        }

        public BoolQuery<T> MustNot(Func<MustNotQuery<T>, Query<T>> mustQuery)
        {
            RegisterQueryExpression(mustQuery);

            return this;
        }

        public BoolQuery<T> Should(Func<ShouldQuery<T>, Query<T>> shouldQuery)
        {
            var shouldResult = RegisterQueryExpression(shouldQuery);

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

                var param = " 'minimum_number_should_match': {0}".SmartQuoteF(number.AsString());
                base.RegisterJsonParam(param);
            }

            return this;
        }

        public BoolQuery<T> Boost(double boost)
        {
            var boostParam = " 'boost': {0}".SmartQuoteF(boost.AsString());
            base.RegisterJsonParam(boostParam);

            return this;
        }

        public BoolQuery<T> DisableCoord(bool disableCoord)
        {
            var disableCoordParam = " 'disable_coord': {0}".SmartQuoteF(disableCoord.AsString());
            base.RegisterJsonParam(disableCoordParam);

            return this;
        }


        public BoolQuery<T> Custom(string queryFormat, params string[] args)
        {
            var query = queryFormat.SmartQuoteF(args);
            RegisterJsonQuery(query);
            return this;
        }

    }
}