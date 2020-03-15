using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GroundWork.Configuration.Ini
{
    /// <summary>
    /// INI writer.
    /// </summary>
    public class IniWriter : StreamWriter
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="stream">Stream to write to.</param>
        public IniWriter(Stream stream) : base(stream)
        {
        }

        /// <summary>
        /// Write INI configuration.
        /// </summary>
        /// <param name="configuration">INI configuration to write.</param>
        public void WriteIniConfiguration(IniConfiguration configuration)
        {
            foreach (IniSection section in configuration.Sections)
            {
                WriteLine($"[{section.Name}]");

                foreach (IniProperty property in section.Properties)
                {
                    WriteLine($"{property.Name}={property.Value}");
                }
            }
        }
    }
}
