using System;

namespace Groundwork.Exceptions.Contracts
{
    /// <summary>
    /// Exception mapper builder interface.
    /// </summary>
    /// <typeparam name="T">Type of object mapped to.</typeparam>
    public interface IExceptionMapperBuilder<T>
    {
        /// <summary>
        /// Add exception handler.
        /// </summary>
        /// <param name="exceptionType">Exception type to handle.</param>
        /// <param name="shouldHandleException">Func that checks whether or not the given exception is handled by this handler.</param>
        /// <param name="mappedObject">Mapped object.</param>
        /// <returns>Exception mapper builder.</returns>
        IExceptionMapperBuilder<T> AddExceptionHandler(Type exceptionType, Func<Exception, bool> shouldHandleException, T mappedObject);

        /// <summary>
        /// Clears the exception handlers.
        /// </summary>
        void ClearExceptionHandlers();

        /// <summary>
        /// Build exception mapper.
        /// </summary>
        /// <returns>Exception mapper.</returns>
        IExceptionMapper<T> Build();
    }
}
