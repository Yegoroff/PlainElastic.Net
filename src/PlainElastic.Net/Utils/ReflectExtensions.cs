using System;
using System.Linq.Expressions;

namespace PlainElastic.Net.Utils
{
    public static class ReflectExtensions
    {
        public static string GetQuotatedPropertyName<TClass, TProp>(this Expression<Func<TClass, TProp>> property)
        {
            return Reflect<TClass>.PropertyName(property)
                .Quotate();
        }

        public static string GetPropertyName<TClass, TProp>(this Expression<Func<TClass, TProp>> property)
        {
            return Reflect<TClass>.PropertyName(property);
        }
    }
}
