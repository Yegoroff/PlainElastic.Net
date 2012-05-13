using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Represents Negative part of Boosting query.
    /// </summary>
    public class NegativeQuery<T> : Query<T>
    {

        protected override string ApplyJsonTemplate(string body)
        {
            return "'negative': {{ {0} }}".AltQuoteF(body);
        }

    }
}