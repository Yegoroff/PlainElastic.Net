using System.Collections.Generic;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A char filter of type mapping replacing characters of an analyzed text with given mapping.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/mapping-charfilter.html
    /// </summary>
    public class MappingCharFilter : NamedComponentBase<MappingCharFilter>
    {
        /// <summary>
        /// Sets a list of character mappings.
        /// </summary>
        public MappingCharFilter Mappings(IEnumerable<string> mappings)
        {
            string propertyJson = JsonHelper.BuildJsonStringsProperty("mappings", mappings);
            RegisterJsonPart(propertyJson);
            return this;
        }

        /// <summary>
        /// Sets a list of character mappings.
        /// </summary>
        public MappingCharFilter Mappings(params string[] mappings)
        {
            return Mappings((IEnumerable<string>)mappings);
        }

        /// <summary>
        /// Sets a path (either relative to config location, or absolute) to a mappings file.
        /// </summary>
        public MappingCharFilter MappingsPath(string mappingsPath)
        {
            RegisterJsonPart("'mappings_path': {0}", mappingsPath.Quotate());
            return this;
        }


        protected override string GetComponentType()
        {
            return DefaultCharFilters.mapping.AsString();
        }
    }
}