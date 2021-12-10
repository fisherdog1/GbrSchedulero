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
        /// Returns true if the flight has been assigned a valid crew
        /// </summary>
        /// <returns></returns>
        public bool ValidCrew()
        {
            //Temp copy of crew assignments so crewmembers can be removed as roles are filled
            List<FlightCrewAssignment> positionsCopy = new List<FlightCrewAssignment>(Crewmembers);
            FlightCrewAssignment tempRemove = null;

            //Check each position
            foreach (StationType position in Ship.AcType.GetCrewStations())
            {
                foreach (FlightCrewAssignment assignment in positionsCopy)
                    if (assignment.Crewmember.Qualified(Ship.AcType, position))
                    {
                        //Remove the crewmember from the selectable list
                        tempRemove = assignment;
                        break;
                    }
                    else
                        tempRemove = null; //Literally does not work without this, do not remove.

                if (tempRemove != null)
                    positionsCopy.Remove(tempRemove);
                else
                    return false; //Missing a crew position
            }

            return true;
        }

        /// <summary>
        /// Assigns the specified crewmember to this flight, produces a change order which must be saved to the database
        /// </summary>
        /// <param name="crewmember"></param>
        /// <returns></returns>
        public void AssignCrewmember(IChangeOrderUpdater updater, Crewmember crewmember)
        {
            FlightCrewAssignment newAssignment = new FlightCrewAssignment(this, crewmember);
            this.Crewmembers.Add(newAssignment);

            //TODO: Look up previous assignment, this will surely require some dependency injection

            AssignmentChangeOrder oldOrder = updater.GetExistingChangeOrder(newAssignment);
            int? oldAssignmentId = null;

            if (oldOrder != null)
                oldAssignmentId = oldOrder.CurrentAssignment.FlightCrewAssignmentID;

            //Now is temporary, could be different value provided
            AssignmentChangeOrder changeOrder = new AssignmentChangeOrder(oldAssignmentId, newAssignment.FlightCrewAssignmentID, DateTime.Now);

            updater.ApplyChangeOrderUpdate(changeOrder);
        }

        /// <summary>
        /// Unassign the provided crewmember, returns null if no such crewmember, returns a change order otherwise.
        /// </summary>
        /// <param name="crewmember"></param>
        /// <returns></returns>
        public void RemoveCrewmember(IChangeOrderUpdater updater, Crewmember crewmember)
        {
            FlightCrewAssignment currentAssignment = null;

            foreach (FlightCrewAssignment assignment in Crewmembers)
                if (assignment.Crewmember.CrewmemberID == crewmember.CrewmemberID)
                    currentAssignment = assignment;

            //Don't do anything if assignment doesn't exist
            if (currentAssignment == null)
                return;

            AssignmentChangeOrder oldOrder = updater.GetExistingChangeOrder(currentAssignment);

            if (oldOrder == null)
                return;

            AssignmentChangeOrder changeOrder = new AssignmentChangeOrder(oldOrder.CurrentAssignment.FlightCrewAssignmentID, null, DateTime.Now);
            updater.ApplyChangeOrderUpdate(changeOrder);
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
