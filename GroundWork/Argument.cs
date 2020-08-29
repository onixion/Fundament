using System;

namespace GroundWork
{
    /// <summary>
    /// Argument.
    /// </summary>
    public static class Argument
    {
        /// <summary>
        /// Throws a <see cref="ArgumentNullException"/> when the given argument is null.
        /// </summary>
        /// <param name="argumentName">Name of the argument.</param>
        /// <param name="value">Value of the argument.</param>
        /// <param name="message">Optional message for the exception.</param>
        public static void NotNull(string argumentName, object value, string message = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    argumentName ?? "",
                    message ?? $"Argument {argumentName} can't be null.");
            }
        }

        /// <summary>
        /// Throws a <see cref="ArgumentException"/> when the given evaluation function return false.
        /// </summary>
        /// <typeparam name="T">Type of the argument.</typeparam>
        /// <param name="argumentName">Argument name.</param>
        /// <param name="value">Current value.</param>
        /// <param name="evaluateFunc">Evaluation function.</param>
        /// <param name="message">Optional message.</param>
        public static void Evaluate<T>(string argumentName, T value, Func<T,bool> evaluateFunc, string message = null)
        {
            if (!evaluateFunc(value))
            {
                throw new ArgumentException(
                    message ?? $"Argument {argumentName} with value {value} failed the evaluaction function.",
                    argumentName ?? "");
            }
        }
    }
}
