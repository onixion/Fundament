namespace GroundWork.Binary
{
    /// <summary>
    /// Interface binary builder.
    /// </summary>
    public interface IBinaryBuilder
    {
        /// <summary>
        /// Append binary data.
        /// </summary>
        /// <param name="data">Binary data.</param>
        void Append(byte[] data);

        /// <summary>
        /// Build binary data.
        /// </summary>
        /// <returns>Byte array.</returns>
        byte[] Build();
    }
}
