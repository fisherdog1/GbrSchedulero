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
    class TestFlightPlanBuilder
    {
        public List<FlightPlan> GeneratePlans()
        {
            List<FlightPlan> plans = new List<FlightPlan>();

            Airport[] airports = Airport.AllAirports();

            Random r = new Random(1337);

            for (int i = 0; i < 17; i++)
            {
                int ap = r.Next(airports.Length);
                Airport origin = airports[ap];

                int apd = (ap + r.Next(1, airports.Length)) % airports.Length;
                Airport destination = airports[apd];

                string flightNumber = "CHA" + r.Next(0, 9999).ToString("d4");

                //Random day in december 2021, between 6am and 8pm.
                int day = r.Next(1,32);
                int hour = r.Next(6, 21);
                int min = r.Next(4) * 15;
                DateTime departureTime = new DateTime(2021, 12, day, hour, min, 0);

                //Arrival time based on time enroute
                DateTime arrivalTime = departureTime.Add(FlightPlan.GetTotalTimeEnroute(origin, destination));

                FlightPlan plan = new FlightPlan(flightNumber, origin, destination, departureTime, arrivalTime);
                plans.Add(plan);
            }

            return plans;
        }
    }
}
