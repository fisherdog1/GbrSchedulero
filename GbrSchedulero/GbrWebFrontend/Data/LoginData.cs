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
        public int CrewmemberID { get; set; }

        [Required]
        [DataType(DataType.Text)]
       
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Required]
        
        public string LastName { get; set; }
       
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 20 characters.")]
        [Required]
        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public void OnGet()
        {
        }
        private List<CrewQualification> qualifications;

        public LoginData(int CrewmemberID, string email, string password, string FirstName, string LastName)
        {
            this.CrewmemberID = CrewmemberID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.EmailAddress = email;
            this.Password = password;

            qualifications = new List<CrewQualification>();
        }

        public LoginData()
        {
        }
    }
}
