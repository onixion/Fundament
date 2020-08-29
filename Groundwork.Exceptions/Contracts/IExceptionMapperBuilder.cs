namespace GroundWork.Exceptions.Contracts
{
    /// <summary>
    /// Exception mapper builder interface.
    /// </summary>
    /// <typeparam name="T">Type of object mapped to.</typeparam>
    public interface IExceptionMapperBuilder<T>
    {
        /// <summary>
        /// Add exception mapper.
        /// </summary>
        /// <param name="exceptionMapper">Exception mapper to add.</param>
        /// <returns>Exception mapper builder.</returns>
        IExceptionMapperBuilder<T> AddExceptionMapper(IExceptionMapper<T> exceptionMapper);

        /// <summary>
        /// Remove all exception mappers.
        /// </summary>
        void RemoveAllExceptionMappers();

        /// <summary>
        /// Build exception mapper.
        /// </summary>
        /// <returns>Exception mapper.</returns>
        IExceptionMapper<T> Build();
    }
}
