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
                //This is very slow
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //These tests could also be moved to a LocalDb

                AircraftType[] types = AircraftType.AllTypes();
                context.AddRange(types);

                Airport[] airports = Airport.AllAirports();
                context.AddRange(airports);

                List<Aircraft> testAircrafts = new TestAircraftBuilder(types).Generate(10);
                context.AddRange(testAircrafts);

                List<Crewmember> testCrewmembers = new TestCrewBuilder(AircraftType.AllTypes()).Generate(30);
                context.AddRange(testCrewmembers);

                List<FlightPlan> testPlans = new TestFlightPlanBuilder(airports).Generate(5);
                context.AddRange(testPlans);

                //Add a test flight, almost certainly not valid
                //This process should be abstracted to ensure the correct processing of change orders
                Flight testFlight = new Flight(testPlans[0], testAircrafts[0], 20);
                AssignmentChangeOrder aso1 = testFlight.AssignCrewmember(testCrewmembers[0]);
                AssignmentChangeOrder aso2 = testFlight.AssignCrewmember(testCrewmembers[1]);
                AssignmentChangeOrder aso3 = testFlight.AssignCrewmember(testCrewmembers[2]);
                context.Add(testFlight);
                context.Add(aso1);
                context.Add(aso2);
                context.Add(aso3);
                context.SaveChanges();

                //Change the flight
                testFlight.Passengers += 10;
                context.Update(testFlight);

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
            //TODO
        }
    }
}
