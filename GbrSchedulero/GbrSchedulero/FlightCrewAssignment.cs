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
        //Primary Key
        public int FlightCrewAssignmentID { get; set; }

        //Foreign Key
        public int FlightID { get; set; }
        public int CrewQualificationID { get; set; }

        //Navigation
        public Flight Flight { get; set; }
        public CrewQualification Qualification { get; set; }
        public AssignmentChangeOrder ChangeOrder { get; set; }


        public FlightCrewAssignment(Flight flight, CrewQualification qualification)
        {
            this.Flight = flight;
            this.Qualification = qualification;
        }
        public FlightCrewAssignment()
        {

        }
    }
}
