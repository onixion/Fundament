using Groundwork.Contracts;

namespace Groundwork
{
    /// <summary>
    /// Generic extensions.
    /// </summary>
    public static class GenericExtensions
    {
        /// <summary>
        /// Wraps the given value in an optional.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <returns>Value wrapped in an optional.</returns>
        public static IOptional ToOptional(this object value)
        {
            return new Optional(value);
        }

        /// <summary>
        /// Wraps the given value in an optional.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="value">Value.</param>
        /// <returns>Value wrapped in an optional.</returns>
        public static IOptional<T> ToOptional<T>(this T value)
        {
            return new Optional<T>(value);
        }
    }
}
