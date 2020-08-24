using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Groundwork
{
    /// <summary>
    /// Enumerable extensions.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// For each.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="enumerable">Enumerable.</param>
        /// <param name="action">Action called for each element.</param>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            Argument.NotNull(nameof(enumerable), enumerable);
            Argument.NotNull(nameof(action), action);

            foreach(T element in enumerable)
            {
                action(element);
            }
        }

        /// <summary>
        /// Is enumerable empty.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="enumerable">Enumerable.</param>
        /// <returns>If true then it is empty, else false.</returns>
        public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
        {
            return !enumerable.Any();
        }

        /// <summary>
        /// To string with string func.
        /// </summary>
        public static string ToString<T>(this IEnumerable<T> enumerable)
        {
            StringBuilder builder = new StringBuilder();

            foreach (T item in enumerable)
            {
                builder.Append(item.ToString());
            }

            return builder.ToString();
        }

        /// <summary>
        /// To string with string func.
        /// </summary>
        public static string ToString<T>(this IEnumerable<T> enumerable, Func<T, string> stringFunc)
        {
            StringBuilder builder = new StringBuilder();

            foreach (T item in enumerable)
            {
                builder.Append(stringFunc(item));
            }

            return builder.ToString();
        }
    }
}
