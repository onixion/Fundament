using Groundwork.Exceptions.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Groundwork.Exceptions
{
    /// <summary>
    /// Exception mapper builder implementation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExceptionMapperBuilder<T> : IExceptionMapperBuilder<T>
    {
        private readonly IDictionary<Type, IList<Holder>> typeToHolders = new Dictionary<Type, IList<Holder>>();

        /// <summary>
        /// Add exception handler.
        /// </summary>
        /// <param name="exceptionType">Type of exception to handle.</param>
        /// <param name="shouldHandleException">Func that checks whether or not the given exception is handled by this handler.</param>
        /// <param name="mappedObject">Mapped object.</param>
        /// <returns>Exception mapper builder.</returns>
        public IExceptionMapperBuilder<T> AddExceptionHandler(Type exceptionType, Func<Exception, bool> shouldHandleException, T mappedObject)
        {
            var holder = new Holder()
            {
                ShouldHandleException = shouldHandleException,
                MappedObject = mappedObject,
            };

            if (!typeToHolders.TryGetValue(exceptionType, out IList<Holder> holders))
            {
                typeToHolders.Add(exceptionType, new List<Holder>() { holder });
            }
            else
            {
                holders.Add(holder);
            }

            return this;
        }

        /// <summary>
        /// Clears the exception handlers.
        /// </summary>
        public void ClearExceptionHandlers()
        {
            typeToHolders.Clear();
        }

        /// <summary>
        /// Build exception mapper.
        /// </summary>
        /// <returns>Exception mapper.</returns>
        public IExceptionMapper<T> Build()
        {
            return new ExceptionMapper<T>()
        }


        class Holder
        {
            public Func<Exception, bool> ShouldHandleException { get; set; }

            public T MappedObject { get; set; }
        }
    }
}
