using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Mappings
{
    /// <summary>
    /// Allows to control _id field behavior 
    /// see http://www.elasticsearch.org/guide/reference/mapping/id-field.html
    /// </summary>
    public class IdField<T> : MappingBase<IdField<T>>
    {

        /// <summary>
        /// Set to yes the store actual field in the index, no to not store it.
        /// </summary>
        public IdField<T> Store(bool store)
        {
            RegisterCustomJsonMap("'store': {0}", store.AsString());
            return this;
        }

        /// <summary>
        /// Allows to control whether field searchable and analyzed.
        /// </summary>
        public IdField<T> Index(IndexState index)
        {
            RegisterCustomJsonMap("'index': {0}", index.AsString().Quotate());
            return this;
        }


        /// <summary>
        /// Allows to associate with a path that will be used to extract the id from a different location in the source document.
        /// </summary>
        public IdField<T> Path(string path)
        {
            RegisterCustomJsonMap("'path': {0}", path.Quotate());
            return this;
        }


        protected override string ApplyMappingTemplate(string mappingBody)
        {
            return "'_id': {{ {0} }}".AltQuoteF(mappingBody);
        }
        
    }
}