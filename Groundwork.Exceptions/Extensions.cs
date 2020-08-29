using GroundWork.Exceptions.Contracts;
using System.Collections.Generic;

namespace GroundWork.Exceptions
{
    public static class Extensions
    {
        /// <summary>
        /// Converts to <see cref="CompositionExceptionMapper{T}"/>.
        /// </summary>
        /// <param name="exceptionMappers">Enumerable of exception mappers.</param>
        /// <returns>Composition exception mapper.</returns>
        public static CompositionExceptionMapper<T> ToCompositionExceptionMapper<T>(this IEnumerable<IExceptionMapper<T>> exceptionMappers)
        {
            return new CompositionExceptionMapper<T>(exceptionMappers);
        }
    }
}
