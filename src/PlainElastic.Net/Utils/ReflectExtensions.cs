using System;
using System.Linq.Expressions;

namespace PlainElastic.Net.Utils
{
    public static class ReflectExtensions
    {
        public static string GetQuotatedPropertyPath<TClass, TProp>(this Expression<Func<TClass, TProp>> property)
        {
            return Reflect<TClass>.PropertyPath(property)
                .Quotate();
        }

        public static string GetPropertyPath<TClass, TProp>(this Expression<Func<TClass, TProp>> property)
        {
            return Reflect<TClass>.PropertyPath(property);
        }
    }
}
