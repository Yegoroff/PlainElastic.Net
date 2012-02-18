using System;


namespace PlainElastic.Net.Queries
{
    public class BoolQuery<T> : AbstractCompositeQuery<T>
    {
        private int shouldPartsCount;


        protected override string QueryTemplate
        {
            get { return "{{ 'bool': {{ {0} }} }}"; }
        }


        public BoolQuery<T> Must(Func<MustQuery<T>, Query<T>> mustQuery)
        {
            RegisterQueryAsJson(mustQuery);

            return this;
        }

        public BoolQuery<T> MustNot(Func<MustNotQuery<T>, Query<T>> mustQuery)
        {
            RegisterQueryAsJson(mustQuery);

            return this;
        }

        public BoolQuery<T> Should(Func<ShouldQuery<T>, Query<T>> shouldQuery)
        {
            var shouldResult = RegisterQueryAsJson(shouldQuery);

            shouldPartsCount = shouldResult.Queries.Count;

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

                var query = " 'minimum_number_should_match': {0}".SmartQuoteF(number.AsString());
                Queries.Add(query);
            }

            return this;
        }

        public BoolQuery<T> Boost(double boost)
        {
            var boostQuery = " 'boost': {0}".SmartQuoteF(boost.AsString());
            Queries.Add(boostQuery);

            return this;
        }

        public BoolQuery<T> DisableCoord(bool disableCoord)
        {
            var disableCoordQuery = " 'disable_coord': {0}".SmartQuoteF(disableCoord.AsString());
            Queries.Add(disableCoordQuery);

            return this;
        }

    }
}