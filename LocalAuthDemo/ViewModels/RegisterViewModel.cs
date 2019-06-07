using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocalAuthDemo.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Have to supply an user name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Have to supply an e-mail address")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email format.")]
        [StringLength(345, ErrorMessage = "Email cannot be longer than 345 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Have to supply a password")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", 
            ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The repeat password did not seem correct")]
        public string RepeatPassword { get; set; }
    }
}
