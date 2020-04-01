using GroundWork.Core;
using System;

namespace GroundWork.Extensions
{
    public static class GenericExtensions
    {
        /// <summary>
        /// Wraps the given value in an optional.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="value">Value.</param>
        /// <returns>Value wrapped in an optional.</returns>
        public static Optional<T> ToOptional<T>(this T value)
        {
            return new Optional<T>(value);
        }
    }
}
