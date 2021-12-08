using GbrSchedulero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbrUnitTests
{
    /// <summary>
    /// Generates arbitrary aircraft
    /// </summary>
    class TestFlightPlanBuilder : ITestDataGenerator<FlightPlan>
    {
        private Airport[] Airports;
        public TestFlightPlanBuilder(Airport[] airports)
        {
            this.Airports = airports;
        }

        public List<FlightPlan> Generate(int count)
        {
            List<FlightPlan> plans = new List<FlightPlan>();
            Random r = new Random(1337*count);

            for (int i = 0; i < count; i++)
            {
                int ap = r.Next(Airports.Length);
                Airport origin = Airports[ap];

                int apd = (ap + r.Next(1, Airports.Length)) % Airports.Length;
                Airport destination = Airports[apd];

                string flightNumber = "CHA" + r.Next(0, 9999).ToString("d4");

                //Random day in december 2021, between 6am and 8pm.
                int day = r.Next(1,32);
                int hour = r.Next(6, 21);
                int min = r.Next(4) * 15;
                DateTime departureTime = new DateTime(2021, 12, day, hour, min, 0);

                //Arrival time based on time enroute
                DateTime arrivalTime = departureTime.Add(FlightPlan.GetTotalTimeEnroute(origin, destination));

                //Stinky
                FlightPlan plan = new FlightPlan(flightNumber, ap + 1, apd + 1, departureTime, arrivalTime);
                plans.Add(plan);
            }

            return plans;
        }
    }
}
