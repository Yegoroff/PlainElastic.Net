using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A tokenizer of type pattern that can flexibly separate text into terms via a regular expression. 
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/pattern-tokenizer.html
    /// </summary>
    public class PatternTokenizer : NamedComponentBase<PatternTokenizer>
    {

        /// <summary>
        /// Sets the regular expression pattern.
        /// Defaults to \W+.
        /// The regular expression should match the token separators, not the tokens themselves.
        /// </summary>
        public PatternTokenizer Pattern(string pattern = @"\W+")
        {
            RegisterJsonPart("'pattern': {0}", pattern.Quotate());
            return this;
        }

        /// <summary>
        /// Sets the regular expression flags.
        /// </summary>
        public PatternTokenizer Flags(RegexFlags flags)
        {
            RegisterJsonPart("'flags': {0}", flags.AsString().Quotate());
            return this;
        }

        /// <summary>
        /// Sets which group to extract into tokens.
        /// Defaults to -1 (split).
        /// </summary>
        public PatternTokenizer Group(int group = -1)
        {
            RegisterJsonPart("'group': {0}", group.AsString());
            return this;
        }


        protected override string GetComponentType()
        {
            return DefaultTokenizers.pattern.AsString();
        }
    }
}