using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    public class RangeAggregationFromTo : QueryBase<RangeAggregationFromTo>
    {
        private bool hasValue;


        public RangeAggregationFromTo FromTo(double? from = null, double? to = null)
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

		public RangeAggregationFromTo FromTo(string key, double? from = null, double? to = null)
		{
			if (!to.HasValue && !from.HasValue)
				return this;

			hasValue = true;

			if (from.HasValue)
			{
				if (to.HasValue)
					RegisterJsonPart("{{ 'key': {0}, 'from': {1}, 'to': {2} }}", key.Quotate(), from.AsString(), to.AsString());
				else
					RegisterJsonPart("{{ 'key': {0}, 'from': {1} }}", key.Quotate(), from.AsString());
			}
			else
				RegisterJsonPart("{{ 'key': {0}, 'to': {1} }}", key.Quotate(), to.AsString());

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