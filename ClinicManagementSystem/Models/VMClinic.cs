using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Models
{
    public class VMClinic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string RegNo { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime OpenTime { get; set; }
         
        [DataType(DataType.DateTime)] 
      
        public DateTime CloseTime { get; set; }
        public string Photo { get; set; }
        public int CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Createdon { get; set; }
        public string Mobile { get; set; }
    }
}