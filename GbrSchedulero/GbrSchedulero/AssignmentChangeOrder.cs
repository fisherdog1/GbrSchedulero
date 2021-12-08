using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbrSchedulero
{
    /// <summary>
    /// Represents a change in FlightCrewAssignment state. Used to keep track of crew assignment changes
    /// 
    /// If no previous assignment was replaced, ReplacedAssignmentID is null
    /// Deleting an assignment should generate a change order with a null NewAssignmentID
    /// Having both ID's null is not valid
    /// 
    /// ChangeEffected indicates the dateTime when this change was made
    /// 
    /// A FlightCrewAssignment can only be replaced once by a change order, so one-one relationship
    /// </summary>
    public class AssignmentChangeOrder
    {
        //Primary Key
        public int AssignmentChangeOrderID { get; set; }

        //Foreign Key
        public int? PreviousOrderID { get; set; }
        public int? CurrentOrderID { get; set; }

        public DateTime ChangeEffected { get; set; }

        //Navigation
        public FlightCrewAssignment PreviousOrder { get; set; }
        public FlightCrewAssignment CurentOrder { get; set; }

        public AssignmentChangeOrder()
        {

        }
    }
}
