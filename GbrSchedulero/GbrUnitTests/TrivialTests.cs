using GbrSchedulero;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System;
using System.Collections.Generic;
using MySqlConnector;

namespace GbrUnitTests
{
    [TestClass]
    public class TrivialTests
    {
        public IConfigurationRoot? Configuration;
        public string connectionString;

        [TestInitialize]
        public void TestInit()
        {
            IConfigurationBuilder config = new ConfigurationBuilder()
                .AddUserSecrets<TrivialTests>();

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
            int result = Program.DatabaseConnTest(this.connectionString);
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Does nothing yet, but allows one to see how test crews are generated.
        /// </summary>
        [TestMethod]
        public void TestCrewNames()
        {
            TestCrewBuilder tcb = new TestCrewBuilder(AircraftType.AllTypes());
            List<Crewmember> exampleCrew = tcb.Generate(50);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestAircraftGen()
        {
            TestAircraftBuilder tab = new TestAircraftBuilder(AircraftType.AllTypes());
            List<Aircraft> acs = tab.Generate(50);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestFlightPlanGen()
        {
            Airport[] airports = Airport.AllAirports();
            TestFlightPlanBuilder tab = new TestFlightPlanBuilder(airports);
            List<FlightPlan> acs = tab.Generate(50);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestDataPull()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                }
                catch (MySqlException e)
                {
                    throw new Exception("DATABASE NOT CONNECTED", e);
                }

                MySqlCommand cmd = new MySqlCommand("Select * from Test;", connection);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[0] + ", ");
                        Console.Write(reader[1]);
                    }
                }
            }
        }
    }
}
