using System.Collections.Generic;
using System.Linq;

namespace GroundWork.Configuration.Ini
{
    /// <summary>
    /// INI configuration.
    /// </summary>
    public class IniConfiguration
    {
        /// <summary>
        /// Sections.
        /// </summary>
        public IEnumerable<IniSection> Sections { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sections">Sections.</param>
        public IniConfiguration(IEnumerable<IniSection> sections)
        {
            Sections = sections.ToArray();
        }

        /// <summary>
        /// To string.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(IniConfiguration)}[{nameof(Sections)}={Sections?.Count()}";
        }
    }
}
