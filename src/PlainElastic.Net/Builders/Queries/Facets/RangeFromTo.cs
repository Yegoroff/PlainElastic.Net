using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    public class RangeFromTo : QueryBase<RangeFromTo>
    {
        private bool hasValue;


        public RangeFromTo FromTo(double? from = null, double? to = null)
        {
            if (!to.HasValue && !from.HasValue)
                return this;

            hasValue = true;

            if (from.HasValue)
            {
                if (to.HasValue)
                    RegisterJsonPart("{{ 'from': {0}, 'to': {1} }}", from.AsString(), to.AsString());
                else
                    RegisterJsonPart("{{ 'from': {0} }}", from.AsString());
            }
            else
                RegisterJsonPart("{{ 'to': {0} }}", to.AsString());

            return this;
        }


        protected override bool HasRequiredParts()
        {
            return hasValue;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "'ranges': [ {0} ]".AltQuoteF(body);
        }

    }
}