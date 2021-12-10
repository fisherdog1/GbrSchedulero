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
        [Required]
        
        [DataType(DataType.Text, ErrorMessage = "Missing first name")]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text, ErrorMessage ="Missing last name" )]
        public string LastName { get; set; }
        //[StringLength(60, MinimumLength = 8, ErrorMessage = "Email must be between 8 and 60 characters.")]
        //[Required]
        //[BindProperty]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //[StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 60 characters.")]
        //[Required]
        //[BindProperty]
        [Required]
        [DataType(DataType.Password)]
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
    }
}
