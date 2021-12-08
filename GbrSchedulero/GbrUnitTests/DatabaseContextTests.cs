using CHA.Data;
using GbrSchedulero;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GbrUnitTests
{
    [TestClass]
    public class DatabaseContextTests
    {
        /// <summary>
        /// checks that Equals method returns true when two aircrafts have the same registration data
        /// </summary>
        [TestMethod]
        public void TestDatabaseContextAuto()
        {
            using (DbContext context = new FlightScheduleDbContext())
            {
                List<Aircraft> testAircrafts = new TestAircraftBuilder().Generate(10);

                foreach (Aircraft ac in testAircrafts)
                    context.Add(ac);

                context.SaveChanges();
            }
        }
    }
}
