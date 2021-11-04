using GbrSchedulero;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GbrUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(Program.TrivialTestMethod(), 1);
        }
    }
}
