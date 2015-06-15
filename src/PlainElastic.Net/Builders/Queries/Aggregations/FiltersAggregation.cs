using System;

namespace PlainElastic.Net.Queries
{
    using PlainElastic.Net.Utils;

    public class FiltersAggregation<T> : AggregationBase<FiltersAggregation<T>, T>
    {

        /// <summary>
        /// Filter that will be used to filter aggregation matches.
        /// </summary>
        public FiltersAggregation<T> Filter(Func<Filters<T>, Filter<T>> filter)
        {
            RegisterJsonPartExpression(filter);
            return this;
        }

        /// <summary>
        /// Filter that will be used to filter aggregation matches.
        /// </summary>
        public FiltersAggregation<T> AnonymousFilters(Func<AnonymousFilters<T>, Filter<T>> filter)
        {
            RegisterJsonPartExpression(filter);
            return this;
        }


        protected override string ApplyAggregationBodyJsonTemplate(string body)
        {
            return "'filters': {{ 'filters': {{ {0} }} }}".AltQuoteF(body);
        }
    }
}

