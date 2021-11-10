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
    abstract class AircraftType
    {
        public abstract int GetPassengerSeats();
        public abstract string GetTypeName();
        
        /// <summary>
        /// Get the possible crew stations. In our case this will always be a captain and first officer station, plus one or more attendant stations.
        /// Crew qualifications are based on both the AircraftType and the station (implementation tbd).
        /// </summary>
        /// <returns></returns>
        public abstract object GetCrewStations();
    }
}
