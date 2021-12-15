using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbrSchedulero
{
    /// <summary>
    /// Represents a crew qualification.
    /// </summary>
    public class CrewQualification
    {
        //Primary key
        public int CrewQualificationID { get; set; }

        //Foreign Key
        public int CrewmemberID { get; set; }
        public int AircraftTypeID { get; set; }

        //Navigation
        public Crewmember Crewmember { get; set; }
        public AircraftType AircraftType { get; set; }
        public List<FlightCrewAssignment> Assignments { get; set; }

        //Enum
        public StationType Station { get; set; }
        //public object AircraftTypes { get; set; }//adding from create CrewmemberController

        public CrewQualification(StationType station, AircraftType acType)
        {
            this.Station = station;
            this.AircraftType = acType;
        }

        public CrewQualification()
        {

        }

        public bool Qualified(StationType station)
        {
            if (station == StationType.Captain)
                return this.Station == StationType.Captain || this.Station == StationType.Officer;

            else if (station == StationType.Officer)
                return this.Station == StationType.Officer;

            else
                return this.Station == StationType.Attendant;
        }

        public override string ToString()
        {
            switch (Station)
            {
                case StationType.Captain:
                    return $"Captain, {AircraftType}";
                case StationType.Officer:
                    return $"First Officer, {AircraftType}";
                default:
                    return $"Flight Attendant, {AircraftType}";
            }
        }
    }

    public enum StationType
    {
        Captain,
        Officer,
        Attendant
    }
}
