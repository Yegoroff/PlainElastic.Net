using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    public class FilteredScoreFunction<T> : ScoreFunctionBase<FilteredScoreFunction<T>, T>
    {
        public FilteredScoreFunction<T> Filter(Func<Filter<T>, Filter<T>> filter)
        {
            RegisterJsonPartExpression(filter);
            return this;
        }


        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ {0} }}".AltQuoteF(body);
        }

        protected override bool HasRequiredParts()
        {
            return true;
        }
    }
}