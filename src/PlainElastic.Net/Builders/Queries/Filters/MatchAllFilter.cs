using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A filter that matches on all documents.
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/match-all-filter.html
    /// </summary>    
    public class MatchAllFilter<T> : IJsonConvertible
    {

        #region IJsonConvertible Members

        string IJsonConvertible.ToJson()
        {
            return "{ 'match_all': {} }".AltQuote();
        }

        #endregion


        public override string ToString()
        {
            return ((IJsonConvertible)this).ToJson();
        }

    }
}