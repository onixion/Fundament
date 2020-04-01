using System;

namespace GroundWork.Core
{
    /// <summary>
    /// Optional.
    /// </summary>
    //[DebuggerStepThrough]
    public class Optional<T> 
    {
        readonly bool hasValue;

        /// <summary>
        /// Value.
        /// </summary>
        public T Value
        {
            get
            {
                if (hasValue) return value;
                throw new InvalidOperationException($"Optional value missing.");
            }
        }
        private readonly T value;

        /// <summary>
        /// Has value.
        /// </summary>
        public bool HasValue => hasValue;

        /// <summary>
        /// Has no value.
        /// </summary>
        public bool HasNoValue
        {
            get
            {
                return !hasValue;
            }
        }

        /// <summary>
        /// Value or default.
        /// </summary>
        public T ValueOrDefault
        {
            get
            {
                return hasValue ? Value : default(T);
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Optional()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value">Value.</param>
        public Optional(T value = default)
        {
            if (value != default)
            {
                this.value = value;
                hasValue = true;
            }
        }

        /// <summary>
        /// Explicit convertion.
        /// </summary>
        public static explicit operator T(Optional<T> optional)
        {
            return optional.Value;
        }

        /// <summary>
        /// Equals.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is Optional<T> optional)
                return Equals(optional);

            return false;
        }

        /// <summary>
        /// Equals.
        /// </summary>
        public bool Equals(Optional<T> other)
        {
            if (HasValue && other.HasValue)
                return Equals(value, other.value);

            return HasValue == other.HasValue;
        }

        /// <summary>
        /// Get hash code.
        /// </summary>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
