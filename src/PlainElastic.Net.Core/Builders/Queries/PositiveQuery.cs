using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Represents Positive part of Boosting query.
    /// </summary>
    public class PositiveQuery<T> : Query<T>
    {

        protected override string ApplyJsonTemplate(string body)
        {
            return "'positive': {{ {0} }}".AltQuoteF(body);
        }

    }
}