using System.Collections.Generic;
using System.Linq;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// An analyzer of type custom that allows to combine a Tokenizer with zero or more Token Filters, and zero or more Char Filters.
    /// The custom analyzer accepts a logical/registered name of the tokenizer to use, and a list of logical/registered names of token filters.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/custom-analyzer.html
    /// </summary>
    public class CustomAnalyzer : AnalyzerBase<CustomAnalyzer>
    {

        /// <summary>
        /// Sets the logical / registered name of the tokenizer to use.
        /// </summary>
        public CustomAnalyzer Tokenizer(string tokenizer)
        {
            RegisterJsonPart("'tokenizer': {0}", tokenizer.Quotate());
            return this;
        }

        /// <summary>
        /// Sets the logical / registered name of the tokenizer to use.
        /// </summary>
        public CustomAnalyzer Tokenizer(DefaultTokenizers tokenizer)
        {
            return Tokenizer(tokenizer.AsString());
        }

        
        /// <summary>
        /// Sets an optional list of logical / registered name of token filters.
        /// </summary>
        public CustomAnalyzer Filter(IEnumerable<string> filters)
        {
            string propertyJson = JsonHelper.BuildJsonStringsProperty("filter", filters);
            RegisterJsonPart(propertyJson);
            return this;
        }

        /// <summary>
        /// Sets an optional list of logical / registered name of token filters.
        /// </summary>
        public CustomAnalyzer Filter(params string[] filters)
        {
            return Filter((IEnumerable<string>)filters);
        }

        /// <summary>
        /// Sets an optional list of logical / registered name of token filters.
        /// </summary>
        public CustomAnalyzer Filter(IEnumerable<DefaultTokenFilters> filters)
        {
            return Filter(filters.Select(f => f.AsString()));
        }

        /// <summary>
        /// Sets an optional list of logical / registered name of token filters.
        /// </summary>
        public CustomAnalyzer Filter(params DefaultTokenFilters[] filters)
        {
            return Filter((IEnumerable<DefaultTokenFilters>)filters);
        }


        /// <summary>
        /// Sets an optional list of logical / registered name of char filters.
        /// </summary>
        public CustomAnalyzer CharFilter(IEnumerable<string> filters)
        {
            string propertyJson = JsonHelper.BuildJsonStringsProperty("char_filter", filters);
            RegisterJsonPart(propertyJson);
            return this;
        }

        /// <summary>
        /// Sets an optional list of logical / registered name of char filters.
        /// </summary>
        public CustomAnalyzer CharFilter(params string[] filters)
        {
            return CharFilter((IEnumerable<string>)filters);
        }

        /// <summary>
        /// Sets an optional list of logical / registered name of char filters.
        /// </summary>
        public CustomAnalyzer CharFilter(IEnumerable<DefaultCharFilters> filters)
        {
            return CharFilter(filters.Select(f => f.AsString()));
        }

        /// <summary>
        /// Sets an optional list of logical / registered name of char filters.
        /// </summary>
        public CustomAnalyzer CharFilter(params DefaultCharFilters[] filters)
        {
            return CharFilter((IEnumerable<DefaultCharFilters>)filters);
        }


        protected override string GetComponentType()
        {
            return "custom";
        }
    }
}