using GroundWork.Exceptions.Contracts;
using System;

namespace GroundWork.Exceptions
{
    /// <summary>
    /// Exception mapper builder extensions.
    /// </summary>
    public static class ExceptionMapperBuilderExtensions
    {
        /// <summary>
        /// Add exception handler.
        /// </summary>
        /// <typeparam name="TException">Type of exception to handle.</typeparam>
        /// <param name="exceptionMapperBuilder">Exception mapper builder.</param>
        /// <param name="shouldHandleException">Func that checks whether or not the given exception is handled by this handler.</param>
        /// <param name="mappedObject">Mapped object.</param>
        /// <returns>Exception mapper builder.</returns>
        public static IExceptionMapperBuilder<T> AddExceptionHandler<T, TException>(
            this IExceptionMapperBuilder<T> exceptionMapperBuilder, 
            Func<TException, bool> shouldHandleException, 
            T mappedObject) where TException : Exception
        {
            return exceptionMapperBuilder.AddExceptionHandler(typeof(TException), (ex) => shouldHandleException((TException)ex), mappedObject);
        }
    }
}
