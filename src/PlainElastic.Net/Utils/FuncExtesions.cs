using System;

namespace PlainElastic.Net.Utils
{
    public static class FuncExtesions
    {
        /// <summary>
        /// Represents Monadic Bind operator.
        /// Provides an easy way to compose functions.
        /// Internally it passes current expression result to <paramref name="func"/> function, 
        /// thus it could be used to apply additional logic to current expression.
        /// </summary>
        public static Func<T, T> Bind<T>(this Func<T, T> source, Func<T, T> func)
        {
            if (source == null)
                return func;

            return o => func(source(o));
        }

    }
}
