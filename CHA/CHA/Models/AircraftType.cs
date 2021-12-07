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
    public class AircraftType
    {
        public string TypeName { get; private set; }
        public int MaxPassengers { get; private set; }
        private List<CrewStation> stations;

        public AircraftType(string typeName, int maxPassengers)
        {
            this.TypeName = typeName;
            this.MaxPassengers = maxPassengers;
            this.stations = new List<CrewStation>();
        }

        public void AddStation(CrewStation station)
        {
            this.stations.Add(station);
        }

        public static AircraftType GBR10()
        {
            AircraftType gbr10 = new AircraftType("GBR-10", 45);

            gbr10.AddStation(new CrewStation(StationType.Captain));
            gbr10.AddStation(new CrewStation(StationType.Officer));
            gbr10.AddStation(new CrewStation(StationType.Attendant));

            return gbr10;
        }

        public static AircraftType NU150()
        {
            AircraftType nu150 = new AircraftType("NU-150", 75);

            nu150.AddStation(new CrewStation(StationType.Captain));
            nu150.AddStation(new CrewStation(StationType.Officer));
            nu150.AddStation(new CrewStation(StationType.Attendant));
            nu150.AddStation(new CrewStation(StationType.Attendant));

            return nu150;
        }

        //public abstract int GetPassengerSeats();
        //public abstract string GetTypeName();
        
        /// <summary>
        /// Get the possible crew stations. In our case this will always be a captain and first officer station, plus one or more attendant stations.
        /// Crew qualifications are based on both the AircraftType and the station (implementation tbd).
        /// </summary>
        /// <returns></returns>
        public List<CrewStation> GetCrewStations()
        {
            return stations;
        }

        public override string ToString()
        {
            return TypeName;
        }
    }
}
