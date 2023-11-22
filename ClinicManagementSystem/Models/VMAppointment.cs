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
    
       
        public string PId { get; set; }
    }
}