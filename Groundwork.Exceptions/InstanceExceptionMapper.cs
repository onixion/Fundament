using GroundWork.Contracts;
using GroundWork.Exceptions.Contracts;
using System;

namespace GroundWork.Exceptions
{
    /// <summary>
    /// Instance exception mapper.
    /// </summary>
    /// <typeparam name="T">Type of mapped object.</typeparam>
    /// <seealso cref="IExceptionMapper{T}" />
    public class InstanceExceptionMapper<T> : IExceptionMapper<T>
    {
        readonly T mappedObject;
        readonly Func<bool> funcCanMapException;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mappedObject">The mapped object.</param>
        /// <param name="funcCanMapException">The can map exception function.</param>
        public InstanceExceptionMapper(T mappedObject, Func<bool> funcCanMapException = null)
        {
            Argument.NotNull(nameof(mappedObject), mappedObject);

            this.mappedObject = mappedObject;
            this.funcCanMapException = funcCanMapException ?? new Func<bool>(() => true);
        }

        /// <summary>
        /// Map exception.
        /// </summary>
        /// <param name="exception">Exception to map.</param>
        /// <returns>Optional mapped object.</returns>
        public IOptional<T> Map(Exception exception)
        {
            if (funcCanMapException())
            {
                return mappedObject.ToOptional();
            }
            else
            {
                return Optional<T>.Empty();
            }
        }
    }
}
