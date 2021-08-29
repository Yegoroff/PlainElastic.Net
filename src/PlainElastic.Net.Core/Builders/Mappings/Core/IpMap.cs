using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Mappings
{
    /// <summary>
    /// Represents IP fields mapping.
    /// Allows to store ipv4 addresses in a numeric form allowing to easily sort, and range query it (using ip values)
    /// see http://www.elasticsearch.org/guide/reference/mapping/ip-type.html
    /// </summary>
    public class IpMap<T> : PropertyBase<T, IpMap<T>>
    {
        protected override string GetElasticFieldType(Type fieldType)
        {
            return "ip";
        }

        /// <summary>
        /// The precision step (number of terms generated for each number value). Defaults to 4.
        /// </summary>
        public IpMap<T> PrecisionStep(int precisionStep = 4)
        {
            RegisterCustomJsonMap("'precision_step': {0}", precisionStep.AsString());
            return this;
        }


    }
}