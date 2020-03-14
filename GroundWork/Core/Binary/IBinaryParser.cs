namespace Utilinator.Core.Binary
{
    /// <summary>
    /// Interface byte array builder.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBinaryParser<T>
    {
        /// <summary>
        /// Parse from data.
        /// </summary>
        /// <param name="data">Data.</param>
        /// <returns>Parsed object.</returns>
        T Parse(byte[] data);
    }
}
