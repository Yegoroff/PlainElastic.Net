using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// An analyzer of type pattern that can flexibly separate text into terms via a regular expression.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/pattern-analyzer.html
    /// </summary>
    public class PatternAnalyzer : AnalyzerBase<PatternAnalyzer>
    {

        /// <summary>
        /// Should terms be lowercased or not.
        /// Defaults to true.
        /// </summary>
        public PatternAnalyzer Lowercase(bool lowercase = true)
        {
            RegisterJsonPart("'lowercase': {0}", lowercase.AsString());
            return this;
        }

        /// <summary>
        /// Sets the regular expression pattern.
        /// Defaults to \W+.
        /// The regular expression should match the token separators, not the tokens themselves.
        /// </summary>
        public PatternAnalyzer Pattern(string pattern = @"\W+")
        {
            RegisterJsonPart("'pattern': {0}", pattern.Quotate());
            return this;
        }

        /// <summary>
        /// Sets the regular expression flags.
        /// </summary>
        public PatternAnalyzer Flags(RegexFlags flags)
        {
            RegisterJsonPart("'flags': {0}", flags.AsString().Quotate());
            return this;
        }


        protected override string GetComponentType()
        {
            return DefaultAnalyzers.pattern.AsString();
        }
    }
}