using System;
using System.Collections.Generic;

namespace GroundWork.Binary
{
    /// <summary>
    /// Binary builder.
    /// </summary>
    public class BinaryBuilder : IBinaryBuilder
    {
        /// <summary>
        /// Total size of all blocks combined.
        /// </summary>
        int totalSize = 0;

        /// <summary>
        /// Binary blocks.
        /// </summary>
        readonly IList<byte[]> blocks = new List<byte[]>();

        /// <summary>
        /// Append data.
        /// </summary>
        /// <param name="data">Data.</param>
        public void Append(byte[] data)
        {
            totalSize += data.Length;
            blocks.Add(data);
        }

        /// <summary>
        /// Build.
        /// </summary>
        /// <returns>Binary data.</returns>
        public byte[] Build()
        {
            byte[] buffer = new byte[totalSize];

            int offset = 0;
            foreach(byte[] block in blocks)
            {
                Buffer.BlockCopy(block, 0, buffer, offset, block.Length);
                offset += block.Length;
            }

            return buffer;
        }
    }
}
