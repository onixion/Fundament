using GroundWork.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GroundWork.Tests.Core
{
    /// <summary>
    /// Argument tests.
    /// </summary>
    [TestClass]
    public class ArgumentTests
    {
        /// <summary>
        /// Common <see cref="Argument.NotNull(string, object, string)"/> positive test.
        /// </summary>
        [TestMethod]
        public void NotNullPositive()
        {
            Argument.NotNull("test", new object());
        }

        /// <summary>
        /// Common <see cref="Argument.NotNull(string, object, string)"/> negative test.
        /// </summary>
        [TestMethod]
        public void NotNullNegative()
        {
            try
            {
                Argument.NotNull("test", null);
                throw new AssertFailedException($"Expected to throw an 'ArgumentNullException' exception.");
            }
            catch(ArgumentNullException)
            {
                // ignore
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Common <see cref="Argument.Evaluate{T}(string, T, Func{T, bool}, string)"/> positive test.
        /// </summary>
        [TestMethod]
        public void EvaluationPositive()
        {
            Argument.Evaluate("Test", 3, number => number < 10);
        }

        /// <summary>
        /// Common <see cref="Argument.Evaluate{T}(string, T, Func{T, bool}, string)"/> negative test.
        /// </summary>
        [TestMethod]
        public void EvaluationNegative()
        {
            try
            {
                Argument.Evaluate("Test", 12, number => number < 10);
                throw new AssertFailedException($"Expected to throw an 'ArgumentException' exception.");
            }
            catch (ArgumentException)
            {
                // ignore
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
