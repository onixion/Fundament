using GroundWork.Contracts;
using GroundWork.Exceptions.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GroundWork.Exceptions
{
    /// <summary>
    /// Exception mapper implementation.
    /// </summary>
    /// <typeparam name="T">Type of mapped object.</typeparam>
    public class CompositionExceptionMapper<T> : IExceptionMapper<T>
    {
        readonly IEnumerable<IExceptionMapper<T>> exceptionMappers;

        /// <summary>
        /// Constructor.
        /// </summary>
        public CompositionExceptionMapper(IEnumerable<IExceptionMapper<T>> exceptionMappers)
        {
            Argument.NotNull(nameof(exceptionMappers), exceptionMappers);

            this.exceptionMappers = exceptionMappers.ToArray();
        }

        /// <summary>
        /// Map exception.
        /// </summary>
        /// <param name="e">Exception to map.</param>
        /// <returns>Mapped object.</returns>
        public IOptional<T> Map(Exception e)
        {
            foreach(var exceptionMapper in exceptionMappers)
            {
                var mappedObject = exceptionMapper.Map(e);

                if (mappedObject.HasValue)
                    return mappedObject;
            }

            return Optional<T>.Empty();
        }
    }
}
