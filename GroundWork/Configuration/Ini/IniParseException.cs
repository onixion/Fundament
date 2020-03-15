using System;

namespace GroundWork.Configuration.Ini
{
    /// <summary>
    /// INI parse exception.
    /// </summary>
    public class IniParseException : Exception
    {
        /// <summary>
        /// Line number.
        /// </summary>
        public int LineNumber { get; }

        /// <summary>
        /// Constructor,
        /// </summary>
        /// <param name="lineNumber">Line number.</param>
        /// <param name="message">Message.</param>
        public IniParseException(int lineNumber, string message) : base(message)
        {
            LineNumber = lineNumber;
        }
    }
}
