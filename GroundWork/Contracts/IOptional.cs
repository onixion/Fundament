namespace GroundWork.Contracts
{
    /// <summary>
    /// Optional interface.
    /// </summary>
    public interface IOptional
    {
        /// <summary>
        /// Gets a value indicating whether this instance has value.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has value; otherwise, <c>false</c>.
        /// </value>
        bool HasValue { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        object Value { get; }

        /// <summary>
        /// Gets the value or default.
        /// </summary>
        object ValueOrDefault { get; }
    }

    /// <summary>
    /// Optional interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IOptional<T>
    {
        /// <summary>
        /// Gets a value indicating whether this instance has value.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has value; otherwise, <c>false</c>.
        /// </value>
        bool HasValue { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        T Value { get; }

        /// <summary>
        /// Gets the value or default.
        /// </summary>
        T ValueOrDefault { get; }
    }
}
