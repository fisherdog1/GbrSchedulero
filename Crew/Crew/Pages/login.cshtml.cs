using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Crew.Pages
{
    public class loginModel : PageModel
    {
        [StringLength(60, MinimumLength = 8, ErrorMessage = "Email must be between 8 and 60 characters.")]
        [Required]
        [BindProperty]
        public string Email { get; set; }
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 20 characters.")]
        [Required]
        [BindProperty]
        public string Password { get; set; }
        public void OnGet()
        {
        }
    }
}
