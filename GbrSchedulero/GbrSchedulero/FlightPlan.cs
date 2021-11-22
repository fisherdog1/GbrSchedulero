using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbrSchedulero
{
    /// <summary>
    /// Represents a flight plan, from which Flights are created, and may be recurring
    /// </summary>
    public abstract class FlightPlan
    {
        public string FlightNumber { get; private set; }
        public Airport Destination { get; private set; }
        public Airport Origin { get; private set; }
        public DateTime DepartureTime { get; private set; }
        public DateTime ArrivalTime { get; private set; }

        /// <summary>
        /// If this is a recurring flight plan, this method should return the time of the next Flight instance that will be formed from this plan.
        /// </summary>
        /// <returns></returns>
        public abstract object GetNextDeparture();
        public abstract object GetNextArrival();

        /// <summary>
        /// Total scheduled time enroute
        /// Divides plan distance by 500mph
        /// </summary>
        /// <returns></returns>
        public TimeSpan GetTotalTimeEnroute()
        {
            double distance = Origin.GetDistance(Destination);
            return TimeSpan.FromHours(distance / 500.0); //mph
        }
        
        /// <summary>
        /// Build a flight instance from this flight plan
        /// Should fail if the crew does not meet requirements.
        /// </summary>
        /// <param name="ship">The aircraft to use</param>
        /// <param name="crewmembers">The crewmembers to use</param>
        /// <returns></returns>
        public abstract Flight BuildFlight(Aircraft ship, Crewmember[] crewmembers);
    }
}
