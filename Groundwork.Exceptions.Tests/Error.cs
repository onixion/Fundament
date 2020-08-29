using System;
using System.Collections.Generic;
using System.Text;

namespace GroundWork.Exceptions.Tests
{
    /// <summary>
    /// Error class used for testing.
    /// </summary>
    internal class Error
    {
        /// <summary>
        /// The message.
        public string Message { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">The message.</param>
        public Error(string message)
        {
            Message = message;
        }
    }
}
