using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    public abstract class TypedAnalysisComponentBase<TPart> : AnalysisComponentBase<TPart> where TPart : TypedAnalysisComponentBase<TPart>
    {
        protected abstract string GetComponentType();


        protected override string ApplyJsonTemplate(string body)
        {
            var type = GetComponentType();
            var typeProperty = "'type': {0}".AltQuoteF(type.Quotate());

            var typedBody = body.IsNullOrEmpty() ? typeProperty
                                                 : new[] { typeProperty, body }.JoinWithComma();

            return base.ApplyJsonTemplate(typedBody);
        }
    }
}