using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Models
{
    public class VMCasePaper
    {
        public int Id { get; set; }
        public int PId { get; set; }
        public string Height { get; set; }
        public string Wight { get; set; }
        public string BP { get; set; }
        public string HealthIssue { get; set; }
        public int CasepaperFee { get; set; }
        public int CreaedBy { get; set; }
        public DateTime Createdon { get; set; }
    }
}