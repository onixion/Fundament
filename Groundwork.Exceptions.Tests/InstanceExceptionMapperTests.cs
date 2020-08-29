using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GroundWork.Exceptions.Tests
{
    /// <summary>
    /// Unit tests for <see cref="InstanceExceptionMapper{T}"/>
    /// </summary>
    [TestClass]
    public class InstanceExceptionMapperTests
    {
        [TestMethod]
        public void Map()
        {
            var instance = new Error("Failure");
            var errorMapper = new InstanceExceptionMapper<Error>(instance);
            var returnedInstance = errorMapper.Map(new Exception());

            Assert.IsTrue(returnedInstance.HasValue);
            Assert.AreSame(instance, returnedInstance.Value);
        }

        [TestMethod]
        public void Map2()
        {
            var instance = new Error("Failure");
            var errorMapper = new InstanceExceptionMapper<Error>(instance, () => { return false; });
            var returnedInstance = errorMapper.Map(new Exception());

            Assert.IsFalse(returnedInstance.HasValue);
        }
    }
}
