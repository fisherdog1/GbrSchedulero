using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbrSchedulero
{
    /// <summary>
    /// Represents an Aircraft type
    /// 
    /// Aircraft types should be immutable. If an aircraft is modified it should be given a new type.
    /// A Singleton-pattern class could be used to keep track of currently in-use types.
    /// Types should have an appropriate tabular representation in the database (f.e they should not be Enums).
    /// 
    /// Provisionally abstract for outlining purposes. Will most likely become concrete later
    /// Return types and parameters with type Object indicate undecided types.
    /// </summary>
    public class AircraftType : IEquatable<AircraftType>
    {
        //Primary Key
        public int AircraftTypeID { get; set; }
        public string TypeName { get; private set; }
        public int MaxPassengers { get; private set; }
        private List<StationType> stations;

        public AircraftType(string typeName, int maxPassengers)
        {
            this.TypeName = typeName;
            this.MaxPassengers = maxPassengers;
            this.stations = new List<StationType>();
        }

        public void AddStation(StationType station)
        {
            this.stations.Add(station);
        }

        public static AircraftType GBR10()
        {
            AircraftType gbr10 = new AircraftType("GBR-10", 45);

            gbr10.AddStation(StationType.Captain);
            gbr10.AddStation(StationType.Officer);
            gbr10.AddStation(StationType.Attendant);

            return gbr10;
        }

        public static AircraftType NU150()
        {
            AircraftType nu150 = new AircraftType("NU-150", 75);

            nu150.AddStation(StationType.Captain);
            nu150.AddStation(StationType.Officer);
            nu150.AddStation(StationType.Attendant);
            nu150.AddStation(StationType.Attendant);

            return nu150;
        }

        private static AircraftType[] singletonAircraftTypes;
        public static AircraftType[] AllTypes()
        {
            if (singletonAircraftTypes == null)
                singletonAircraftTypes = new AircraftType[] { NU150(), GBR10() };

            return singletonAircraftTypes;
        }

        //public abstract int GetPassengerSeats();
        //public abstract string GetTypeName();

        /// <summary>
        /// Get the possible crew stations. In our case this will always be a captain and first officer station, plus one or more attendant stations.
        /// Crew qualifications are based on both the AircraftType and the station (implementation tbd).
        /// </summary>
        /// <returns></returns>
        public List<StationType> GetCrewStations()
        {
            return stations;
        }

        public override string ToString()
        {
            return TypeName;
        }

        //This might be neccessary to stop EF creating duplicate types?
        public bool Equals(AircraftType other)
        {
            return this.TypeName == other.TypeName;
        }
    }
}
