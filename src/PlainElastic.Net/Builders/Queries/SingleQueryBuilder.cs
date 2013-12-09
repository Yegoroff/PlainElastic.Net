using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    public class SingleQueryBuilder<T> : Query<T>
    {

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents beautified JSON query.
        /// </summary>
        public override string ToString()
        {
            return this.BuildBeautified();
        }


        protected override bool HasRequiredParts()
        {
            return true;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "{0}".AltQuoteF(body);
        }
    }
}