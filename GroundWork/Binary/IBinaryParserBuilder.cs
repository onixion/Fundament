using System;

namespace GroundWork.Binary
{
    /// <summary>
    /// Interface for binary parser builder.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBinaryParserBuilder<T>
    {
        /// <summary>
        /// Parse block.
        /// </summary>
        /// <param name="size">Size of the block.</param>
        /// <param name="parseAction">Parse action.</param>
        void AppendBlock(int size, Action<byte[], T> parseAction);

        /// <summary>
        /// Build binary parser.
        /// </summary>
        /// <returns>Binary parser.</returns>
        IBinaryParser<T> Build();
    }
}
