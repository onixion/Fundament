using Groundwork.Contracts;
using System;

namespace Groundwork.Exceptions.Contracts
{
    /// <summary>
    /// Exception mapper interface.
    /// </summary>
    /// <typeparam name="T">Type of object to map to.</typeparam>
    public interface IExceptionMapper<T>
    {
        /// <summary>
        /// Map exception.
        /// </summary>
        /// <param name="e">Exception to map.</param>
        /// <returns>Optional mapped object.</returns>
        IOptional<T> Map(Exception e);
    }
}
