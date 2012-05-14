using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Filters documents with fields that have values within a certain numeric range.
    /// Similar to range filter, except that it works only with numeric values, and the filter execution works differently.
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/numeric-range-filter.html
    /// </summary>
    public class NumericRangeFilter<T> : RangeFilter<T>
    {
        protected override string ApplyJsonTemplate(string body)
        {
            var filterBody = GetFilterBody(body);

            return "{{ 'numeric_range': {{ {0} }} }}".AltQuoteF(filterBody);
        }
    }
}