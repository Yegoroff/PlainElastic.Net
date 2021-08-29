using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
	/// <summary>
	/// The regexp filter is similar to the regexp query, except that it is cacheable and can speedup performance in case you are reusing this filter in your queries.
	/// see http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/query-dsl-regexp-filter.html
	/// </summary>    
    public class RegExpFilter<T> : FieldQueryBase<T, RegExpFilter<T>>
	{
		private bool hasValue;


        public RegExpFilter<T> Value(string value)
		{
			if (!value.IsNullOrEmpty())
			{
                RegisterJsonPart("{0}: {1}", RegisteredField, value.Quotate());
				hasValue = true;
			}

			return this;
		}


        public RegExpFilter<T> Value(string value, RegExpSyntaxFlags flags)
        {
            if (!value.IsNullOrEmpty())
            {
                RegisterJsonPart("{0}: {{ 'value': {1}, 'flags': {2} }}", RegisteredField, value.Quotate(), flags.AsString().Quotate());
                hasValue = true;
            }

            return this;
        }


		public RegExpFilter<T> Cache(bool cache)
		{
			RegisterJsonPart("'_cache': {0}", cache.AsString());
			return this;
		}

		public RegExpFilter<T> CacheKey(string cacheKey)
		{
			RegisterJsonPart("'_cache_key': {0}", cacheKey.Quotate());
			return this;
		}

		/// <summary>
		/// Allows to name filter, so the search response will include for each hit the matched_filters 
		/// it matched on (note, this feature make sense for or / bool filters).
		/// http://www.elasticsearch.org/guide/reference/api/search/named-filters.html 
		/// </summary>
		public RegExpFilter<T> Name(string filterName)
		{
			RegisterJsonPart("'_name': {0}", filterName.Quotate());
			return this;
		}



		protected override bool HasRequiredParts()
		{
			return hasValue;
		}

		protected override string ApplyJsonTemplate(string body)
		{
			return "{{ 'regexp': {{ {0} }} }}".AltQuoteF(body);
		}
	}
}
