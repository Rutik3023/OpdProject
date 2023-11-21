using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Models
{
    public class VMPatient
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string AdhaarNo { get; set; }
        public int BloodGroupId { get; set; }
        public char Gender { get; set; }
        public string Photo { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
    }
}