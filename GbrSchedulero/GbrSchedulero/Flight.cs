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
        public List<FlightCrewAssignment> CrewAssignments { get; set; }

        public Flight(FlightPlan plan, Aircraft ac, int passengers)
        {
            this.Plan = plan;
            this.Ship = ac;
            this.Passengers = passengers;
            this.CrewAssignments = new List<FlightCrewAssignment>();


            //Check if crew is suitable. (Extra crewmembers are placed in passenger seats?)
            //throw new NotImplementedException("Flight class unfinished.");
        }

        public Flight()
        {

        }

        /// <summary>
        /// Returns true if the flight has been assigned a valid crew
        /// </summary>
        /// <returns></returns>
        public bool ValidCrew()
        {
            //Check each position
            foreach (StationType position in Ship.AcType.GetCrewStations())
            {
                bool positionSat = false;

                foreach (FlightCrewAssignment assignment in CrewAssignments)
                    if (assignment.Qualification.Station == position)
                    {
                        positionSat = true;
                        break;
                    }

                if (positionSat == false)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Assigns the specified crewmember position to this flight
        /// </summary>
        public void AssignCrewmember(CrewQualification position)
        {
            FlightCrewAssignment assignment = new FlightCrewAssignment(this, position);
            this.CrewAssignments.Add(assignment);

            //TODO: Doesn't affect ChangeOrders
        }

        /// <summary>
        /// Unassign the provided crew position.
        /// </summary>
        public void RemoveCrewmember(CrewQualification position)
        {
            CrewAssignments.RemoveAll(pos => pos.Qualification == position);

            //TODO: Doesn't affect ChangeOrders
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
