using System.Collections.Generic;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// Named word_delimiter, it splits words into subwords and performs optional transformations on subword groups.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/word-delimiter-tokenfilter.html
    /// </summary>
    public class WordDelimiterTokenFilter : NamedComponentBase<WordDelimiterTokenFilter>
    {

        /// <summary>
        /// Sets flag causing parts of words to be generated: "PowerShot" => "Power" "Shot".
        /// Defaults to true.
        /// </summary>
        public WordDelimiterTokenFilter GenerateWordParts(bool generateWordParts = true)
        {
            RegisterJsonPart("'generate_word_parts': {0}", generateWordParts.AsString());
            return this;
        }

        /// <summary>
        /// Sets flag causing number subwords to be generated: "500-42" => "500" "42".
        /// Defaults to true.
        /// </summary>
        public WordDelimiterTokenFilter GenerateNumberParts(bool generateNumberParts = true)
        {
            RegisterJsonPart("'generate_number_parts': {0}", generateNumberParts.AsString());
            return this;
        }

        /// <summary>
        /// Sets flag causing maximum runs of word parts to be catenated: "wi-fi" => "wifi".
        /// Defaults to false.
        /// </summary>
        public WordDelimiterTokenFilter CatenateWords(bool catenateWords = false)
        {
            RegisterJsonPart("'catenate_words': {0}", catenateWords.AsString());
            return this;
        }

        /// <summary>
        /// Sets flag causing maximum runs of number parts to be catenated: "500-42" => "50042".
        /// Defaults to false.
        /// </summary>
        public WordDelimiterTokenFilter CatenateNumbers(bool catenateNumbers = false)
        {
            RegisterJsonPart("'catenate_numbers': {0}", catenateNumbers.AsString());
            return this;
        }

        /// <summary>
        /// Sets flag causing all subword parts to be catenated: "wi-fi-4000" => "wifi4000".
        /// Defaults to false.
        /// </summary>
        public WordDelimiterTokenFilter CatenateAll(bool catenateAll = false)
        {
            RegisterJsonPart("'catenate_all': {0}", catenateAll.AsString());
            return this;
        }

        /// <summary>
        /// Sets flag causing "PowerShot" to be two tokens; ("Power-Shot" remains two parts regards).
        /// Defaults to true.
        /// </summary>
        public WordDelimiterTokenFilter SplitOnCaseChange(bool splitOnCaseChange = true)
        {
            RegisterJsonPart("'split_on_case_change': {0}", splitOnCaseChange.AsString());
            return this;
        }

        /// <summary>
        /// Sets flag controlling inclusion of original words in subwords: "500-42" => "500" "42" "500-42".
        /// Defaults to false.
        /// </summary>
        public WordDelimiterTokenFilter PreserveOriginal(bool preserveOriginal = false)
        {
            RegisterJsonPart("'preserve_original': {0}", preserveOriginal.AsString());
            return this;
        }

        /// <summary>
        /// Sets flag causing "j2se" to be three tokens; "j" "2" "se".
        /// Defaults to true.
        /// </summary>
        public WordDelimiterTokenFilter SplitOnNumerics(bool splitOnNumerics = true)
        {
            RegisterJsonPart("'split_on_numerics': {0}", splitOnNumerics.AsString());
            return this;
        }

        /// <summary>
        /// Sets flag causing trailing "'s" to be removed for each subword: "O'Neil's" => "O", "Neil".
        /// Defaults to true.
        /// </summary>
        public WordDelimiterTokenFilter StemEnglishPossessive(bool stemEnglishPossessive = true)
        {
            RegisterJsonPart("'stem_english_possessive': {0}", stemEnglishPossessive.AsString());
            return this;
        }

        /// <summary>
        /// Sets a list of words protected from being delimited.
        /// </summary>
        public WordDelimiterTokenFilter ProtectedWords(IEnumerable<string> protectedWords)
        {
            string propertyJson = JsonHelper.BuildJsonStringsProperty("protected_words", protectedWords);
            RegisterJsonPart(propertyJson);
            return this;
        }

        /// <summary>
        /// Sets a list of words protected from being delimited.
        /// </summary>
        public WordDelimiterTokenFilter ProtectedWords(params string[] protectedWords)
        {
            return ProtectedWords((IEnumerable<string>)protectedWords);
        }

        /// <summary>
        /// Sets a path (either relative to config location, or absolute) to a protected words file configuration.
        /// </summary>
        public WordDelimiterTokenFilter ProtectedWordsPath(string protectedWordsPath)
        {
            RegisterJsonPart("'protected_words_path': {0}", protectedWordsPath.Quotate());
            return this;
        }

        /// <summary>
        /// Sets a custom type mapping table.
        /// </summary>
        public WordDelimiterTokenFilter TypeTable(IEnumerable<string> typeTable)
        {
            string propertyJson = JsonHelper.BuildJsonStringsProperty("type_table", typeTable);
            RegisterJsonPart(propertyJson);
            return this;
        }

        /// <summary>
        /// Sets a custom type mapping table.
        /// </summary>
        public WordDelimiterTokenFilter TypeTable(params string[] typeTable)
        {
            return TypeTable((IEnumerable<string>)typeTable);
        }

        /// <summary>
        /// Sets a path (either relative to config location, or absolute) to a custom type mapping file configuration.
        /// </summary>
        public WordDelimiterTokenFilter TypeTablePath(string typeTablePath)
        {
            RegisterJsonPart("'type_table_path': {0}", typeTablePath.Quotate());
            return this;
        }


        protected override string GetComponentType()
        {
            return DefaultTokenFilters.word_delimiter.AsString();
        }
    }
}