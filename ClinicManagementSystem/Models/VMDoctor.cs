using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Models
{
    public class VMDoctor
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Qulification { get; set; }
        public string Specilization { get; set; }
        public char Gender { get; set; }
        public int Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

       
    }
}