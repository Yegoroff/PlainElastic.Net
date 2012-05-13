using System;
using System.Linq.Expressions;

namespace PlainElastic.Net.Utils
{
    public static class Reflect<T>
    {

        public static string PropertyType<TPropertyType>(Expression<Func<T, TPropertyType>> exp)
        {
            return PropertyTypeFromExpresion(exp.Body);
        }

        public static string PropertyName<TPropertyType>(Expression<Func<T, TPropertyType>> exp)
        {
            return PropertyNameFromExpresion(exp.Body, fullPath: false);
        }

        public static string PropertyPath<TPropertyType>(Expression<Func<T, TPropertyType>> exp)
        {
            return PropertyNameFromExpresion(exp.Body);
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

        private static string PropertyNameFromExpresion(Expression exp, bool fullPath = true)
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
                prefix = PropertyNameFromExpresion(memberExpression.Expression);

            var name = memberExpression.Member.Name;

            if (!prefix.IsNullOrEmpty())
                return prefix + "." + name;

            return name;
        }

    }
}
