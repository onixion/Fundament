namespace GroundWork.Configuration.Ini
{
    /// <summary>
    /// INI property (name/value pair).
    /// </summary>
    public class IniProperty
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name of the property.</param>
        /// <param name="value">Value of the property.</param>
        public IniProperty(string name, string value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Equals.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (!(obj is IniProperty property))
                return false;

            if (property.Name != Name)
                return false;

            if (!property.Value.Equals(Value))
                return false;

            return true;
        }

        /// <summary>
        /// To string.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(IniProperty)}[{nameof(Name)}={Name},{nameof(Value)}={Value}]";
        }
    }
}
