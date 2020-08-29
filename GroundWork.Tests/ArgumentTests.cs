using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GroundWork.Tests
{
    /// <summary>
    /// Unit tests for <see cref="Argument"/>.
    /// </summary>
    [TestClass]
    public class ArgumentTests
    {
        /// <summary>
        /// Test NotNull method.
        /// </summary>
        [TestMethod]
        public void NotNull()
        {
            Argument.NotNull("TestName", new object());
        }

        /// <summary>
        /// Test NotNull method.
        /// </summary>
        [TestMethod]
        public void NotNull2()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Argument.NotNull("TestName", null));
        }

        /// <summary>
        /// Test Evaluate method.
        /// </summary>
        [TestMethod]
        public void Evaluate()
        {
            Argument.Evaluate("TestName", "Test", str => str == "Test");
        }

        /// <summary>
        /// Test Evaluate method.
        /// </summary>
        [TestMethod]
        public void Evaluate2()
        {
            Assert.ThrowsException<ArgumentException>(() => Argument.Evaluate("TestName", "Test", _ => false));
        }
    }
}
