using GroundWork.Contracts;
using GroundWork.Exceptions.Contracts;
using System;

namespace GroundWork.Exceptions
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
