using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicManagementSystem.Models
{
    public class item
    {


        public int Srno { get; set; }

        public int QTY { get; set; }
        public int MedicineId { get; set; }
        public string Medicinename { get; set; }
      
        public bool MDose { get; set; }
        public bool AfDose { get; set; }
        public bool NDose { get; set; }
        
        
    
    
    }
}