using System;
using System.Collections.Generic;
using System.Linq;
using PlainElastic.Net.Builders;

namespace PlainElastic.Net.Mappings
{
    public abstract class ObjectBase<T, TMapping> : MappingBase where TMapping : ObjectBase<T, TMapping>
    {

        /// <summary>
        /// The name of mapped object.
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Allows to Map object properties
        /// see http://www.elasticsearch.org/guide/reference/mapping/object-type.html
        /// </summary>
        public TMapping Properties(Func<Properties<T>, Properties<T>> properties)
        {
            RegisterMapAsJson(properties);

            return (TMapping)this;
        }

        /// <summary>
        /// Allows to disable dynamic JSOM object mapping.
        /// </summary>
        public TMapping Dynamic(bool enableDynamic)
        {
            return Custom(" 'dynamic': {0}", enableDynamic.AsString());
        }

        /// <summary>
        /// Allows to disable parsing and adding a named object completely.
        /// </summary>
        public TMapping Enabled(bool enable)
        {
            return Custom(" 'enabled': {0}", enable.AsString());
        }

        /// <summary>
        /// Allows to specify custom path within index to mapped document. 
        /// </summary>
        public TMapping Path(string path)
        {
            return Custom(" 'path': {0}", path.Quotate());
        }

        /// <summary>
        /// Allows to control document and inner documents inclusion to _all field.
        /// </summary>
        public TMapping IncludeInAll(bool includeInAll)
        {
            return Custom(" 'include_in_all': {0}", includeInAll.AsString());
        }


        /// <summary>
        /// Adds a custom mapping to Object Map.
        /// You can use ' instead of " to simplify mapFormat creation.
        /// </summary>
        public TMapping Custom(string mapFormat, params string[] args)
        {
            RegisterCustomJsonMap(mapFormat, args);

            return (TMapping)this;
        }


        protected override string ApplyMappingTemplate(string mappingBody)
        {
            // Full:  " '{0}': {{ 'type': 'object', {1} }}";
            return " {0}: {{ {1} }}".F(Name.Quotate(), mappingBody);
        }
    }
}