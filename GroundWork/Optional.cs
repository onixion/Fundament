using GroundWork.Contracts;
using System;
using System.Diagnostics;

namespace GroundWork
{
    /// <summary>
    /// Optional.
    /// </summary>
    [DebuggerStepThrough]
    public class Optional : IOptional
    {
        /// <summary>
        /// Value.
        /// </summary>
        public object Value
        {
            get
            {
                if (value == null)
                    throw new InvalidOperationException($"Optional value missing.");

                return value;
            }
        }
        private readonly object value;

        /// <summary>
        /// Has value.
        /// </summary>
        public bool HasValue => value != null;

        /// <summary>
        /// Value or default.
        /// </summary>
        public object ValueOrDefault => HasValue ? Value : null;

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
        public Optional(object value)
        {
            this.value = value;
        }

        /// <summary>
        /// Equals.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is Optional optional)
                return Equals(optional);

            return false;
        }

        /// <summary>
        /// Equals.
        /// </summary>
        public bool Equals(Optional other)
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

        /// <summary>
        /// To string.
        /// </summary>
        public override string ToString()
        {
            return Value.ToString();
        }

        private readonly static Optional emptyOptional = new Optional();

        /// <summary>
        /// Returns empty optional.
        /// </summary>
        /// <returns>Empty optional.</returns>
        public static Optional Empty()
        {
            return emptyOptional;
        }
    }

    /// <summary>
    /// Generic optional.
    /// </summary>
    [DebuggerStepThrough]
    public class Optional<T>  : IOptional<T>
    {
        /// <summary>
        /// Value.
        /// </summary>
        public T Value
        {
            get
            {
                if (value == null)
                    throw new InvalidOperationException($"Optional value missing.");

                return value;
            }
        }
        private readonly T value;

        /// <summary>
        /// Has value.
        /// </summary>
        public bool HasValue => value != null;

        /// <summary>
        /// Value or default.
        /// </summary>
        public T ValueOrDefault => HasValue ? Value : default(T);

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
        public Optional(T value)
        {
            this.value = value;
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

        /// <summary>
        /// To string.
        /// </summary>
        public override string ToString()
        {
            return Value.ToString();
        }

        /// <summary>
        /// Returns empty optional.
        /// </summary>
        /// <returns>Empty optional.</returns>
        public static Optional<T> Empty()
        {
            return new Optional<T>();
        }
    }
}
