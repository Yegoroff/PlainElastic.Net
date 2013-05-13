using System;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Allows to highlight search results on one or more fields.
    /// see http://www.elasticsearch.org/guide/reference/api/search/highlighting.html
    /// </summary>
    public class Highlight<T> : HighlightBase<T, Highlight<T>>
    {

        #region HighlightedFields class that builds JSON fields collection

        /// <summary>
        /// Holds the highlighting fields JSON.
        /// </summary>
        private class HighlightedFields : QueryBase<HighlightedFields>
        {

            public void RegisterExpression<TJsonPart, TResultJsonPart>(Func<TJsonPart, TResultJsonPart> partExpression)
                where TJsonPart : new()
                where TResultJsonPart : IJsonConvertible
            {
                RegisterJsonPartExpression(partExpression);
            }

            protected override bool HasRequiredParts()
            {
                return true;
            }

            protected override string ApplyJsonTemplate(string body)
            {
                return "'fields': [ {0} ]".AltQuoteF(body);
            }

        }

        #endregion


        public Highlight<T> Fields(params Func<HighlightField<T>, HighlightField<T>>[] fields)
        {

            RegisterJsonPartExpression<HighlightedFields, HighlightedFields>(
                highlightedFields =>
                    {
                        foreach (var fieldExpression in fields)
                        {
                            highlightedFields.RegisterExpression(fieldExpression);
                        }
                        return highlightedFields;
                    });
            
            return this;
        }


        protected override string ApplyJsonTemplate(string body)
        {
            return "'highlight': {{ {0} }}".AltQuoteF(body);
        }

    }
}