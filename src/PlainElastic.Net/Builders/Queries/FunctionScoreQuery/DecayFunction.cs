using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Score a document with a function that decays depending on the distance of a numeric field value of the document
    /// from a user given origin. This is similar to a range query, but with smooth edges instead of boxes.
    /// see: http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/query-dsl-function-score-query.html#_decay_functions
    /// </summary>
    public class DecayFunction<T> : FieldQueryBase<T, DecayFunction<T>>
    {
        private DecayFunctionType type = DecayFunctionType.linear;


        /// <summary>
        /// Type of the Decay function. Can be "linear", "exp" and "gauss".
        /// By default linear.
        /// </summary>
        public DecayFunction<T> Type(DecayFunctionType decayFunctionType)
        {
            type = decayFunctionType;
            return this;
        } 

        /// <summary>
        /// Defines the “central point” from which the distance is calculated.
        /// </summary>
        public DecayFunction<T> Origin(string origin)
        {
            RegisterJsonPart("'origin': {0}", origin.Quotate());
            return this;
        }


        /// <summary>
        ///  Defines the rate of decay
        /// </summary>
        public DecayFunction<T> Scale(string scale)
        {
            RegisterJsonPart("'scale': {0}", scale.Quotate());
            return this;
        }

        /// <summary>
        /// If an offset is defined, the decay function will only compute a the decay function
        /// for documents with a distance greater that the defined offset. The default is 0.
        /// </summary>
        public DecayFunction<T> Offset(string offset)
        {
            RegisterJsonPart("'offset': {0}", offset.Quotate());
            return this;
        }

        /// <summary>
        /// Defines how documents are scored at the distance given at scale.
        /// If no decay is defined, documents at the distance scale will be scored 0.5.
        /// </summary>
        public DecayFunction<T> Decay(double decay)
        {
            RegisterJsonPart("'decay': {0}", decay.AsString());
            return this;
        }


        protected override string ApplyJsonTemplate(string body)
        {
            if (RegisteredField.IsNullOrEmpty())
                return "'{0}': {{ {1} }}".AltQuoteF(type.AsString(), body);

            return "'{0}': {{ {1}: {{ {2} }} }}".AltQuoteF(type.AsString(), RegisteredField, body);
        }

        protected override bool HasRequiredParts()
        {
            return true;
        }
    }
}