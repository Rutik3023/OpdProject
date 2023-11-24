using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Models
{
    public class VMPrescription
    {
        public int Id { get; set; }
        public int AId { get; set; }
        public int PId { get; set; }
        public int CId { get; set; }
        public string Narration { get; set; }
        public DateTime Createdon { get; set; }
        public string Symtams { get; set; }
        public string Disiese { get; set; }
        public int MedicineId { get; set; }
        public int QTY { get; set; }
        public bool MDose { get; set; }
        public bool AfDose { get; set; }
        public bool NDose { get; set; }
        public string Stastus { get; set; }
    }
}