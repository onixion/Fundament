using GroundWork.Core;
using System.Collections.Generic;
using System.Linq;

namespace GroundWork.Configuration.Ini
{
    /// <summary>
    /// INI section.
    /// </summary>
    public class IniSection
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Properties.
        /// </summary>
        public IEnumerable<IniProperty> Properties { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="namee">Name of the section.</param>
        /// <param name="properties">Properties.</param>
        public IniSection(string name, IEnumerable<IniProperty> properties)
        {
            Argument.NotNull(nameof(name), name);
            Argument.NotNull(nameof(properties), properties);

            Name = name;
            Properties = properties.ToArray();
        }

        /// <summary>
        /// Equals.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (!(obj is IniSection section))
                return false;

            if (section.Name != Name)
                return false;

            if (!section.Properties.Equals(Properties))
                return false;

            return true;
        }

        /// <summary>
        /// To string.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(IniSection)}[{nameof(Name)}={Name}]";
        }
    }
}
