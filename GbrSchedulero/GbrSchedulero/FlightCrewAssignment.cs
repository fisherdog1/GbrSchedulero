using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbrSchedulero
{
    //Many-Many representation of a Crewmember assigned to a Flight
    public class FlightCrewAssignment
    {
        public int FlightID { get; set; }
        public Flight Flight { get; set; }
        public int CrewmemberID { get; set; }
        public Crewmember Crewmember { get; set; }

        public FlightCrewAssignment(Flight flight, Crewmember crewmember)
        {
            this.Flight = flight;
            this.Crewmember = crewmember;
        }
        public FlightCrewAssignment()
        {

        }
    }
}
