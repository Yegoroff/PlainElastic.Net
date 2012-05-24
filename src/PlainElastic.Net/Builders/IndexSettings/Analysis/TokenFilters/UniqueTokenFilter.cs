using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// The unique token filter can be used to only index unique tokens during analysis.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/unique-tokenfilter.html
    /// </summary>
    public class UniqueTokenFilter : NamedComponentBase<UniqueTokenFilter>
    {

        /// <summary>
        /// Sets flag indicating that only duplicate tokens on the same position should be removed.
        /// Defaults to false.
        /// </summary>
        public UniqueTokenFilter OnlyOnSamePosition(bool onlyOnSamePosition = false)
        {
            RegisterJsonPart("'only_on_same_position': {0}", onlyOnSamePosition.AsString());
            return this;
        }


        protected override string GetComponentType()
        {
            return DefaultTokenFilters.unique.AsString();
        }
    }
}