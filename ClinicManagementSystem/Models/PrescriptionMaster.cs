using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Models
{
    public class PrescriptionMaster
    {
        public int Id { get; set; }
        public int AId { get; set; }
        public string Symtams { get; set; }
        public string Disiese { get; set; }
        public string Narration { get; set; }

       
        public DateTime Createdon { get; set; }

        public List<item> ShopCart { get; set; }
    }
}