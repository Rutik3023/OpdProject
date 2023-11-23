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
        public int Stastus { get; set; }
        [DataType(DataType.Date)]
[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}{1:HH/mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    
       
        public string PId { get; set; }
    }
}