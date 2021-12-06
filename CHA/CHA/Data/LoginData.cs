using GbrSchedulero;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CHA.Data
{
    public class LoginData
    {
        [Key]
        public int CrewID { get; set; }

        [StringLength(60, MinimumLength = 8, ErrorMessage = "Email must be between 8 and 60 characters.")]
        [Required]
        [BindProperty]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 60 characters.")]
        [Required]
        [BindProperty]
        public string Password { get; set; }
        public void OnGet()
        {
        }
        private List<CrewQualification> qualifications;

        public LoginData(string email, string password)
        {
            //this.CrewID = CrewID;
            this.Email = email;
            this.Password = password;

            qualifications = new List<CrewQualification>();
        }

        public LoginData()
        {
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
