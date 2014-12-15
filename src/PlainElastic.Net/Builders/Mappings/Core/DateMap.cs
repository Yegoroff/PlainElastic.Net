using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Mappings
{
    /// <summary>
    /// Represents Date fields mapping.
    /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
    /// </summary>
    public class DateMap<T>: PropertyBase<T, DateMap<T>>
    {
        
        /// <summary>
        /// Allows to specify the date format.
        /// All dates are UTC.
        /// see  http://www.elasticsearch.org/guide/reference/mapping/date-format.html
        /// </summary>
        public DateMap<T> Format(string dateFormat)
        {
            RegisterCustomJsonMap("'format': {0}", dateFormat.Quotate());
            return this;            
        }


        /// <summary>
        ///  The precision step (number of terms generated for each number value). Defaults to 4.       
        /// </summary>
        public DateMap<T> PrecisionStep(int precisionStep = 4)
        {
            RegisterCustomJsonMap("'precision_step': {0}", precisionStep.AsString());
            return this;
        }


        /// <summary>
        /// Allow to configure a fuzzy_factor mapping value (defaults to 1), which will be used to multiply the fuzzy value by it when used in a query_string type query.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/fuzzy-query.html
        /// </summary>
        public DateMap<T> FuzzyFactor(int fuzzyFactor = 1)
        {
            RegisterCustomJsonMap("'fuzzy_factor': {0}", fuzzyFactor.AsString());
            return this;
        }


        protected override string GetElasticFieldType(Type fieldType)
        {
            return "date";
        }

        /// <summary>
        /// The fields options allows to map several core types fields into a single json source field
        /// </summary>
        public virtual DateMap<T> Fields(Func<CoreFields<DateMap<T>>, CoreFields<DateMap<T>>> fields)
        {
            RegisterMapAsJson(fields);
            return this;
        }
    }
}