using System;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Builders.Queries
{
    public class PartialFields<T> : QueryBase<PartialFields<T>>
    {
        public PartialFields<T> Partial(Func<Partial<T>, Partial<T>> partial)
        {
            RegisterJsonPartExpression(partial);
            return this;
        }

        protected override bool HasRequiredParts()
        {
            return true;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "'partial_fields': {{ {0} }}".AltQuoteF(body);
        }
    }
}