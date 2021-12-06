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
        [StringLength(60, MinimumLength = 8, ErrorMessage = "Email must be between 8 and 60 characters.")]
        [Required]
        [BindProperty]
        public string Password { get; set; }
        public void OnGet()
        {
        }
    }
}
