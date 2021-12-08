using CHA.Data;
using GbrSchedulero;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace GbrUnitTests
{
    [TestClass]
    public class BaseContextTest
    {
        protected DbContextOptions<FlightScheduleDbContext> ContextOptions;
        protected string ConnectionString;
        public BaseContextTest(DbContextOptions<FlightScheduleDbContext> options)
        {
            this.ContextOptions = options;

            //Get connection string for testing on production db
            IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            ConnectionString = configuration.GetConnectionString("Default");

            Seed();
        }

        /// <summary>
        /// Add required sample data to the DB. Particularly the two default aircraft types and four airports
        /// </summary>
        protected void Seed()
        {
            using (FlightScheduleDbContext context = new FlightScheduleDbContext(ContextOptions))
            {
                //Note: at the moment this keeps adding more types and aircraft each time
                //Something either in FlightScheduleDbContext or this test file needs to be changed to prevent this happening
                //These tests could also be moved to a LocalDb
                context.Add(AircraftType.GBR10());
                context.Add(AircraftType.NU150());

                List<Aircraft> testAircrafts = new TestAircraftBuilder().Generate(10);

                foreach (Aircraft ac in testAircrafts)
                    context.Add(ac);

                context.SaveChanges();
            }
        }
    }

    [TestClass]
    public class SimpleContextTest : BaseContextTest
    {
        public SimpleContextTest() 
            : base(new DbContextOptionsBuilder<FlightScheduleDbContext>()
                  //I cannot for the life of me figure out how not to repeat the connection string here
                  .UseMySQL("server=gbrschedulero.c5vcx9th6rqh.us-east-2.rds.amazonaws.com;uid=admin;pwd=PxidtU6rHzP7wwdarVhQ;database=schedulero")
                  .Options)
        {

        }

        [TestMethod]
        public void HasAircraftTypes()
        {

        }
    }
}
