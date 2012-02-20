namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A filter that allows to filter nested objects / docs.
    /// The filter is executed against the nested objects / docs as if they were indexed 
    /// as separate docs (they are, internally) and resulting in the root parent doc (or parent nested mapping)
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/nested-filter.html
    /// </summary>
    public class NestedFilter<T> : NestedBase<NestedFilter<T>, T>
    {
        /// <summary>
        /// Controls whether the filter will be cached.
        /// </summary>
        public NestedFilter<T> Cache(bool cache)
        {
            var scoreParam = " '_cache': {0}".SmartQuoteF(cache.AsString());
            RegisterJsonParam(scoreParam);

            return this;
        }
    }
}