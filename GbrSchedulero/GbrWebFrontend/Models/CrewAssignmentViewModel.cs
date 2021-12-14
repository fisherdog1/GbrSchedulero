using GbrSchedulero;
using System.Collections.Generic;

public class CrewAssignmentViewModel
{
    public int FlightID;
    public IEnumerable<FlightCrewAssignment> CurrentCrew;
    public IEnumerable<CrewAssignmentViewLine> Lines;
}