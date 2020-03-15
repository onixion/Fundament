using System.IO;
using System.Reflection;

namespace GroundWork.Tests
{
    /// <summary>
    /// Embedded resource helper.
    /// </summary>
    public static class EmbeddedResourceHelper
    {
        /// <summary>
        /// Get resource stream.
        /// </summary>
        /// <param name="path">Path to the resource.</param>
        /// <returns>Stream.</returns>
        public static Stream GetResourceStream(string path)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(path);

            if (stream == null)
                throw new FileNotFoundException($"Embedded resource not found: {path}.");

            return stream;
        }
    }
}
