using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace lab4.Models
{
    public class AuthModel
    {
        [Required(ErrorMessage = "Email required")]
        [EmailAddress(ErrorMessage = "Incorrect email")]
        [Remote(action: "CheckEmail", controller: "Mockups")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password not specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Incorrect password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Name not specified")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name not specified")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Day not specified")]
        public int Day { get; set; }

        [Required(ErrorMessage = "Month not specified")]
        public string Month { get; set; }

        [Required(ErrorMessage = "Year not specified")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Gender not specified")]
        public string Gender { get; set; }

        public bool Remember { get; set; }
        public string Code { get; set; }
    }



    public class AccountsBase
    {
        private static readonly AccountsBase Instance = new AccountsBase();
        private Dictionary<string, AuthModel> Accounts = new Dictionary<string, AuthModel>();
        public static Dictionary<string, AuthModel> Get()
        {
            return Instance.Accounts;
        }
    }
}
