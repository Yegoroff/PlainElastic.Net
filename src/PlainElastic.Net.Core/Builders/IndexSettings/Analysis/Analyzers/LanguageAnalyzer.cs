using System.Collections.Generic;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A set of analyzers aimed at analyzing specific language text.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/lang-analyzer.html
    /// </summary>
    public class LanguageAnalyzer : StopwordsAnalyzerBase<LanguageAnalyzer>
    {
        private string type;

        public string AnalyzerType
        {
            get { return type; }
        }


        /// <summary>
        /// Sets the language analyzer type.
        /// </summary>
        public LanguageAnalyzer Type(string type)
        {
            this.type = type;
            if(ComponentName.IsNullOrEmpty())
                Name(type);

            return this;
        }

        /// <summary>
        /// Sets the language analyzer type.
        /// </summary>
        public LanguageAnalyzer Type(LanguageAnalyzerTypes type)
        {
            return Type(type.AsString());
        }


        /// <summary>
        /// Sets a list of stem exclusion words supported by the following languages:
        /// arabic, armenian, basque, brazilian, bulgarian, catalan, czech, danish, dutch, english, finnish, french, galician, german, hindi, hungarian, indonesian, italian, norwegian, portuguese, romanian, russian, spanish, swedish, turkish.
        /// </summary>
        public LanguageAnalyzer StemExclusion(IEnumerable<string> stemExclusion)
        {
            string propertyJson = JsonHelper.BuildJsonStringsProperty("stem_exclusion", stemExclusion);
            RegisterJsonPart(propertyJson);
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


        protected override string GetComponentType()
        {
            return type;
        }
    }
}