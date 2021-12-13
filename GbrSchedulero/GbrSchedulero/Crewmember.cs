using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbrSchedulero
{
    public class Crewmember
    {
        //Primary Key
        public int CrewmemberID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Navigation
        public List<CrewQualification> Qualifications { get; set; }
        public List<FlightCrewAssignment> Flights { get; set; }

        public Crewmember(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

            Qualifications = new List<CrewQualification>();
        }

        public Crewmember()
        {

        }

        public void AddQualification(CrewQualification qualification)
        {
            this.Qualifications.Add(qualification);
        }

        internal bool Qualified(AircraftType type, StationType position)
        {
            foreach (CrewQualification qual in Qualifications)
                if (qual.Station == position && qual.AircraftType == type)
                    return true;

            return false;
        }

        /// <summary>
        /// Returns true if the Crewmember is accumulating rest hours (Landed with no upcoming flights)
        /// </summary>
        /// <returns></returns>
        //public abstract bool IsResting();

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
        //public abstract bool IsStationed();

        /// <summary>
        /// True if Crewmember is currently performing crew duties.
        /// A Crewmember on duty is necessarily stationed, but Crewmembers are not on duty while waiting for upcoming flights or deadheading.
        /// </summary>
        /// <returns></returns>
        //public abstract bool IsOnDuty();

        /// <summary>
        /// True if crewmember is on a flight but not acting as a crewmember. 
        /// Deadheads do not count towards the crewing requirements of aircraft.
        /// </summary>
        /// <returns></returns>
        //public abstract bool IsDeadhead();

        /// <summary>
        /// Get the number of duty hours this Crewmember has left on their shift. 
        /// Crewmembers are not allowed to exceed their duty hours except in an emergency (diversion, RTB, etc).
        /// </summary>
        /// <returns></returns>
        //public abstract object GetDutyHoursRemaining();

        public override string ToString()
        {
            string str = $"{LastName}, {FirstName}\n";

            foreach (CrewQualification qual in Qualifications)
            {
                str += "    " + qual + "\n";
            }

            return str;
        }
    }
}
