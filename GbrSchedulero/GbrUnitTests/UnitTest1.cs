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

        [TestMethod]
        public void DatabaseConnTest()
        {
            string user = System.Environment.GetEnvironmentVariable("DB_SECRET");
            int result = Program.DatabaseConnTest(user);
            Assert.AreEqual(result, 1);
        }
    }
}
