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

        //Navigation
        public AircraftType AcType { get; private set; }

        //Enum
        public StationType Station { get; private set; }
        public object AircraftTypes { get; set; }

        public CrewQualification(StationType station, AircraftType acType)
        {
            this.Station = station;
            this.AcType = acType;
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
                    return $"Captain, {AcType}";
                case StationType.Officer:
                    return $"First Officer, {AcType}";
                default:
                    return $"Flight Attendant, {AcType}";
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
