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
        public CrewStation Station { get; private set; }
        public AircraftType AcType { get; private set; }

        public CrewQualification(CrewStation station, AircraftType acType)
        {
            this.Station = station;
            this.AcType = acType;
        }

        public override string ToString()
        {
            return $"{Station}, {AcType}";
        }
    }

    /// <summary>
    /// Represents either a crew station.
    /// </summary>
    public class CrewStation
    {
        public StationType CrewStationType { get; private set; }

        public CrewStation(StationType crewStationType)
        {
            this.CrewStationType = crewStationType;
        }

        /// <summary>
        /// Checks if (this) crew station can be satisfied by the provided qualification
        /// Note that captains can fulfil either Captain or Officer stations
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        public bool Qualified(CrewStation station)
        {
            if (station.CrewStationType == StationType.Captain)
                return this.CrewStationType == StationType.Captain || this.CrewStationType == StationType.Officer;

            else if (station.CrewStationType == StationType.Officer)
                return this.CrewStationType == StationType.Officer;

            else
                return this.CrewStationType == StationType.Attendant;
        }

        public override string ToString()
        {
            switch (CrewStationType)
            {
                case StationType.Captain:
                    return "Captain";
                case StationType.Officer:
                    return "First Officer";
                default:
                    return "Flight Attendant";
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
