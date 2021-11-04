using GbrSchedulero;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace GbrUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        public IConfigurationRoot? Configuration;

        [TestInitialize]
        public void TestInit()
        {
            IConfigurationBuilder config = new ConfigurationBuilder()
                .AddUserSecrets<UnitTest1>();

            this.Configuration = config.Build();
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(Program.TrivialTestMethod(), 1);
        }

        [TestMethod]
        public void DatabaseConnTest()
        {
            string user = System.Environment.GetEnvironmentVariable("DB_SECRET");

            if (string.IsNullOrEmpty(user))
            {
                user = Configuration["DB_SECRET"];

                if (string.IsNullOrEmpty(user))
                    throw new System.Exception("DB_SECRET not found!");
            }

            int result = Program.DatabaseConnTest(user);
            Assert.AreEqual(result, 1);
        }
    }
}
