using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A phonetic analysis token filter plugin.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/phonetic-tokenfilter.html
    /// </summary>
    public class PhoneticTokenFilter : NamedComponentBase<PhoneticTokenFilter>
    {
        protected override string GetComponentType()
        {
            return DefaultTokenFilters.phonetic.AsString();
        }


        /// <summary>
        /// Sets a phonetic encoder.
        /// </summary>
        public PhoneticTokenFilter Encoder(string encoder)
        {
            RegisterJsonPart("'encoder': {0}", encoder.Quotate());
            return this;
        }

        /// <summary>
        /// Sets a phonetic encoder.
        /// </summary>
        public PhoneticTokenFilter Encoder(PhoneticTokenFilterEncoders encoder)
        {
            RegisterJsonPart("'encoder': {0}", encoder.AsString().Quotate());
            return this;
        }

        /// <summary>
        /// Sets flag controlling if the token processed should be replaced with the encoded one (true), or added (false).
        /// Defaults to true.
        /// </summary>
        public PhoneticTokenFilter Replace(bool replace = true)
        {
            RegisterJsonPart("'replace': {0}", replace.AsString());
            return this;
        }
    }
}