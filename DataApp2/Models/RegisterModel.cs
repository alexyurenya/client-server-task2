﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp2.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Does not specify email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Does not specify password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Incorrect password")]
        public string ConfirmPassword { get; set; }
    }
}
