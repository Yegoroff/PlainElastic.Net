using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    public class FilteredScoreFunctions<T> : QueryBase<FilteredScoreFunctions<T>>
    {
        public FilteredScoreFunctions<T> Function(Func<FilteredScoreFunction<T>, FilteredScoreFunction<T>> function)
        {
            RegisterJsonPartExpression(function);
            return this;
        }


        protected override string ApplyJsonTemplate(string body)
        {
            return "'functions': [ {0} ]".AltQuoteF(body);
        }

        protected override bool HasRequiredParts()
        {
            return true;
        }
    }
}