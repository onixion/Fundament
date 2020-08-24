namespace Groundwork.Exceptions.Contracts
{
    /// <summary>
    /// Exception mapper chain interface.
    /// </summary>
    /// <typeparam name="T">Type of object to map to.</typeparam>
    public interface IExceptionMapperChainBuilder<T>
    {
        /// <summary>
        /// Add exception mapper to the chain.
        /// </summary>
        /// <param name="exceptionMapper">Exception mapper to add.</param>
        /// <returns>Exception mapper chain builder.</returns>
        IExceptionMapperChainBuilder<T> AddExceptionMapper(IExceptionMapper<T> exceptionMapper);

        /// <summary>
        /// Clears the exception mappers.
        /// </summary>
        void ClearExceptionMappers();

        /// <summary>
        /// Build exception mapper chain.
        /// </summary>
        /// <returns>Exception mapper.</returns>
        IExceptionMapper<T> Build();
    }
}
