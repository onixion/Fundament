using GroundWork.Contracts;
using GroundWork.Exceptions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroundWork.Exceptions
{
    /// <summary>
    /// Exception mapper chain implementation.
    /// </summary>
    /// <typeparam name="T">Type of mapped object.</typeparam>
    public class ExceptionMapperChain<T> : IExceptionMapper<T>
    {
        private readonly IEnumerable<IExceptionMapper<T>> exceptionMappers;

        /// <summary>
        /// Constructor.
        /// </summary>
        public ExceptionMapperChain(IEnumerable<IExceptionMapper<T>> exceptionMappers)
        {
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
                var optionalMappedObject = exceptionMapper.Map(e);

                if (optionalMappedObject.HasValue)
                    return optionalMappedObject;
            }

            return new Optional<T>();
        }
    }
}
