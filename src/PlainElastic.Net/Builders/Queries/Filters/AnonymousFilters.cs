using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Defines an array of anonymous filters.
    /// <remarks>
    /// Used in <see cref="FiltersAggregation{T}"/>.
    ///  </remarks>
    /// </summary>
    public class AnonymousFilters<T> : Filter<T>
    {
        protected override string ApplyJsonTemplate(string body)
        {
            return string.Format("[ {0} ] ", body.AltQuoteF());
        }
    }

}
