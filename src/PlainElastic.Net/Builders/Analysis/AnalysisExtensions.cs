using System;
using System.Collections.Generic;
using System.Linq;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    public static class AnalysisExtensions
    {
        internal static Func<TComponent, TComponent> Name<TComponent>(this Func<TComponent, TComponent> component, Func<TComponent, string> name) where TComponent : AnalysisComponentBase<TComponent>
        {
            return obj =>
                    {
                        var componentPart = component(obj);
                        return componentPart.Name(name(componentPart));
                    };
        }

        internal static Func<TComponent, TComponent> Name<TComponent>(this Func<TComponent, TComponent> component, string name) where TComponent : AnalysisComponentBase<TComponent>
        {
            if (component == null)
                return obj => obj.Name(name);

            return component.Name(_ => name);
        }

        internal static void RegisterJsonStringsProperty<TPart>(this AnalysisBase<TPart> builder, string name, IEnumerable<string> values) where TPart : AnalysisBase<TPart>
        {
            var valuesJson = values.Where(v => !v.IsNullOrEmpty()).Quotate().JoinWithComma();
            builder.CustomPart("{0}: [ {1} ]", name.Quotate(), valuesJson);
        }
    }
}