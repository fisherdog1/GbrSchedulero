using GbrSchedulero;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CHA.Data
{
    public class Crewmem
    {

        [Key]
        public int CrewID { get; set; }
        //public string FirstName { get;  set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        //public string LastName { get;  set; }
        private List<CrewQualification> qualifications;

        public Crewmem(string firstName, string lastName)
        {
            //this.CrewID = CrewID;
            this.FirstName = firstName;
            this.LastName = lastName;

            qualifications = new List<CrewQualification>();
        }
        //Adding when extract data from database



        /// <summary>
        /// Returns which (if any) crew stations this Crewmember can be assigned on the given aircraft type
        /// </summary>
        /// <returns></returns>
        public List<CrewStation> PossibleAssignments(AircraftType acType)
        {
            List<CrewStation> stations = new List<CrewStation>();

            foreach (CrewQualification qual in qualifications)
                if (qual.AcType == acType)
                    foreach (CrewStation station in acType.GetCrewStations())
                        if (station.Qualified(qual.Station))
                            stations.Add(station);

            return stations;
        }
    }
}