using GroundWork.Contracts;
using GroundWork.Exceptions.Contracts;
using System;
using System.Collections.Generic;

namespace GroundWork.Exceptions
{
    /// <summary>
    /// Extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Converts to <see cref="IExceptionMapper{T}"/>.
        /// </summary>
        /// <param name="exceptionMappers">Enumerable of exception mappers.</param>
        /// <returns>Exception mapper.</returns>
        public static IExceptionMapper<T> ToExceptionMapper<T>(this IEnumerable<IExceptionMapper<T>> exceptionMappers)
        {
            return new ChainExceptionMapper<T>(exceptionMappers);
        }

        /// <summary>
        /// Converts to <see cref="IExceptionMapper{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcExceptionMapper">The exception mapper function.</param>
        /// <returns>Exception mapper.</returns>
        public static IExceptionMapper<T> ToExceptionMapper<T>(this Func<Exception, IOptional<T>> funcExceptionMapper)
        {
            return new FunctionalExceptionMapper<T>(funcExceptionMapper);
        }
    }
}
