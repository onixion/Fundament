using GroundWork.Contracts;

namespace GroundWork
{
    /// <summary>
    /// Optional extensions.
    /// </summary>
    public static class OptionalExtensions
    {
        /// <summary>
        /// Determines whether the optional has no value.
        /// </summary>
        /// <typeparam name="T">Type of the optional.</typeparam>
        /// <param name="optional">The optional.</param>
        /// <returns>
        ///   <c>true</c> if optional has no value; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasNoValue<T>(this IOptional<T> optional)
        {
            return !optional.HasValue;
        }
    }
}
