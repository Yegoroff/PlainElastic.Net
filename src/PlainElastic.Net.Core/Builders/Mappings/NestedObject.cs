using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Mappings
{
    /// <summary>
    /// Builds a mapping that allows to map certain sections in the document indexed as nested allowing to query them as if they are separate docs joining with the parent owning doc.
    /// http://www.elasticsearch.org/guide/reference/mapping/nested-type.html
    /// </summary>
    public class NestedObject<T> : ObjectBase<T, NestedObject<T>>
    {

        /// <summary>
        /// Allows to object fields be automatically added to the immediate parent.
        /// </summary>
        public NestedObject<T> IncludeInParent(bool includeInParent = false)
        {
            RegisterCustomJsonMap("'include_in_parent ': {0}", includeInParent.AsString());
            return this;
        }

        /// <summary>
        /// Allows to object fields be automatically added to the root object.
        /// </summary>
        public NestedObject<T> IncludeInRoot(bool includeInRoot = false)
        {
            RegisterCustomJsonMap("'include_in_root ': {0}", includeInRoot.AsString());
            return this;
        }
        

        protected override string ApplyMappingTemplate(string mappingBody)
        {
            if (mappingBody.IsNullOrEmpty())
                return "{0}: {{ 'type': 'nested' }}".AltQuoteF(Name.Quotate());

            return "{0}: {{ 'type': 'nested',{1} }}".AltQuoteF(Name.Quotate(), mappingBody);
        }

    }
}