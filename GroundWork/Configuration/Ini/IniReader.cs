using System.Collections.Generic;
using System.IO;

namespace GroundWork.Configuration.Ini
{
    /// <summary>
    /// INI reader.
    /// </summary>
    public class IniReader : StreamReader
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="stream">Stream to read from.</param>
        public IniReader(Stream stream): base(stream)
        {
        }

        /// <summary>
        /// Read INI configuration.
        /// </summary>
        /// <returns>Configuration.</returns>
        public IniConfiguration ReadIniConfiguration()
        {
            int lineNumber = 1;
            string line;

            IList<IniSection> sections = new List<IniSection>();
            string sectionName = null;
            IList<IniProperty> properties = new List<IniProperty>();

            while ((line = ReadLine()?.Trim()) != null)
            {
                if (line.Length == 0 || line[0] == '#' || line[0] == ';')
                {
                    // ignore
                }
                else if (line[0] == '[')
                {
                    // Add previouse section to the sections.
                    if (sectionName != null)
                    {
                        sections.Add(new IniSection(sectionName, properties));
                        properties.Clear();
                    }

                    #region Read section name

                    // Section line has to be at least
                    // 3 characters long.
                    if (line.Length < 3)
                    {
                        throw new IniParseException(lineNumber,
                            $"Invalid section in line {lineNumber}: {line}");
                    }

                    // Check characters for the section.
                    if (line[0] != '[' || line[line.Length - 1] != ']')
                    {
                        throw new IniParseException(lineNumber,
                            $"Invalid section in line { lineNumber }: { line}");
                    }

                    // Retrieve section name.
                    sectionName = line.Substring(1, line.Length - 2);

                    #endregion
                }
                else
                {
                    if (sectionName == null)
                    {
                        throw new IniParseException(lineNumber,
                            $"Expected section name in line { lineNumber }: { line}");
                    }

                    var property = ReadProperty(line, lineNumber);
                    properties.Add(property);
                }

                lineNumber++;
            }

            if (sectionName == null)
            {
                throw new IniParseException(lineNumber,
                    $"Expected section name in line { lineNumber }: { line}");
            }

            sections.Add(new IniSection(sectionName, properties));
            return new IniConfiguration(sections);
        }

        /// <summary>
        /// Read property.
        /// </summary>
        /// <param name="line">Line to read a property from.</param>
        /// <param name="lineNumber">Line number.</param>
        /// <returns>Property.</returns>
        IniProperty ReadProperty(string line, int lineNumber)
        {
            string[] keyValue = line.Split('=');

            if (keyValue.Length != 2)
            {
                throw new IniParseException(lineNumber,
                    $"Invalid key/value pair in line { lineNumber }: { line}");
            }

            return new IniProperty(keyValue[0].Trim(), keyValue[1].Trim());
        }
    }
}
