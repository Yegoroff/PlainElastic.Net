using System.Collections.Generic;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    public class ScoredFilter<T> : Filter<T>
    {
        private readonly List<string> modes = new List<string>();


        /// <summary>
        /// Sets the constant boost value used in case of filter match.
        /// </summary>
        public ScoredFilter<T> Boost(double boost)
        {
            modes.Add("'boost': {0}".AltQuoteF(boost.AsString()));
            return this;
        }

        /// <summary>
        /// Sets the script used to calculate boost value in case of filter match.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
        public ScoredFilter<T> Script(string script)
        {
            modes.Add("'script': {0}".AltQuoteF(script.Quotate()));
            return this;
        }


        protected override string ApplyJsonTemplate(string body)
        {
            string filter = base.ApplyJsonTemplate(body);

            modes.Insert(0, filter);

            string filterBody = modes.JoinWithComma();

            return "{{ {0} }}".AltQuoteF(filterBody);
        }
    }
}