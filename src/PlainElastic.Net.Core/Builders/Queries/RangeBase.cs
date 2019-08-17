using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Base class for Range filter and range query.
    /// </summary>
    public class RangeBase<T, TQuery> : FieldQueryBase<T, TQuery> where TQuery : RangeBase<T, TQuery>
    {
        private bool hasValue;


        /// <summary>
        /// The lower bound. Defaults to start from the first.
        /// </summary>
        public TQuery From(string value)
        {
            if (!value.IsNullOrEmpty())
            {
                hasValue = true;
                RegisterJsonPart("'from': {0}", value.Quotate());
            }
            return (TQuery)this;
        }

        /// <summary>
        /// The upper bound. Defaults to unbounded.
        /// </summary>
        public TQuery To(string value)
        {
            if (!value.IsNullOrEmpty())
            {
                hasValue = true;
                RegisterJsonPart("'to': {0}", value.Quotate());
            }

            return (TQuery)this;
        }

        /// <summary>
        /// Should the first from (if set) be inclusive or not. Defaults to true
        /// </summary>
        public TQuery IncludeLower(bool includeLower = true)
        {
            RegisterJsonPart("'include_lower': {0}", includeLower.AsString());
            return (TQuery)this;
        }

        /// <summary>
        /// Should the last to (if set) be inclusive or not. Defaults to true.
        /// </summary>
        public TQuery IncludeUpper(bool includeUpper = true)
        {
            RegisterJsonPart("'include_upper': {0}", includeUpper.AsString());
            return (TQuery)this;
        }

        /// <summary>
        /// Same as setting from to the value, and include_lower to false.
        /// </summary>
        public TQuery Gt(string value)
        {
            if (!value.IsNullOrEmpty())
            {
                hasValue = true;
                RegisterJsonPart("'gt': {0}", value.Quotate());
            }
            return (TQuery)this;
        }

        /// <summary>
        /// Same as setting from to the value, and include_lower to true.
        /// </summary>
        public TQuery Gte(string value)
        {
            if (!value.IsNullOrEmpty())
            {
                hasValue = true;
                RegisterJsonPart("'gte': {0}", value.Quotate());
            }
            return (TQuery)this;
        }

        /// <summary>
        /// Same as setting to to the value, and include_upper to false.
        /// </summary>
        public TQuery Lt(string value)
        {
            if (!value.IsNullOrEmpty())
            {
                hasValue = true;
                RegisterJsonPart("'lt': {0}", value.Quotate());
            }
            return (TQuery)this;
        }

        /// <summary>
        /// Same as setting to to the value, and include_upper to true.
        /// </summary>
        public TQuery Lte(string value)
        {
            if (!value.IsNullOrEmpty())
            {
                hasValue = true;
                RegisterJsonPart("'lte': {0}", value.Quotate());
            }
            return (TQuery)this;
        }


        protected override bool HasRequiredParts()
        {
            return hasValue;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            if (RegisteredField.IsNullOrEmpty())
                return "{{ 'range': {{ {0} }} }}".AltQuoteF(body);

            return "{{ 'range': {{ {0}: {{ {1} }} }} }}".AltQuoteF(RegisteredField, body);
        }

    }
}