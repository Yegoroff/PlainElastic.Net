using System;
using System.Collections.Generic;

namespace PlainElastic.Net.Tests
{
    public static class Extensions
    {
        public static bool ShouldContain(this string current, string other)
        {
            return current.Contains(other);
        }

        public static bool ShouldNotContain(this string current, string other)
        {
            return !current.Contains(other);
        }

        public static bool ShouldStartWith(this string current, string other)
        {
            return current.StartsWith(other, StringComparison.InvariantCulture);
        }

        public static bool ShouldBeEmpty(this string current)
        {
            return current == string.Empty;
        }

        public static bool ShouldBe(this Exception current, Type actual)
        {
            return current.GetType() == actual;
        }

        public static bool ShouldEqual<T>(this T current, T other)
        {
                return current.Equals(other);
        }

        public static bool ShouldNotBeNull<T>(this T current) where T : class
        {
            return current != null;
        }

        public static bool ShouldBeOfType<T>(this object current)
        {
            return current.GetType() == typeof(T);
        }

        public static bool ShouldBeNull(this object current)
        {
            return current == null;
        }

        public static bool ShouldBeTrue(this bool current)
        {
            return current;
        }




    }
}
