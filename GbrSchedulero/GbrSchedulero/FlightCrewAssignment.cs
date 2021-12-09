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
        public int CrewmemberID { get; set; }

        //Navigation
        public Flight Flight { get; set; }
        public Crewmember Crewmember { get; set; }
<<<<<<< HEAD
      
=======
        public AssignmentChangeOrder ChangeOrder { get; set; }
>>>>>>> 3866b15b5c84358f348ff1e7d4decb5047c91935

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
