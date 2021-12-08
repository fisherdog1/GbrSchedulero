using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbrSchedulero
{
    /// <summary>
    /// Represents a single instance of a Flight, i.e. Not a recurring schedule
    /// 
    /// Changing crew assignment to a flight must be done with the provided methods, and the 
    /// AssignmentChangeOrders returned must be saved to the database
    /// </summary>
    public class Flight
    {
        //Primary Key
        public int FlightID { get; set; } //This is not the flight number.
        public int Passengers { get; set; }

        //Navigation
        public Aircraft Ship { get; set; }
        public FlightPlan Plan { get; set; }
        public List<FlightCrewAssignment> Crewmembers { get; set; }

        public Flight(FlightPlan plan, Aircraft ac, int passengers)
        {
            this.Plan = plan;
            this.Ship = ac;
            this.Passengers = passengers;
            this.Crewmembers = new List<FlightCrewAssignment>();


            //Check if crew is suitable. (Extra crewmembers are placed in passenger seats?)
            //throw new NotImplementedException("Flight class unfinished.");
        }

        private Flight()
        {

        }

        /// <summary>
        /// Assigns the specified crewmember to this flight, and returns a change order which must be saved to the database
        /// </summary>
        /// <param name="crewmember"></param>
        /// <returns></returns>
        public AssignmentChangeOrder AssignCrewmember(Crewmember crewmember)
        {
            FlightCrewAssignment newAssignment = new FlightCrewAssignment(this, crewmember);
            this.Crewmembers.Add(newAssignment);

            //TODO: Look up previous assignment, this will surely require some dependency injection

            //Now is temporary, could be different value provided
            AssignmentChangeOrder changeOrder = new AssignmentChangeOrder(null, newAssignment, DateTime.Now);

            return changeOrder;
        }

        /// <summary>
        /// Unassign the provided crewmember, returns null if no such crewmember, returns a change order otherwise.
        /// </summary>
        /// <param name="crewmember"></param>
        /// <returns></returns>
        public AssignmentChangeOrder RemoveCrewmember(Crewmember crewmember)
        {
            FlightCrewAssignment currentAssignment = null;

            foreach (FlightCrewAssignment assignment in Crewmembers)
                if (assignment.Crewmember.CrewmemberID == crewmember.CrewmemberID)
                    currentAssignment = assignment;

            if (currentAssignment == null)
                return null;

            AssignmentChangeOrder changeOrder = new AssignmentChangeOrder(currentAssignment, null, DateTime.Now);
            return changeOrder;
        }

        /// <summary>
        /// True if this flight has landed at any destination, potentially not the planned destination
        /// </summary>
        /// <returns></returns>
        //public abstract bool IsComplete();

        /// <summary>
        /// True if the flight has landed at its intended destination
        /// </summary>
        /// <returns></returns>
        //public abstract bool IsCompleteAsPlanned();

        /// <summary>
        /// True if this flight is in the air
        /// </summary>
        /// <returns></returns>
        //public abstract bool IsEnroute();

        /// <summary>
        /// True if the flight has not left yet and is not cancelled
        /// </summary>
        /// <returns></returns>
        //public abstract bool IsUpcoming();

        /// <summary>
        /// Returns the time the flight actually departed
        /// </summary>
        /// <returns></returns>
        //public abstract object GetActualDepartureTime();

        /// <summary>
        /// Returns the time the flight actually arrived (at any destination, potentially different from the planned destination)
        /// </summary>
        /// <returns></returns>
        //public abstract object GetActualArrivalTime();

        /// <summary>
        /// Get the current destination, which will differ from the FlightPlan destination if the aircraft diverts or returns to base
        /// </summary>
        /// <returns></returns>
        //public abstract Airport GetActualDestination();

        /// <summary>
        /// Get estimated arrival time based on actual departure time
        /// </summary>
        /// <returns></returns>
        //public abstract object GetEstimatedArrival();

        /// <summary>
        /// Total time enroute, based on actual departure time.
        /// If the flight has landed, it is the actual time enroute,
        /// if the flight is in the air, it is the estimated time enroute.
        /// </summary>
        /// <returns></returns>
        //public abstract object GetTimeEnroute();

        //public abstract Crewmember[] GetCrew();
        //public abstract Aircraft GetAircraft();
    }
}
