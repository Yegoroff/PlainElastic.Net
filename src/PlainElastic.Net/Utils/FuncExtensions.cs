using System;

namespace PlainElastic.Net.Utils
{
    public static class FuncExtensions
    {
        /// <summary>
        /// Represents Monadic Bind operator.
        /// Provides an easy way to compose functions.
        /// Internally it passes current expression result to <paramref name="func"/> function, 
        /// thus it could be used to apply additional logic to current expression.
        /// </summary>
        public static Func<T, TResult> Bind<T, TResult>(this Func<T, TResult> source, Func<TResult, TResult> func) where T : TResult
        {
            if (source == null)
                return o => func(o);

            return o => func(source(o));
        }

    }
}
