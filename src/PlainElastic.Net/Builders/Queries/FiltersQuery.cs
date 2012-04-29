using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    public class FiltersQuery<T> : QueryBase<FiltersQuery<T>>
    {

        public FiltersQuery<T> Filter(Func<FilterQuery<T>, Filter<T>> filter)
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