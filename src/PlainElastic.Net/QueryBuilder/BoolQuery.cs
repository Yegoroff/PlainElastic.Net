using System;


namespace PlainElastic.Net.QueryBuilder
{
    public class BoolQuery<T> : AbstractQuery<T>
    {
        #region Query Templates

        private const string queryTemplate = @"
    ""bool"": {{
{0}
    }}";

        private const string boostTemplate = "   \"boost\": {0}";
        private const string minimumNumberShouldMatchTemplate = "   \"minimum_number_should_match\": {0}";
        
        #endregion

        private int shouldPartsCount;

        public override string QueryTemplate
        {
            get { return queryTemplate; }
        }


        public BoolQuery<T> Must(Func<MustQuery<T>, Query<T>> mustQuery)
        {
            ExecuteAndRegisterQuery(mustQuery);

            return this;
        }

        public BoolQuery<T> Should(Func<ShouldQuery<T>, Query<T>> shouldQuery)
        {
            var shouldResult = ExecuteAndRegisterQuery(shouldQuery);

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

                var query = minimumNumberShouldMatchTemplate.F(number);
                Queries.Add(query);
            }

            return this;
        }

        public BoolQuery<T> Boost(double boost)
        {
            var boostQuery = boostTemplate.F(boost);
            Queries.Add(boostQuery);

            return this;
        }

    }
}