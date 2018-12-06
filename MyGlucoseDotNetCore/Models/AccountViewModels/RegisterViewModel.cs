﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyGlucoseDotNetCore.Models.AccountViewModels
{
    public class RegisterViewModel
    {

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }

        public List<ApplicationRole> AllRoles { get; set; }

        //public string SelectedUser { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        // API
        [Display( Name = "Doctor" )]
        public string DoctorUserName { get; set; }
        // Register:
        [Display( Name = "Degree Abbreviation" )]
        public string DegreeAbbreviation { get; set; }
        [Display( Name = "Doctor" )]
        public List<Doctor> AllDoctors { get; set; }

        public Patient GetNewPatient()
        {
            return new Patient
            {
                Email = Email,
                DoctorUserName = DoctorUserName,
                UserName = Email
            };

        } // GetNewPatient

        public RegisterViewModel()
        {
            //Role = new ApplicationRole();
        }

    }

}
