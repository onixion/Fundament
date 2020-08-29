using GroundWork.Exceptions.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace GroundWork.Exceptions.Tests
{
    [TestClass]
    public class ChainExceptionErrorMapperTests
    {
        [TestMethod]
        public void Map()
        {
            var exceptionMapper = new ChainExceptionMapper<Error>(new IExceptionMapper<Error>[0]);
            var returnedError = exceptionMapper.Map(new Exception());

            Assert.IsFalse(returnedError.HasValue);
        }

        [TestMethod]
        public void Map2()
        {
            var exceptionMapperMock = new Mock<IExceptionMapper<Error>>();

            exceptionMapperMock
                .Setup(em => em.Map(It.IsAny<Exception>()))
                .Returns(Optional<Error>.Empty);

            var exceptionMapper = new ChainExceptionMapper<Error>(new IExceptionMapper<Error>[]
            {
                exceptionMapperMock.Object,
            });

            var returnedError = exceptionMapper.Map(new Exception());

            Assert.IsFalse(returnedError.HasValue);
        }

        [TestMethod]
        public void Map3()
        {
            var exceptionMapperMock = new Mock<IExceptionMapper<Error>>();

            exceptionMapperMock
                .Setup(em => em.Map(It.IsAny<Exception>()))
                .Returns(() => Optional<Error>.Empty);

            var exceptionMapper2Mock = new Mock<IExceptionMapper<Error>>();

            exceptionMapper2Mock
                .Setup(em => em.Map(It.IsAny<Exception>()))
                .Returns(new Error("Failure2").ToOptional());

            var exceptionMapper = new ChainExceptionMapper<Error>(new IExceptionMapper<Error>[]
            {
                exceptionMapperMock.Object,
                exceptionMapper2Mock.Object,
            });

            var returnedError = exceptionMapper.Map(new Exception());

            Assert.IsTrue(returnedError.HasValue);
            Assert.AreEqual("Failure2", returnedError.Value);
        }
    }
}
