using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Models
{
    public class VMDoctor
    {
        public int Id { get; set; }

        [Required]
        public int ClinicId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Qulification { get; set; }

        [Required]
        public string Specilization { get; set; }

        [Required]
        public char Gender { get; set; }

        [Required]
        public int Role { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        public string Photo { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

       
    }
}