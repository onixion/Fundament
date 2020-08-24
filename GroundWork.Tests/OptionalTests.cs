using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Groundwork.Tests
{
    /// <summary>
    /// Unit tests for <see cref="Optional"/> and <see cref="Optional{T}"/>.
    /// </summary>
    [TestClass]
    public class OptionalTests
    {
        /// <summary>
        /// Test optional without value.
        /// </summary>
        [TestMethod]
        public void Empty()
        {
            var optional = new Optional();

            Assert.AreEqual(
                expected: false, 
                actual: optional.HasValue, 
                message: "Expected optional to have no value.");

            Assert.ThrowsException<InvalidOperationException>(
                action: () => optional.Value, 
                message: "Expected to throw an InvalidOperationException.");

            Assert.AreEqual(
                expected: null,
                actual: optional.ValueOrDefault,
                message: "Expected value of optional to be null.");
        }

        /// <summary>
        /// Test generic optional without value.
        /// </summary>
        [TestMethod]
        public void EmptyGeneric()
        {
            var optional = new Optional<object>();

            Assert.AreEqual(
                expected: false, 
                actual: optional.HasValue, 
                message: "Expected optional to have no value.");

            Assert.AreEqual(
                expected: null, 
                actual: optional.ValueOrDefault, 
                message: "Expected value of optional to be 0.");
        }

        /// <summary>
        /// Test optional with value.
        /// </summary>
        [TestMethod]
        public void Value()
        {
            var obj = new object();
            var optional = new Optional(obj);

            Assert.AreEqual(
                expected: true,
                actual: optional.HasValue,
                message: "Expected optional to have a value.");

            Assert.AreEqual(
              expected: obj,
              actual: optional.ValueOrDefault,
              message: "Expected value of optional to be not null.");

            Assert.AreEqual(
                expected: obj,
                actual: optional.ValueOrDefault,
                message: "Expected value of optional to be not null.");
        }

        /// <summary>
        /// Test generic optional with value.
        /// </summary>
        [TestMethod]
        public void ValueGeneric()
        {
            var obj = new object();
            var optional = new Optional<object>(obj);

            Assert.AreEqual(
                expected: true,
                actual: optional.HasValue,
                message: "Expected optional to have a value.");

            Assert.AreEqual(
              expected: obj,
              actual: optional.ValueOrDefault,
              message: "Expected value of optional to be not null.");

            Assert.AreEqual(
                expected: obj,
                actual: optional.ValueOrDefault,
                message: "Expected value of optional to be not null.");
        }
    }
}
