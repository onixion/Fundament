using GroundWork.Contracts;
using GroundWork.Exceptions.Contracts;
using System;

namespace GroundWork.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="IExceptionMapper{T}" />
    public class FunctionalExceptionMapper<T> : IExceptionMapper<T>
    {
        readonly Func<Exception, IOptional<T>> funcExceptionToMappedObject;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="funcExceptionToMappedObject">The function that maps the exception to the optional mapped object.</param>
        public FunctionalExceptionMapper(Func<Exception, IOptional<T>> funcExceptionToMappedObject)
        {
            this.funcExceptionToMappedObject = funcExceptionToMappedObject;
        }

        /// <summary>
        /// Map exception.
        /// </summary>
        /// <param name="e">Exception to map.</param>
        /// <returns>Optional mapped object.</returns>
        public IOptional<T> Map(Exception e)
        {
            return funcExceptionToMappedObject(e);
        }
    }
}
