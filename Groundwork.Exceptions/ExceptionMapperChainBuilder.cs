using Groundwork.Exceptions.Contracts;
using System.Collections.Generic;

namespace Groundwork.Exceptions
{
    /// <summary>
    /// Exception mapper chain builder.
    /// </summary>
    /// <typeparam name="T">Type of mapped object.</typeparam>
    public class ExceptionMapperChainBuilder<T> : IExceptionMapperChainBuilder<T>
    {
        private readonly IList<IExceptionMapper<T>> exceptionMappers = new List<IExceptionMapper<T>>();

        /// <summary>
        /// Add exception mapper to the chain.
        /// </summary>
        /// <param name="exceptionMapper">Exception mapper to add.</param>
        /// <returns>Exception mapper chain builder.</returns>
        public IExceptionMapperChainBuilder<T> AddExceptionMapper(IExceptionMapper<T> exceptionMapper)
        {
            exceptionMappers.Add(exceptionMapper);
            return this;
        }

        /// <summary>
        /// Clears the exception mappers.
        /// </summary>
        public void ClearExceptionMappers()
        {
            exceptionMappers.Clear();
        }

        /// <summary>
        /// Build exception mapper chain.
        /// </summary>
        /// <returns>Exception mapper.</returns>
        public IExceptionMapper<T> Build()
        {
            return new ExceptionMapperChain<T>(exceptionMappers);
        }
    }
}
