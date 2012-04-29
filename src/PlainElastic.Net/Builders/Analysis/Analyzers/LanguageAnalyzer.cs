using System.Collections.Generic;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A set of analyzers aimed at analyzing specific language text.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/lang-analyzer.html
    /// </summary>
    public class LanguageAnalyzer : StopAnalyzerBase<LanguageAnalyzer>
    {
        private string type;

        public string AnalyzerType
        {
            get { return type; }
        }


        protected override string GetComponentType()
        {
            return type;
        }


        /// <summary>
        /// Sets the language analyzer type.
        /// </summary>
        public LanguageAnalyzer Type(string type)
        {
            this.type = type;
            return this;
        }

        /// <summary>
        /// Sets the language analyzer type.
        /// </summary>
        public LanguageAnalyzer Type(LanguageAnalyzerTypes type)
        {
            return Type(type.ToString());
        }


        /// <summary>
        /// Sets a list of stem exclusion words supported by the following languages:
        /// arabic, armenian, basque, brazilian, bulgarian, catalan, czech, danish, dutch, english, finnish, french, galician, german, hindi, hungarian, indonesian, italian, norwegian, portuguese, romanian, russian, spanish, swedish, turkish.
        /// </summary>
        public LanguageAnalyzer StemExclusion(IEnumerable<string> stemExclusion)
        {
            RegisterJsonStringsProperty("stem_exclusion", stemExclusion);
            return this;
        }

        /// <summary>
        /// Sets a list of stem exclusion words supported by the following languages:
        /// arabic, armenian, basque, brazilian, bulgarian, catalan, czech, danish, dutch, english, finnish, french, galician, german, hindi, hungarian, indonesian, italian, norwegian, portuguese, romanian, russian, spanish, swedish, turkish.
        /// </summary>
        public LanguageAnalyzer StemExclusion(params string[] stemExclusion)
        {
            return StemExclusion((IEnumerable<string>)stemExclusion);
        }
    }
}