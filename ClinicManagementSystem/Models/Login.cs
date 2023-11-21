using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Models
{
    public class Login
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="User Name is Required")]
        public string LoginName { get; set; }
         [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}