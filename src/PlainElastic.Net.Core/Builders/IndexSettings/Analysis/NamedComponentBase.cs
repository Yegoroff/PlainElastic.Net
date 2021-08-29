using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// Base class for Analyzers, Tokenizers and Filters.
    /// </summary>
    public abstract class NamedComponentBase<TPart> : SettingsBase<TPart> where TPart : NamedComponentBase<TPart>
    {
        public string ComponentName { get; set; }

        
        public TPart Name(string name)
        {
            ComponentName = name;
            return (TPart)this;
        }

        /// <summary>
        /// Controls which Lucene version behavior this component should use.
        /// The highest version number is the default option.
        /// </summary>
        public TPart Version(string version)
        {
            RegisterJsonPart("'version': {0}", version.Quotate());
            return (TPart)this;
        }


        protected abstract string GetComponentType();


        protected override string ApplyJsonTemplate(string body)
        {
            var type = GetComponentType();
            var typeProperty = "'type': {0}".AltQuoteF(type.Quotate());

            var typedBody = body.IsNullOrEmpty() ? typeProperty
                                                 : new[] { typeProperty, body }.JoinWithComma();

            return "{0}: {{ {1} }}".F(ComponentName.Quotate(), typedBody);
        }

    }
}