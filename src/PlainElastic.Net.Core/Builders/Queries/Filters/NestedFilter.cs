using System;
using PlainElastic.Net.Utils;

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
        private bool hasRequiredPart;

        /// <summary>
        /// Controls whether the filter will be cached.
        /// </summary>
        public NestedFilter<T> Cache(bool cache)
        {
            RegisterJsonPart("'_cache': {0}", cache.AsString());

            return this;
        }

        public NestedFilter<T> Filter(Func<Filter<T>, Filter<T>> filter)
        {
            var result = RegisterJsonPartExpression(filter);
            hasRequiredPart = !result.GetIsEmpty();

            return this;
        }

        protected override bool HasRequiredParts()
        {
            return base.HasRequiredParts() || hasRequiredPart;
        }
    }
}