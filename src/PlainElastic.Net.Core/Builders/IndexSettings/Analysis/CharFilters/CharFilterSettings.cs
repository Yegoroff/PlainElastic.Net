using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// Allows to configure char filters to be used in custom analyzers.
    /// </summary>
    public class CharFilterSettings : SettingsBase<CharFilterSettings>
    {

        #region HtmlStrip

        /// <summary>
        /// A char filter of type html_strip stripping out HTML elements from an analyzed text.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/htmlstrip-charfilter.html
        /// </summary>
        public CharFilterSettings HtmlStrip(string name, Func<HtmlStripCharFilter, HtmlStripCharFilter> htmlStrip = null)
        {
            RegisterJsonPartExpression(htmlStrip.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A char filter of type html_strip stripping out HTML elements from an analyzed text.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/htmlstrip-charfilter.html
        /// </summary>
        public CharFilterSettings HtmlStrip(Func<HtmlStripCharFilter, HtmlStripCharFilter> htmlStrip)
        {
            return HtmlStrip(DefaultCharFilters.html_strip.AsString(), htmlStrip);
        }

        #endregion


        #region Mapping

        /// <summary>
        /// A char filter of type mapping replacing characters of an analyzed text with given mapping.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/mapping-charfilter.html
        /// </summary>
        public CharFilterSettings Mapping(string name, Func<MappingCharFilter, MappingCharFilter> mapping = null)
        {
            RegisterJsonPartExpression(mapping.Bind(tokenizer => tokenizer.Name(name)));
            return this;
        }

        /// <summary>
        /// A char filter of type mapping replacing characters of an analyzed text with given mapping.
        /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/mapping-charfilter.html
        /// </summary>
        public CharFilterSettings Mapping(Func<MappingCharFilter, MappingCharFilter> mapping)
        {
            return Mapping(DefaultCharFilters.mapping.AsString(), mapping);
        }

        #endregion


        protected override string ApplyJsonTemplate(string body)
        {
            return "'char_filter': {{ {0} }}".AltQuoteF(body);
        }
    }
}