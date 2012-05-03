using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    public class ScoredFilters<T> : QueryBase<ScoredFilters<T>>
    {

        public ScoredFilters<T> Filter(Func<ScoredFilter<T>, Filter<T>> filter)
        {
            RegisterJsonPartExpression(filter);
            return this;
        }


        protected override bool HasRequiredParts()
        {
            return true;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "'filters': [ {0} ]".AltQuoteF(body);
        }

    }
}