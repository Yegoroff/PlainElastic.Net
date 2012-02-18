using System;

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
            RegisterCustomJsonMap("'format': {0} ", dateFormat.Quotate());
            return this;            
        }


        /// <summary>
        ///  The precision step (number of terms generated for each number value). Defaults to 4.       
        /// </summary>
        public DateMap<T> PrecisionStep(int precisionStep = 4)
        {
            RegisterCustomJsonMap("'precision_step': {0} ", precisionStep.AsString().Quotate());
            return this;
        }


        protected override string GetFieldType(Type fieldType)
        {
            return "date";
        }

    }
}