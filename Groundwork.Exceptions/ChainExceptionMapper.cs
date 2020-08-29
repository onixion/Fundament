using GroundWork.Contracts;
using GroundWork.Exceptions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroundWork.Exceptions
{
    /// <summary>
    /// Chain exception mapper implementation.
    /// </summary>
    /// <typeparam name="T">Type of mapped object.</typeparam>
    public class ChainExceptionMapper<T> : IExceptionMapper<T>
    {
        readonly IEnumerable<IExceptionMapper<T>> exceptionMappers;

        /// <summary>
        /// Constructor.
        /// </summary>
        public ChainExceptionMapper(IEnumerable<IExceptionMapper<T>> exceptionMappers)
        {
            Argument.NotNull(nameof(exceptionMappers), exceptionMappers);

            this.exceptionMappers = exceptionMappers.ToArray();
        }

        /// <summary>
        /// Map exception.
        /// </summary>
        /// <param name="exception">Exception to map.</param>
        /// <returns>Mapped object.</returns>
        public IOptional<T> Map(Exception exception)
        {
            Argument.NotNull(nameof(exception), exception);

            foreach (var exceptionMapper in exceptionMappers)
            {
                var mappedObject = exceptionMapper.Map(exception);

                if (mappedObject.HasValue)
                {
                    return mappedObject;
                }
            }

            return Optional<T>.Empty();
        }
    }
}
