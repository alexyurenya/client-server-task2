using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp2.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Does not specify email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Does not specify password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
