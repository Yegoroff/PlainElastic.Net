using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Mappings
{
    /// <summary>
    /// Allows to control _parent field behavior 
    /// see http://www.elasticsearch.org/guide/reference/mapping/parent-field.html
    /// </summary>
    public class ParentField<T> : MappingBase<ParentField<T>>
    {

        /// <summary>
        /// Allows to define the parent field mapping on a child mapping, and points to the parent type this child relates to.
        /// </summary>
        public ParentField<T> Type(string parentType)
        {
            RegisterCustomJsonMap("'type': {0} ", parentType.Quotate());
            return this;
        }


        protected override string ApplyMappingTemplate(string mappingBody)
        {
            return "'_parent': {{ {0} }}".AltQuoteF(mappingBody);
        }
        
    }
}