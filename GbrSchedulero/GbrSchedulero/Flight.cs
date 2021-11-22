using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbrSchedulero
{
    /// <summary>
    /// Represents a single instance of a Flight, i.e. Not a recurring schedule
    /// </summary>
    public abstract class Flight
    {
        public string FlightNumber { get { return Plan.FlightNumber; } }
        public FlightPlan Plan { get; private set; }

        /// <summary>
        /// True if this flight has landed at any destination, potentially not the planned destination
        /// </summary>
        /// <returns></returns>
        public abstract bool IsComplete();

        /// <summary>
        /// True if the flight has landed at its intended destination
        /// </summary>
        /// <returns></returns>
        public abstract bool IsCompleteAsPlanned();

        /// <summary>
        /// True if this flight is in the air
        /// </summary>
        /// <returns></returns>
        public abstract bool IsEnroute();

        /// <summary>
        /// True if the flight has not left yet and is not cancelled
        /// </summary>
        /// <returns></returns>
        public abstract bool IsUpcoming();

        /// <summary>
        /// Returns the time the flight actually departed
        /// </summary>
        /// <returns></returns>
        public abstract object GetActualDepartureTime();

        /// <summary>
        /// Returns the time the flight actually arrived (at any destination, potentially different from the planned destination)
        /// </summary>
        /// <returns></returns>
        public abstract object GetActualArrivalTime();

        /// <summary>
        /// Get the current destination, which will differ from the FlightPlan destination if the aircraft diverts or returns to base
        /// </summary>
        /// <returns></returns>
        public abstract Airport GetActualDestination();

        /// <summary>
        /// Get estimated arrival time based on actual departure time
        /// </summary>
        /// <returns></returns>
        public abstract object GetEstimatedArrival();

        /// <summary>
        /// Total time enroute, based on actual departure time.
        /// If the flight has landed, it is the actual time enroute,
        /// if the flight is in the air, it is the estimated time enroute.
        /// </summary>
        /// <returns></returns>
        public abstract object GetTimeEnroute();

        public abstract Crewmember[] GetCrew();
        public abstract Aircraft GetAircraft();
    }
}
