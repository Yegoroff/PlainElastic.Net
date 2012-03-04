using System;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
    public static class Reflect<T>
    {

        public static string LowerCasedPropertyType<TPropertyType>(Expression<Func<T, TPropertyType>> exp)
        {
            return PropertyTypeFromExpresion(exp.Body).ToLower();
        }

        public static string PropertyType<TPropertyType>(Expression<Func<T, TPropertyType>> exp)
        {
            return PropertyTypeFromExpresion(exp.Body);
        }


        public static string CamelCasedPropertyName<TPropertyType>(Expression<Func<T, TPropertyType>> exp)
        {
            return PropertyNameFromExpresion(exp.Body, camelCase: true, fullPath: false);
        }

        public static string CamelCasedPropertyPath<TPropertyType>(Expression<Func<T, TPropertyType>> exp)
        {
            return PropertyNameFromExpresion(exp.Body, camelCase: true);
        }


        public static string PropertyName<TPropertyType>(Expression<Func<T, TPropertyType>> exp)
        {
            return PropertyNameFromExpresion(exp.Body, camelCase: false, fullPath: false);
        }

        public static string PropertyPath<TPropertyType>(Expression<Func<T, TPropertyType>> exp)
        {
            return PropertyNameFromExpresion(exp.Body, camelCase: false);
        }


        private static string PropertyTypeFromExpresion(Expression exp)
        {
            MemberExpression memberExpression = exp as MemberExpression;
            if (memberExpression == null && exp is UnaryExpression)
            {
                UnaryExpression unaryExpression = (UnaryExpression)exp;
                memberExpression = unaryExpression.Operand as MemberExpression;
            }

            if (memberExpression == null)
                return "";

            return memberExpression.Type.Name;
        }

        private static string PropertyNameFromExpresion(Expression exp, bool camelCase, bool fullPath = true)
        {
            MemberExpression memberExpression = exp as MemberExpression;
            if (memberExpression == null && exp is UnaryExpression)
            {
                UnaryExpression unaryExpression = (UnaryExpression)exp;
                memberExpression = unaryExpression.Operand as MemberExpression;
            }

            if (memberExpression == null)
                return "";

            string prefix = "";
            if (fullPath)
                prefix = PropertyNameFromExpresion(memberExpression.Expression, camelCase);

            var name = memberExpression.Member.Name;
            if (camelCase)
                name = name.ToCamelCase();

            if (!prefix.IsNullOrEmpty())
                return prefix + "." + name;

            return name;
        }

    }
}
