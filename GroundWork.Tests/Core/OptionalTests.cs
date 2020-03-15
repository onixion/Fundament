using GroundWork.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroundWork.Tests.Core
{
    /// <summary>
    /// Optional tests.
    /// </summary>
    [TestClass]
    public class OptionalTests
    {
        /// <summary>
        /// Common value.
        /// </summary>
        [TestMethod]
        public void CommonValue()
        {
            var optional = new Optional<int>(4);

            Assert.IsTrue(optional.HasValue);
            Assert.IsFalse(optional.HasNoValue);
            Assert.AreEqual(4, optional.Value);
            Assert.AreEqual(4, optional.ValueOrDefault);
        }

        /// <summary>
        /// Common no value.
        /// </summary>
        [TestMethod]
        public void CommonNoValue()
        {
            var optional = new Optional<int>();

            Assert.IsFalse(optional.HasValue);
            Assert.IsTrue(optional.HasNoValue);
            Assert.AreEqual(0, optional.ValueOrDefault);
        }
    }
}
