using System;

namespace Utilinator.Core
{
    /// <summary>
    /// Argument.
    /// </summary>
    public static class Argument
    {
        /// <summary>
        /// Throw <see cref="ArgumentNullException"/> when given argument is null.
        /// </summary>
        /// <param name="argumentName">Name of the argument.</param>
        /// <param name="value">Value of the argument.</param>
        /// <param name="message">Optional message for the exception.</param>
        public static void NotNull(string argumentName, object value, string message = null)
        {
            if (value == null)
                throw new ArgumentNullException(argumentName,
                    message ?? $"Argument {argumentName} can't be null.");
        }
    }
}
