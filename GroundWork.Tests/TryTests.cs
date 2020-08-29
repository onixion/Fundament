using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GroundWork.Tests
{
    [TestClass]
    public class TryTests
    {
        [TestMethod]
        public void CatchIgnore()
        {
            Try.CatchIgnore(() => { });
        }

        [TestMethod]
        public void CatchIgnore2()
        {
            Try.CatchIgnore(() => throw new InvalidCastException());
        }

        [TestMethod]
        public async Task CatchIgnoreAsync()
        {
            await Try.CatchIgnoreAsync(() => Task.CompletedTask);
        }

        [TestMethod]
        public async Task CatchIgnoreAsync2()
        {
            await Try.CatchIgnoreAsync(() => throw new InvalidCastException());
        }
    }
}
