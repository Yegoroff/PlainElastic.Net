using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PlainElastic.Net.Utils
{
    public static class ReflectExtensions
    {
        public static string GetQuotatedPropertyName<TClass, TProp>(this Expression<Func<TClass, TProp>> property)
        {
            return Reflect<TClass>.CamelCasedPropertyName(property)
                .Quotate();
        }

        public static string GePropertyName<TClass, TProp>(this Expression<Func<TClass, TProp>> property)
        {
            return Reflect<TClass>.CamelCasedPropertyName(property);
        }
    }
}
