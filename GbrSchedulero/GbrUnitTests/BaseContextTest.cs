using CHA.Data;
using GbrSchedulero;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GbrUnitTests
{
    [TestClass]
    public class BaseContextTest
    {
        protected DbContextOptions<FlightScheduleDbContext> ContextOptions;
        protected string ConnectionString;
        public BaseContextTest()
        {
            //Get connection string for testing on production db
            IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            ConnectionString = configuration.GetConnectionString("Default");

            this.ContextOptions = new DbContextOptionsBuilder<FlightScheduleDbContext>()
              .UseMySQL(ConnectionString)
              .Options;

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
                //Add an extra qual to one crewmember for testing (Captain NU150)
                testCrewmembers[0].AddQualification(new CrewQualification(StationType.Captain, types[0]));
                context.AddRange(testCrewmembers);

                List<FlightPlan> testPlans = new TestFlightPlanBuilder(airports).Generate(5);
                context.AddRange(testPlans);

                ChangeOrderProvider provider = new ChangeOrderProvider(context);

                //Add a test flight, almost certainly not valid
                //This process should be abstracted to ensure the correct processing of change orders
                Flight testFlight = new Flight(testPlans[0], testAircrafts[0], 20);
                testFlight.AssignCrewmember(provider, testCrewmembers[0]);
                //testFlight.AssignCrewmember(provider, testCrewmembers[1]);
                //testFlight.AssignCrewmember(provider, testCrewmembers[2]);
                context.Add(testFlight);
                context.SaveChanges();

                //Change the flight
                testFlight = context.Flights.Where(a => a.FlightID == 1).Single();
                testFlight.RemoveCrewmember(provider, testCrewmembers[0]);
                testFlight.AssignCrewmember(provider, testCrewmembers[3]);
                //testFlight.RemoveCrewmember(provider, testCrewmembers[0]);
                context.Update(testFlight);

                context.SaveChanges();

                Crewmember crewmember = context.Crewmembers.Where<Crewmember>(c => c.CrewmemberID == 1).FirstOrDefault();
            }
        }
    }

    [TestClass]
    public class SimpleContextTest : BaseContextTest
    {
        public SimpleContextTest()
        {
            
        }

        [TestMethod]
        public void HasTwoAircraftTypes()
        {
            //Check if the database contains two aircraft types
            using (FlightScheduleDbContext context = new FlightScheduleDbContext(ContextOptions))
            {
                IQueryable<AircraftType> a = context.AircraftTypes.Where(ac => true);
                Assert.AreEqual(a.Count(), 2);
            }
        }
    }
}
