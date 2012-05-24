using System.Collections.Generic;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A token filter of type dictionary_decompounder that allows to decompose compound words.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/compound-word-tokenfilter.html
    /// </summary>
    public class DictionaryDecompounderTokenFilter : NamedComponentBase<DictionaryDecompounderTokenFilter>
    {

        /// <summary>
        /// Sets a list of words to use.
        /// </summary>
        public DictionaryDecompounderTokenFilter WordList(IEnumerable<string> wordList)
        {
            string propertyJson = JsonHelper.BuildJsonStringsProperty("word_list", wordList);
            RegisterJsonPart(propertyJson);
            return this;
        }

        /// <summary>
        /// Sets a list of words to use.
        /// </summary>
        public DictionaryDecompounderTokenFilter WordList(params string[] wordList)
        {
            return WordList((IEnumerable<string>)wordList);
        }

        /// <summary>
        /// Sets a path (either relative to config location, or absolute) to a list of words file.
        /// </summary>
        public DictionaryDecompounderTokenFilter WordListPath(string wordListPath)
        {
            RegisterJsonPart("'word_list_path': {0}", wordListPath.Quotate());
            return this;
        }


        protected override string GetComponentType()
        {
            return DefaultTokenFilters.dictionary_decompounder.AsString();
        }
    }
}