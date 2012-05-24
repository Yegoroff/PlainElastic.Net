using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// The pattern_replace token filter allows to easily handle string replacements based on a regular expression.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/pattern_replace-tokenfilter.html
    /// </summary>
    public class PatternReplaceTokenFilter : NamedComponentBase<PatternReplaceTokenFilter>
    {

        /// <summary>
        /// Sets the regular expression pattern.
        /// </summary>
        public PatternReplaceTokenFilter Pattern(string pattern)
        {
            RegisterJsonPart("'pattern': {0}", pattern.Quotate());
            return this;
        }

        /// <summary>
        /// Sets the replacement string.
        /// Supports referencing the original text, see http://docs.oracle.com/javase/6/docs/api/java/util/regex/Matcher.html
        /// </summary>
        public PatternReplaceTokenFilter Replacement(string replacement)
        {
            RegisterJsonPart("'replacement': {0}", replacement.Quotate());
            return this;
        }


        protected override string GetComponentType()
        {
            return DefaultTokenFilters.pattern_replace.AsString();
        }
    }
}