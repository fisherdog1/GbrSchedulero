using GbrSchedulero;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System;

namespace GbrUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        public IConfigurationRoot? Configuration;
        public string connectionString;

        [TestInitialize]
        public void TestInit()
        {
            IConfigurationBuilder config = new ConfigurationBuilder()
                .AddUserSecrets<UnitTest1>();

            this.Configuration = config.Build();

            //Use user secret database password
            this.connectionString = Configuration["DB_CS_TEST"];

            if (string.IsNullOrEmpty(this.connectionString))
            {
                //Use environment variable secret, passed by Github Action
                this.connectionString = System.Environment.GetEnvironmentVariable("DB_CS_TEST");
                if (string.IsNullOrEmpty(this.connectionString))
                    Console.WriteLine("DB_CS_TEST not found. If testing locally, you must set the DB_CS_TEST user secret for this project.");
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(Program.TrivialTestMethod(), 1);
        }

        [TestMethod]
        public void DatabaseConnTest()
        {
            Console.WriteLine("Connection String: " + this.connectionString);
            int result = Program.DatabaseConnTest(this.connectionString);
            Assert.AreEqual(1, result);
        }
    }
}
