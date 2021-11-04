using Microsoft.VisualStudio.TestTools.UnitTesting;
using GbrSchedulero;

namespace GbrUnitTests
{
    [TestClass]
    public class TrivialTests
    {
        [TestMethod]
        /// Example Unit Test that does nothing and should always pass.
        public void AlwaysPass()
        {
            int a = Program.TrivialTestMethod();
            Assert.AreEqual(a, 1);
        }
    }
}
