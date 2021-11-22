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
        public Airport Destination { get; private set; }
        public Airport Origin { get; private set; }



        public abstract string GetFlightNumber();
        public abstract object GetNextDeparture();
        public abstract object GetNextArrival();
        public abstract object GetScheduledDepartureTime();
        public abstract object GetScheduledArrivalTime();

        /// <summary>
        /// Total scheduled time enroute
        /// Divides plan distance by 500mph
        /// </summary>
        /// <returns></returns>
        public abstract object GetTotalTimeEnroute();
        
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
