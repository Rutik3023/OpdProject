using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Models
{
    public class VMAppointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int CasepaperId { get; set; }
        public int Status { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public string HealthIssue { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string BP { get; set; }
        public string PId { get; set; }
    }
}