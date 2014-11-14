using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
	/// <summary>
	/// The regexp filter is similar to the regexp query, except that it is cacheable and can speedup performance in case you are reusing this filter in your queries.
	/// see http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/query-dsl-regexp-filter.html
	/// </summary>    
	public class RegExpFilter<T> : QueryBase<RegExpFilter<T>>
	{
		private bool hasValue;

		public RegExpFilter<T> Value(string path, string regex)
		{
			if (!path.IsNullOrEmpty() && !regex.IsNullOrEmpty())
			{
				RegisterJsonPart("{0}: {1}", path.Quotate(), regex.Quotate());
				hasValue = true;
			}

			return this;
		}

		/// <summary>
		/// You can also select the cache name and use the same regexp flags in the filter as in the query.
		/// </summary>
		public RegExpFilter<T> Value(string path, string regex, RegexFlags regexFlags)
		{
			if (!path.IsNullOrEmpty() && !regex.IsNullOrEmpty())
			{
				RegisterJsonPart("{0}: {{ {1}, {2} }}", path.Quotate(), regex.Quotate(), regexFlags.AsString().Quotate());
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
