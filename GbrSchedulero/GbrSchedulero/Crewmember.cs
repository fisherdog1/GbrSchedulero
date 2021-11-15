using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbrSchedulero
{
    public abstract class Crewmember
    {
        public abstract string GetFirstName();
        public abstract string GetLastName();

        /// <summary>
        /// Get the type of Crewmember, such as Captain, FO, or Attendant
        /// </summary>
        /// <returns>Some representation of the type, possibly Enum or an object</returns>
        public abstract object GetCrewmemberType();

        /// <summary>
        /// Returns whether this Crewmember is qualified to staff the passed crew station (type tbd)
        /// </summary>
        /// <param name="crewStation">The crew station being checked against</param>
        /// <returns></returns>
        public abstract bool IsQualified(object crewStation);

        /// <summary>
        /// Returns true if the Crewmember is accumulating rest hours (Landed with no upcoming flights)
        /// </summary>
        /// <returns></returns>
        public abstract bool IsResting();

        /// <summary>
        /// True if Crewmember is currently working, either duty or non-duty hours.
        /// May be true if the crew is waiting for an upcoming flight, or on a flight.
        /// A Crewmember is not stationed if:
        /// They are deadheading a flight back to their home base
        /// They are resting (Landed with no upcoming flights)
        /// A Crewmember is still stationed even if they run out of duty hours if:
        /// They are overdue returning to their home base
        /// </summary>
        /// <returns></returns>
        public abstract bool IsStationed();

        /// <summary>
        /// True if Crewmember is currently performing crew duties.
        /// A Crewmember on duty is necessarily stationed, but Crewmembers are not on duty while waiting for upcoming flights or deadheading.
        /// </summary>
        /// <returns></returns>
        public abstract bool IsOnDuty();

        /// <summary>
        /// True if crewmember is on a flight but not acting as a crewmember. 
        /// Deadheads do not count towards the crewing requirements of aircraft.
        /// </summary>
        /// <returns></returns>
        public abstract bool IsDeadhead();

        /// <summary>
        /// Get the number of duty hours this Crewmember has left on their shift. 
        /// Crewmembers are not allowed to exceed their duty hours except in an emergency (diversion, RTB, etc).
        /// </summary>
        /// <returns></returns>
        public abstract object GetDutyHoursRemaining();
    }
}
