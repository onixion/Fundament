using GroundWork.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GroundWork.Tests.Core
{
    /// <summary>
    /// Try tests.
    /// </summary>
    [TestClass]
    public class TryTests
    {
        /// <summary>
        /// Try ignore.
        /// </summary>
        [TestMethod]
        public void TryIgnore()
        {
            Try.CatchIgnore(() => throw new TestException());
            Try.CatchIgnore(() => { });
        }

        /// <summary>
        /// Try catch.
        /// </summary>
        [TestMethod]
        public void TryCatch()
        {
            Try.Catch(
                () => throw new TestException(), 
                ex => Assert.IsInstanceOfType(ex, typeof(TestException)));

            Try.Catch(
                () => { },
                ex => throw new AssertFailedException($"Expected that the catch func is not called."));
        }

        /// <summary>
        /// Try catch specific exception.
        /// </summary>
        [TestMethod]
        public void TryCatchException()
        {
            Try.Catch<TestException>(
                () => throw new TestException(),
                ex => Assert.IsInstanceOfType(ex, typeof(TestException)));

            try
            {
                Try.Catch<Test2Exception>(
                    () => throw new TestException(),
                    ex => throw new AssertFailedException($"Expected that the catch func is not called."));
            }
            catch(TestException)
            {
                // ignore
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
