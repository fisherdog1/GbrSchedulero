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
    public class FlightPlan
    {
        //Primary Key
        public int FlightPlanID { get; set; }
        public string FlightNumber { get; private set; }
        public DateTime DepartureTime { get; private set; }
        public DateTime ArrivalTime { get; private set; }

        public int DestinationID { get; set; }
        public int OriginID { get; set; }

        //Navigation Properties
        public Airport Destination { get; private set; }
        public Airport Origin { get; private set; }

        public FlightPlan(string flightNumber, int originId, int destinationId, DateTime departureTime, DateTime arrivalTime)
        {
            if (originId == destinationId)
                throw new Exception("Origin and Destination airport cannot be the same.");

            this.FlightNumber = flightNumber;
            this.OriginID = originId;
            this.DestinationID = destinationId;
            this.DepartureTime = departureTime;
            this.ArrivalTime = arrivalTime;
        }

        public FlightPlan()
        {

        }

        /// <summary>
        /// If this is a recurring flight plan, this method should return the time of the next Flight instance that will be formed from this plan.
        /// </summary>
        /// <returns></returns>
        //public abstract object GetNextDeparture();
        //public abstract object GetNextArrival();

        /// <summary>
        /// Total scheduled time enroute
        /// Divides plan distance by 500mph
        /// </summary>
        /// <returns></returns>
        public TimeSpan GetTotalTimeEnroute()
        {
            return GetTotalTimeEnroute(Origin, Destination);
        }
        
        public static TimeSpan GetTotalTimeEnroute(Airport a, Airport b)
        {
            double distance = a.GetDistance(b);
            return TimeSpan.FromHours(distance / 500.0); //mph
        }

        /// <summary>
        /// Build a flight instance from this flight plan
        /// Should fail if the crew does not meet requirements.
        /// </summary>
        /// <param name="ship">The aircraft to use</param>
        /// <param name="crewmembers">The crewmembers to use</param>
        /// <returns></returns>
        //public abstract Flight BuildFlight(Aircraft ship, Crewmember[] crewmembers);

        public override string ToString()
        {
            return $"{Origin} -> {Destination}: {DepartureTime.TimeOfDay} ({ArrivalTime.TimeOfDay})";
        }
    }
}
