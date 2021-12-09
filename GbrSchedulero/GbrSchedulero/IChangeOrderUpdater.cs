using GbrSchedulero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Interface for providing information about existing flight plans.
/// The implementing class should ensure up-to-dateness with the database when serving flight info, caching where appropriate.
/// </summary>
namespace GbrSchedulero
{
    public interface IChangeOrderUpdater
    {
        /// <summary>
        /// Get the current Change order which is effective on the provided flight crew assignment. Can return null.
        /// Looks for a FlightCrewAssignment which has the same Flight and Crewmember as the provided assignment.
        /// </summary>
        /// <returns></returns>
        public AssignmentChangeOrder GetExistingChangeOrder(FlightCrewAssignment assignment);

        /// <summary>
        /// Apply a change order to the database.
        /// Always adds a new AssignmentChangeOrder to the database.
        /// </summary>
        public void ApplyChangeOrderUpdate(AssignmentChangeOrder changeOrder);
    }
}
