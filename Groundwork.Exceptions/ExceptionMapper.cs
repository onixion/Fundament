using Groundwork.Contracts;
using Groundwork.Exceptions.Contracts;
using System;

namespace Groundwork.Exceptions
{
    /// <summary>
    /// Exception mapper implementation.
    /// </summary>
    /// <typeparam name="T">Type of mapped object.</typeparam>
    public class ExceptionMapper<T> : IExceptionMapper<T>
    {


        /// <summary>
        /// Map exception.
        /// </summary>
        /// <param name="e">Exception to map.</param>
        /// <returns>Mapped object.</returns>
        public IOptional<T> Map(Exception e)
        {
            return null;
        }
    }
}
