using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Models
{
    public class VMAppointment
    {
        public int Id { get; set; }
        public int DrId { get; set; }
        public int Cid { get; set; }
        public string Stastus { get; set; }
   
        public DateTime Date { get; set; }
    
       
        public string PId { get; set; }
    }
}